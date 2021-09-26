#include "framework.h"

//#define MEGABYTE_TO_BYTES 1000000
#define MEGABYTE_TO_BYTES 1048576
#define MAX_ALLOC_MEGABYTES 10  // in megabytes

#ifdef _WIN64
#define GetTickCount GetTickCount64
#endif

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

DWORD APIENTRY thread_callback(LPVOID threadsPtr){

    auto threads = (std::map<ThreadId,ThreadInfo>*)threadsPtr;
    DWORD tickStart, tickEnd;
    DWORD id;

    while (true){
        WaitForSingleObject(hMutex, INFINITE);
        id = GetCurrentThreadId();
        auto item = threads->find(id);
        if (item == threads->end()) {
            ReleaseMutex(hMutex);
            return -1; // ERROR
        }

        tickStart = GetTickCount();
        item->second.allocatedMemory->push_back(malloc(allocation_size));
        item->second.currentlyAllocated += allocation_size;
        tickEnd = GetTickCount();

        std::cout << "Thread [ " << setw(id, 5) << " ] allocated memory in "
                  << setw((double)(tickEnd - tickStart)/1000, 5) << " sec "
                  << "Currently allocated [ " << setw(item->second.currentlyAllocated, 7) << " ]; "
                  << "Max: [ "<< setw(item->second.maxSize, 5) <<" ]\n";

        if(item->second.currentlyAllocated >=  item->second.maxSize){
            ReleaseMutex(hMutex);
            break;
        }
        ReleaseMutex(hMutex);
    }

    WaitForSingleObject(hMutex, INFINITE);
    --threads_counter;
    auto item = threads->find(GetCurrentThreadId())->second;
    for (auto &ptr : *item.allocatedMemory){
        free(ptr);
    }
    ReleaseMutex(hMutex);
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

    hMutex = CreateMutex(
            nullptr,    // default security attributes
            FALSE,      // initially not owned
            nullptr);   // unnamed mutex
    if (hMutex == nullptr) {
        std::cout << "CreateMutex error: " << GetLastError()<< std::endl;
        return 1;
    }

    std::random_device rd;
    std::mt19937 rand(rd());
    std::map<ThreadId,ThreadInfo> threads;

    for(int i = 0; i < THREADS; i++){
        setupThread(threads, rand);
    }
    std::cout << " All threads are created\n";

    QueryPerformanceFrequency(&frequency);
    QueryPerformanceCounter(&start);

    for (const auto &item : threads){
        if(ResumeThread(item.second.threadHandle) == -1){
            std::cout << "ResumeThread error: " << GetLastError() << std::endl;
        }
    }

    while (threads_counter) {
        Sleep(0);
    }

    QueryPerformanceCounter(&end);
    res = ((end.QuadPart - start.QuadPart) * 1000 ) / frequency.QuadPart;
    std::cout << "\n All threads are finished in " << res << " ms\n";

    for (const auto &item : threads){
        CloseHandle(item.second.threadHandle);
    }
    CloseHandle(hMutex);

    return 0;
}
