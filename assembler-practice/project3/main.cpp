#include <iostream>

using namespace std;

// task3
float calc_formula_acrsin(float number1, float number2);
float calc_formula_task2();
void calc_formula_task1();
void calc_formula_task4();

int main ()
{

    calc_formula_task1();

    cout << "Y = (5,6^x) / (3 * x^2) ; Result: ";
    cout << calc_formula_task2() << endl;

    cout << "Y = Y = 2 * arcSin ((A^2 + B^2) / 3). ; Result: ";
    cout << calc_formula_acrsin(0.4, 1.1) << endl;

    calc_formula_task4();
    char n;
    std::cin >> n;
    return 0;
}



float calc_formula_task2() {
    float a = 3, b = 5.6, limit = 200;
    float X = 1, Y;
    _asm
    {
        finit
        fld1; load 1

        m1:
            fld     ST(0)       // copy top
            fld     b           // ST(0) = 5.6
            fyl2x               // ST(0) = X * log_2(5.6)
            fld1
            fld     ST(1)       // reaload X * log_2(5.6)
            fprem               // float part X * log_2(5.6)
            f2xm1               // ST(0) = 2^(fprem)-1
            fadd                // add 1
            fscale              // ST(0) =  5.6 ^ X
            fxch    ST(1)       // st(0) <-> st(1) (swap)
            fstp    ST(0)       // ST(0) = 5.6 ^ X; ST(1) = X
            fld     ST(1)       // reaload X
            fmul    ST(0), ST(0)// ST(0) =  X ^ 2
            fld     a
            fmulp   ST(1), ST(0)// ST(0) =  3 * X ^ 2

            fdiv                // ST(0) =  (5.6 ^ x / (3 * x ^ 2))

            fld limit           // load limit number
            fcomip ST(0), ST(1) // compare 
            jna m2              // Jump Not Above
            fstp ST(0)          // claer top
            fld1                // load 1
            fadd                // ST(0) = X + 1
            jmp m1              

            m2:

            fstp    ST(0)
            fstp    Y
    }
    return Y;
}

//float calc_formula_task2() {
//    float a = 3, b = 5.6, limit = 200;
//    float X = 1, Y;
//    _asm
//    {
//        finit
//        fld1; load 1
//
//        m1:
//        fld     ST(0)        // copy top
//            fld     b           // ST(0) = 5.6
//            fyl2x               // ST(0) = X * log_2(5.6)
//            fld1
//            fld     ST(1)       // reaload X * log_2(5.6)
//            fprem               // float part X * log_2(5.6)
//            f2xm1               // ST(0) = 2^(fprem)-1
//            fadd                // add 1
//            fscale              // ST(0) =  5.6 ^ X
//            fxch    ST(1)       // st(0) <-> st(1) (swap)
//            fstp    ST(0)       // ST(0) = 5.6 ^ X; ST(1) = X
//            fld     ST(1)       // reaload X
//            fmul    ST(0), ST(0)// ST(0) =  X ^ 2
//            fld     a
//            fmulp   ST(1), ST(0)// ST(0) =  3 * X ^ 2
//
//            fdiv                // ST(0) =  (5.6 ^ x / (3 * x ^ 2))
//
//            fld limit           // load limit number
//            fcomip ST(0), ST(1) // compare 
//            jna m2              // Jump Not Above
//            fstp ST(0)          // claer top
//            fld1                // load 1
//            fadd                // ST(0) = X + 1
//            jmp m1
//
//            m2 :
//
//        fstp    ST(0)
//            fstp    Y
//    }
//    return Y;
//}

void calc_formula_task4() {
    float number = 12, step = 0.3, start = 0.5, X = 0, res[6];
    _asm
    {
        lea  EDI, res
        mov  ECX, 6
        finit

        m4:
            fld     X           // SP(0) = X 
            fadd    start       // SP(0) = X + 0.5 (current value)
            fst     X               // store x
            fld     number      // ST(0) = 12
            fyl2x               // ST(0) = X * log_2(12)
            fld1
            fld     ST(1)       // reaload X * log_2(12)
            fprem               // float part X * log_2(12)
            f2xm1               // ST(0) = 2^(fprem)-1
            fadd                // add 1
            fscale              // ST(0) =  12 ^ X
            fxch    ST(1)       // st(0) <-> st(1) (swap)
            fstp    ST(0)       // ST(0) = 12 ^ X; ST(1) = X
            fstp    dword ptr[EDI]  // save to arr
            fstp    ST(0)
           
            add     EDI, 4
            mov     eax, dword ptr[step]
            mov     dword ptr[start], eax

        loop  m4
    }
    std::cout << "task4: results: \n";
    for (int i = 0; i < 6; ++i) {
        std::cout << "Value " << i + 1 << ": " << res[i] << endl;
    }
}


#define elements 5
void calc_formula_task1(){
    float  X = 0, res[elements], start = 3.0, step = 2.5;
    int A = 7, B = 20; 

    _asm{
        lea  EDI, res   
        mov  ECX, elements 
        finit;
    m1:
        fld     X               // SP(0) = X 
        fadd    start           // SP(0) = X + 3 (current value)
        fst     X               // store x
        fisub   A               // SP(0) = X - 7 
        fld     X               // SP(0) = X 
        fiadd   B               // X +20 
        fsqrt                   // SP(0) = (x + 20) ^ (1/2) 
        fdivp   ST(1), ST       // (x - 7) / [(x + 20) ^ (1/2)] 
        fstp    dword ptr[EDI]  // save to arr
        add     EDI, 4
        mov     eax, dword ptr[step]
        mov     dword ptr[start], eax

        loop  m1
    }

    std::cout << "task1: results: \n";
    for (int i = 0; i < 5; ++i){
        std::cout << "Value " << i + 1 << ": " << res[i] << endl;
    }
}


float calc_formula_acrsin(float number1, float number2) {

    float numb_3 = 3, numb_2 = 2, deg = 180, res = 0;
    _asm
    {
        finit
        fld     number1         // load number1
        fmul    ST(0), ST(0)    // number1^2
        fld     number2         // load number2
        fmul    ST(0), ST(0)    // number2^2
        FADD    ST(0), ST(1)    // add ST(0) = A^2 + B^2

        fld     numb_3          // load 3
        fdivp   ST(1), ST(0)    // ST(1) = (A^2 + B^2) / 3
        fld     ST(0)           // copy
        fmul    ST(0), ST(0)    // square
        fld1                    // load 1
        fsubrp  ST(1), ST(0)    // 1 - result
        fsqrt                   // root from the result
        fdiv    ST(1), ST(0)    // 1 / result
        fpatan                  // tang(res)
        fld     numb_2          // load 2
        fmulp   ST(1), ST(0)    // mul 2 by res
        fld     deg             // load 180 degrees
        fmulp   ST(1), ST(0)    //
        fldpi
        fdivp   ST(1), ST(0)    // convert to degrees
        fst     res             // save
    }
    return res;
}