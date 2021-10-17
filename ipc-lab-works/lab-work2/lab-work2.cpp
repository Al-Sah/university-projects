#include <windows.h>
#include <iostream>
#include <random>

#define BYTES 1000

#define MIN_VALUE 33
#define MAX_VALUE 150

volatile static size_t readPos  = 0;
volatile static size_t writePos = 0;


DWORD APIENTRY bufferReader(LPVOID bufferPtr){

    char* buffer = (char*)bufferPtr;
    for(readPos = 0; readPos < BYTES; readPos++){
        std::cout << buffer[readPos];
    }
    return 0;
}
DWORD APIENTRY bufferWriter(LPVOID bufferPtr){

    char* buffer = (char*)bufferPtr;
    std::random_device rd;
    std::mt19937 eng(rd());
    std::uniform_int_distribution<int> dist(MIN_VALUE,MAX_VALUE);

    for(writePos = 0; writePos < BYTES; writePos++){
        buffer[writePos] = char(dist(eng));
    }
    return 0;
}

int main(){

    char *buffer = (char*) malloc(BYTES);

    DWORD readerId, writerId;
    HANDLE writer = CreateThread(nullptr, 0, bufferWriter, buffer, 0, &writerId);
    Sleep(2000);
    HANDLE reader = CreateThread(nullptr, 0, bufferReader, buffer, 0, &readerId);
    Sleep(2000);

    free(buffer);
}