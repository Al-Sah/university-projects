#include <windows.h>
#include <iostream>
#include <random>

#include "config.h"

volatile static size_t readPos  = 0;
volatile static size_t writePos = 0;

struct treadInfo{
    char* buffer;
    HANDLE reader;
    HANDLE writer;
};

DWORD APIENTRY bufferReader(LPVOID info){
    WaitForSingleObject(((treadInfo*)info)->writer, INFINITE);
    for(readPos = 0; readPos < BYTES; readPos++){
        std::cout << ((treadInfo*)info)->buffer[readPos];
    }
    std::cout << std::endl;
    if (!SetEvent(((treadInfo*)info)->reader)){
        std::cout << "Reader: SetEvent failed; last error: " << GetLastError() << std::endl;
        return 1;
    }
    return 0;
}
DWORD APIENTRY bufferWriter(LPVOID info){
    std::random_device rd;
    std::mt19937 eng(rd());
    std::uniform_int_distribution<int> dist(MIN_VALUE,MAX_VALUE);

    for(writePos = 0; writePos < BYTES; writePos++){
        ((treadInfo*)info)->buffer[writePos] = char(dist(eng));
    }
    if (!SetEvent(((treadInfo*)info)->writer)){
        std::cout << "Writer: SetEvent failed; last error: " << GetLastError() << std::endl;
        return 1;
    }
    return 0;
}


int main(){
    char *buffer = (char*) malloc(BYTES);
    if(buffer == nullptr){
        std::cout << "Failed to allocate memory\n";
        return 1;
    }
    // manual-reset event - true
    HANDLE writeEvent = CreateEvent(nullptr, TRUE, INIT_STATE, nullptr),
            readEvent = CreateEvent(nullptr, TRUE, INIT_STATE, nullptr);
    if (writeEvent == nullptr || readEvent == nullptr){
        std::cout << "Events creation failed; last error: " << GetLastError() << std::endl;
        free(buffer);
        return 1;
    }

    treadInfo info{
        .buffer = buffer,
        .reader = readEvent,
        .writer = writeEvent,
    };
    HANDLE threads[] = {
            CreateThread(nullptr, 0, bufferReader, &info, 0, nullptr),
            CreateThread(nullptr, 0, bufferWriter, &info, 0, nullptr)
    };

    // wait until all are signaled
    DWORD waitResult = WaitForMultipleObjects(2, threads, TRUE, INFINITE);
    if(waitResult == WAIT_OBJECT_0) {
        std::cout << "Happy end !!!! \n";
    }else{
        std::cout << "Main: WaitForMultipleObjects failed; last error: " << GetLastError() << std::endl;
    }
    CloseHandle(writeEvent);
    CloseHandle(readEvent);
    CloseHandle(threads[0]);
    CloseHandle(threads[1]);
    free(buffer);
    return 0;
}