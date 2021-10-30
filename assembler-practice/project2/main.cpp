#include <iostream>
#include <chrono>


void print_arr(long *arr, size_t size) {
    for (size_t i = 0; i < size; i++){
        std::cout << "el: " << i << "; Value: " << arr[i] << std::endl;
    }
}

void fill_rand(long *arr, size_t size) {
    srand(time(nullptr));
    for (size_t i = 0; i < size; i++){
        arr[i] = rand()%100-50;
    }
}

#define ARR_ELEMENTS 8
#define TYPE_SIZE 4

int main()
{

    // subtask1:
    [[maybe_unused]] long X, Y;
    long	res[ARR_ELEMENTS];

    __asm{
        lea	EBX, res		    ; load array adres in register
        mov	ECX, ARR_ELEMENTS	; init counter
        mov X,  2

        m1:
        mov		EAX, 5			; EAX=5
        imul	X				; EAX = 5 * x
        imul	X				; EAX = 5 * x^2
        sub		EAX, 14			; EAX = 5 * x^2 - 14
        mov		EDI, EAX		; EAX to EDI

        mov		EAX, 2			; EAX = 2
        imul	X				; EAX = 2 * x
        add		EAX, EDI		; EAX = 5 * x ^ 2 - 14 + 2 * x

        mov		dword ptr[EBX], EAX	; mov res to array element
        add		EBX,TYPE_SIZE	; set ptr to the next element
        add		X,  4		    ; move to the next step
        loop	m1				; create a loop with a counter in ЕСХ
    }
    std::cout << "Subtask1 result:" << std::endl;
    print_arr(res, ARR_ELEMENTS);

    // subtask2
    __asm {
        mov X, 1
        m2 :
        dec	X
        mov		EAX, 8		; EAX = 8
        imul	X			; EAX = 8 * x
        imul	X			; EAX = 8 * x^2
        add		EAX, 25		; EAX = 8 * x^2 + 25
        mov		EDI, EAX	; EAX to EDI

        mov		EAX, 2000;
        add		EAX, X;

        cdq					; EAX => EDX:EAX
        idiv	EDI			; int part - EAX, remainder - EDX

        cmp		EAX, 10		;
        ja		m2			; Jump Above
        mov		Y,	EAX     ; save result
    }
    std::cout << "Subtask2 result:" << std::endl;
    std::cout << "First negative X: " << X << "; Y (as long): " << Y << std::endl;

    __asm {
        mov X, -1
        m4 :
        inc	X

        mov		EAX, 8		; EAX = 8
        imul	X			; EAX = 8 * x
        imul	X			; EAX = 8 * x^2
        add		EAX, 25		; EAX = 8 * x^2 + 25
        mov		EDI, EAX	; EAX to EDI

        mov		EAX, 2000;
        add		EAX, X;

        cdq					; EAX => EDX:EAX
        idiv	EDI			; int part - EAX, remainder - EDX

        cmp		EAX, 10		;
        ja		m4			; Jump Above
        mov		Y,	EAX     ; save result
    }
    std::cout << "First positive X: " << X << "; Y (as long): " << Y << std::endl;




    // subtask3:
    long arr[ARR_ELEMENTS];
    long elements = 0;
    fill_rand(arr, ARR_ELEMENTS);
    arr[ARR_ELEMENTS-1]= 0;

    std::cout << "Random array... "<< std::endl;
    print_arr(arr, ARR_ELEMENTS);

    _asm{
        mov     EAX, 0              ; elements counter
        lea	    EBX, arr	        ; load array adres in register
        mov 	ECX, ARR_ELEMENTS   ; init counter
        mov		EDX, 0              ; for the cmp

        m3 :
        mov		EDI, dword ptr[EBX]
        add		EBX, TYPE_SIZE  ; set ptr to the next element
        cmp		EDI, EDX        ; check array element

        jge		p
        inc		EAX             ; if negative => increment
        p:

        loop	m3              ; create a loop with a counter in ЕСХ
        mov elements, EAX;      ; save result
    }
    std::cout << "Subtask3 result: negative elements: " << elements << std::endl;

    return 0;
}