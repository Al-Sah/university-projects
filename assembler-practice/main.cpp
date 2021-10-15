
#include <iostream>
#define LAB1
#define LAB2

extern "C" void fillArray32bit(int*);
extern "C" void decimal2binary32bit(unsigned int, bool*);
extern "C" void decimal2binary(int, int*);
extern "C" void decimal2binary64bit(unsigned long long, bool*);

typedef unsigned long long reg64;
typedef unsigned int reg32;

struct GeneralRegisters64bit{
    reg64 reg_rax;
    reg64 reg_rdx;
    reg64 reg_rbx;
    reg64 reg_rcx;
    reg64 reg_rsi;
    reg64 reg_rdi;
    reg64* reg_rsp;
    reg64* reg_rbp;
};
struct GeneralRegisters32bit{
    reg32 reg_eax;
    reg32 reg_edx;
    reg32 reg_ebx;
    reg32 reg_ecx;
    reg32 reg_esi;
    reg32 reg_edi;
    reg32 reg_esp;
    reg32 reg_ebp;
};

extern "C" void getRegistersState64bit(GeneralRegisters64bit*);
extern "C" void getRegistersState32bit(GeneralRegisters32bit*);

void printBin(int size, const bool array[]);
void printRegistersState(GeneralRegisters64bit &reg);
void printRegistersState(GeneralRegisters32bit &reg);
void printRegistersStateBinary(GeneralRegisters32bit &reg);
void printRegistersStateBinary(GeneralRegisters64bit &reg);
void test_lab1();



int compare1(int a, int b){
    return a > b ? 0 : 1;
}
int compare2(int a, int b){
    return a < b ? 0 : 1;
}

template <typename my_type>
void printArray(my_type *arr, size_t size);
template <typename my_type>
void fillArray(my_type arr[], size_t size);

extern "C" int findMin(int, int*);
extern "C" int findMax(int, int*);
extern "C" int calcAverage(int, int*);
extern "C" void sortArray(int, int*, int(*)(int,int));

int main() {

#ifdef LAB1
    GeneralRegisters64bit reg64{};
    GeneralRegisters32bit reg32{};

    getRegistersState64bit(&reg64);
    getRegistersState32bit(&reg32);
    printRegistersStateBinary(reg64);
    printRegistersStateBinary(reg32);

    int a = 1;
    a = a << 4;

    getRegistersState64bit(&reg64);
    getRegistersState32bit(&reg32);
    printRegistersStateBinary(reg64);
    printRegistersStateBinary(reg32);

    a = a >> 2;

    getRegistersState64bit(&reg64);
    getRegistersState32bit(&reg32);
    printRegistersStateBinary(reg64);
    printRegistersStateBinary(reg32);
#endif
    std::cout<< std::endl;
#ifdef LAB2
    int size = 20, min, max;
    int array[20];
    int average;

    int z;
    z = compare1(23,20);


    fillArray(array, size);

    std::cout << "\nArray: ";
    printArray(array, size);

    min = findMin(size, array);
    std::cout << "\nArray min element: " << min;
    max = findMax(size, array);
    std::cout << "\nArray max element: " << max;

    average = calcAverage(5, array);
    std::cout << "\nArray average: " << average;

    int(*compareFuncPtr)(int, int);
    compareFuncPtr = compare2;

    sortArray(size, array, compareFuncPtr);
    std::cout << "\nSorted array (1): ";
    printArray(array, size);


    compareFuncPtr = compare1;
    sortArray(size, array, compareFuncPtr);
    std::cout << "\nSorted array (2): ";
    printArray(array, size);


    return 0;
#endif
}








void printBin(int size, const bool array[]){
    for(int i = 0; i < size; i++){
        if(array[i]){
            std::cout << "1";
        }else{
            std::cout << "0";
        }
    }
}

void printRegistersState(GeneralRegisters64bit &reg){
    std::cout << "rax " << reg.reg_rax << std::endl;
    std::cout << "rdx " << reg.reg_rdx << std::endl;
    std::cout << "rbx " << reg.reg_rbx << std::endl;
    std::cout << "rcx " << reg.reg_rcx << std::endl;
    std::cout << "rsi " << reg.reg_rsi << std::endl;
    std::cout << "rdi " << reg.reg_rdi << std::endl;
    std::cout << "rsp " << reg.reg_rsp << std::endl;
    std::cout << "rbp " << reg.reg_rbp << std::endl;
}

void printRegistersState(GeneralRegisters32bit &reg){
    std::cout << "eax " << reg.reg_eax << std::endl;
    std::cout << "edx " << reg.reg_edx << std::endl;
    std::cout << "ebx " << reg.reg_ebx << std::endl;
    std::cout << "ecx " << reg.reg_ecx << std::endl;
    std::cout << "esi " << reg.reg_esi << std::endl;
    std::cout << "edi " << reg.reg_edi << std::endl;
    std::cout << "esp " << reg.reg_esp << std::endl;
    std::cout << "ebp " << reg.reg_ebp << std::endl;
}


void printRegistersStateBinary(GeneralRegisters32bit &reg){
    bool array[32] = {};
    decimal2binary32bit(reg.reg_eax, array);
    std::cout << "\neax ";
    printBin(32,array);

    decimal2binary32bit(reg.reg_edx, array);
    std::cout << "\nedx ";
    printBin(32,array);

    decimal2binary32bit(reg.reg_ebx, array);
    std::cout << "\nebx ";
    printBin(32,array);

    decimal2binary32bit(reg.reg_ecx, array);
    std::cout << "\necx ";
    printBin(32,array);

    decimal2binary32bit(reg.reg_esi, array);
    std::cout << "\nesi ";
    printBin(32,array);

    decimal2binary32bit(reg.reg_edi, array);
    std::cout << "\nedi ";
    printBin(32,array);

    decimal2binary32bit(reg.reg_edi, array);
    std::cout << "\nedi ";
    printBin(32,array);

    decimal2binary32bit(reg.reg_esp, array);
    std::cout << "\nesp ";
    printBin(32,array);

    decimal2binary32bit(reg.reg_ebp, array);
    std::cout << "\nebp ";
    printBin(32,array);
}

void printRegistersStateBinary(GeneralRegisters64bit &reg){
    bool array[64] = {};
    decimal2binary64bit(reg.reg_rax, array);
    std::cout << "\nrax ";
    printBin(64,array);

    decimal2binary64bit(reg.reg_rdx, array);
    std::cout << "\nrdx ";
    printBin(64,array);

    decimal2binary32bit(reg.reg_rbx, array);
    std::cout << "\nrbx ";
    printBin(64,array);

    decimal2binary64bit(reg.reg_rcx, array);
    std::cout << "\nrcx ";
    printBin(64,array);

    decimal2binary64bit(reg.reg_rsi, array);
    std::cout << "\nrsi ";
    printBin(64,array);

    decimal2binary64bit(reg.reg_rdi, array);
    std::cout << "\nrdi ";
    printBin(64,array);

    decimal2binary64bit(reg.reg_rdi, array);
    std::cout << "\nrdi ";
    printBin(64,array);

    decimal2binary64bit(*reg.reg_rsp, array);
    std::cout << "\nrsp ";
    printBin(64,array);

    decimal2binary64bit(*reg.reg_rbp, array);
    std::cout << "\nrbp ";
    printBin(64,array);
}


void test_lab1(){
    unsigned int number32bit = 23210, temp = 23210;
    unsigned long long int number64bit = 753766792959;

    int test[32] = {};
    decimal2binary(temp, test);

    int test32[32] = {};
    fillArray32bit(test32);

    bool test32bin[32] = {};
    decimal2binary32bit(number32bit, test32bin);
    printBin(32, test32bin);

    bool test64bin[64] = {};
    decimal2binary64bit(number64bit, test64bin);
}


template <typename my_type>
void printArray(my_type *arr, size_t size){
    for(int i = 0; i < size; i++){
        std::cout << arr[i] << "  ";
    }
}

template <typename my_type>
void fillArray(my_type arr[], size_t size){
    srand(0);
    for(int i = 0; i < size; i++){
        arr[i] = rand() % 1000 - 40;
    }
}

/*struct MinMax{
    int min;
    int max;
};
extern "C" int findMinAndMax(int, int*, MinMax*);
     //fillArray(array, size);
    //auto *mm = new MinMax{};
    //findMinAndMax(size, array, mm);
 */
