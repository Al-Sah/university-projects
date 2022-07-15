#include <iostream>

using namespace std;

int main() {

    bool cpu_is_32 = false;
    __asm
    {

        pushf           // сохранить копию регистра флагов
        pop bx          // восстановить в BX
        mov ax, 0x0FFF; // очистить биты 12 - 15 в AX
        and ax, bx
        push ax;        // сохранить новое значение регистра флагов
        popf
        pushf;          // установить регистр флагов
        pop ax;         // сохранить копию нового регистра флагов в AX

        mov cx, 0xF000
        and ax, cx
        cmp ax, cx;     // если биты 12 - 15 установлены, cpu - 32bit
        jne not_32bit;  // переход, если не 32

    cpu_32bit:
        mov[cpu_is_32], 1; // 32
    not_32bit:
        mov[cpu_is_32], 0; // !32
    }
    cout << "This cpu is 32: " << cpu_is_32 << endl;

    int value = 0;
    // The largest CPUID standard function input value supported by the processor implementation.
    __asm{
        mov eax, 0
        cpuid
        mov value, eax
    }

    // CPUID Fn8000_0000_EAX Largest Extended Function Number
    __asm {
        mov eax, 0x80000000
        cpuid
        mov value, eax
    }

    // CPUID Fn0000_0000_E[D,C,B]X value
    __asm {
        mov eax, 0x0
        cpuid
    }

    //CPUID Fn0000_0001_EAX Family, Model, Stepping Identifiers
    __asm {
        mov eax, 1
        cpuid
    }

    //CPUID Fn8000_0005_EAX L1 Cacheand TLB Identifiers
    __asm {
        mov eax, 0x80000005
        cpuid
    }

    __asm {
        mov eax, 0x80000006
        cpuid
    }
    
    return 0;
}
