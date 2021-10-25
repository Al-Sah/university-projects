#include "framework.h"

//#define MEGABYTE_TO_BYTES 1000000
#define MEGABYTE_TO_BYTES 1048576
#define MAX_ALLOC_MEGABYTES 10  // in megabytes
#define setw(val, n) std::setw(n)<<val

#define THREADS 5
typedef DWORD ThreadId;

static HANDLE hMutex = nullptr;
static size_t allocation_size = MEGABYTE_TO_BYTES / 2;

volatile static size_t threads_counter = 0;

struct ThreadInfo{
    HANDLE  threadHandle;
    size_t  maxSize;
    size_t  currentlyAllocated;
    std::list<void*>* allocatedMemory;
};

inline size_t get_max_allocation_size(std::mt19937 &rand_engine){
    size_t result = (size_t)rand_engine() % (MEGABYTE_TO_BYTES * MAX_ALLOC_MEGABYTES);
    result = (result < MEGABYTE_TO_BYTES) ? result + MEGABYTE_TO_BYTES : result;
    return result;
}

DWORD APIENTRY thread_callback(LPVOID threadsPtr){ // pass item_ptr

    auto threads = (std::map<ThreadId,ThreadInfo>*)threadsPtr;
    DWORD id = GetCurrentThreadId();

    auto item = threads->find(id);
    if (item == threads->end()) {
        return -1; // ERROR
    }

    while (true){
        item->second.allocatedMemory->push_back(malloc(allocation_size));
        item->second.currentlyAllocated += allocation_size;

        WaitForSingleObject(hMutex, INFINITE);
        std::cout << "Thread [ " << setw(id, 5) << " ] "
                  << "Currently allocated [ " << setw(item->second.currentlyAllocated, 7) << " ]; "
                  << "Max: [ " << setw(item->second.maxSize, 6) << " ]\n";
        ReleaseMutex(hMutex);

        if(item->second.currentlyAllocated >=  item->second.maxSize){
            WaitForSingleObject(hMutex, INFINITE);
            std::cout << "Thread [ " << setw(id, 5) << " ] STOP !\n";
            ReleaseMutex(hMutex);
            break;
        }
    }

    WaitForSingleObject(hMutex, INFINITE);
    --threads_counter;
    ReleaseMutex(hMutex);
    for (auto &ptr : *item->second.allocatedMemory){
        free(ptr);
    }
    return 0;
}


void setupThread(std::map<ThreadId,ThreadInfo> &threads, std::mt19937 &rand_engine){
    DWORD threadId;
    HANDLE newThreadHandle = CreateThread(nullptr, 0, thread_callback, &threads, CREATE_SUSPENDED, &threadId);

    threads[threadId] = {
            .threadHandle = newThreadHandle,
            .maxSize = get_max_allocation_size(rand_engine),
            .currentlyAllocated = 0,
            .allocatedMemory = new std::list<void*>(),
    };
    if( threads[threadId].threadHandle == nullptr ){
        std::cout << "CreateThread error: " << GetLastError() << std::endl;
    } else{
        threads_counter++;
    }
}

int main() {
    LARGE_INTEGER start, end, frequency;
    LONGLONG res;

    std::random_device rd;
    std::mt19937 rand(rd());
    std::map<ThreadId,ThreadInfo> threads;

    hMutex = CreateMutex(
            nullptr,    // default security attributes
            FALSE,      // initially not owned
            nullptr);   // unnamed mutex
    if (hMutex == nullptr) {
        std::cout << "CreateMutex error: " << GetLastError()<< std::endl;
        return 1;
    }

    for(int i = 0; i < THREADS; i++){
        setupThread(threads, rand);
    }
    std::cout << " All threads are created: " << threads_counter << std::endl;

    QueryPerformanceFrequency(&frequency);
    QueryPerformanceCounter(&start);

    for (const auto &item : threads){
        if(ResumeThread(item.second.threadHandle) == -1){
            std::cout << "ResumeThread error: " << GetLastError() << std::endl;
        }
    }

    while (threads_counter) {} // threads_counter - volatile

    QueryPerformanceCounter(&end);
    res = ((end.QuadPart - start.QuadPart) * 1000 ) / frequency.QuadPart;
    std::cout << "\n All threads are finished in " << res << " ms\n";

    for (const auto &item : threads){
        CloseHandle(item.second.threadHandle);
    }
    CloseHandle(hMutex);

    return 0;
}