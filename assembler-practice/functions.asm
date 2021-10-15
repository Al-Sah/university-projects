global fillArray32bit, decimal2binary32bit, decimal2binary64bit, getRegistersState64bit, getRegistersState32bit, decimal2binary, findMinAndMax, findMin, findMax, calcAverage, sortArray
section .text

decimal2binary32bit:
    mov  rcx, 0         ; set iterator to 0
    mov  rbx, rsi       ; array element pointer (start)
    mov  edx, 1         ; first bit
    shl  edx, 31        ; set mask

    .L32bit:
    mov eax, edx        ; mov mask to the accumulator
    and eax, edi        ; masking (rax contains just 1 non-zero bit) Eg: 0010000
    jz .AddZero32bit    ; jump if zero
    mov  [rbx], byte 1  ; fill array element
    jmp .updateRegisters32bit; non-condition jump

    .AddZero32bit:
    mov [rbx], byte 0   ; fill array element

    .updateRegisters32bit:
    add  rbx, 1         ; перемещаем указатель на следующий элемент (4 - размер)
    shr  edx, 1         ; mask update
    inc  ecx            ; increment counter

    cmp  ecx, 32        ; comparison counter with array size (32)
    jne   .L32bit       ; jump if not equal

    mov  rax, rcx       ; generate return value
    ret

decimal2binary64bit:
    mov  rcx, 0         ; set iterator to 0
    mov  rbx, rsi       ; array element pointer (start)
    mov  rdx, 1
    shl  rdx, 63        ; set mask

    .L64bit:
    mov rax, rdx        ; mov mask to the accumulator
    and rax, rdi        ; masking (rax contains just 1 non-zero bit) Eg: 0010000
    jz .AddZero64bit    ; ump if zero
    mov  [rbx], byte 1  ; fill array element
    jmp .updateRegisters64bit; non-condition jump

    .AddZero64bit:
    mov [rbx], byte 0   ; fill array element

    .updateRegisters64bit:
    add  rbx, 1         ; mov pointer to the next element
    shr  rdx, 1         ; mask update
    inc  rcx            ; increment counter

    cmp  rcx, 64
    jne   .L64bit       ; jump if not equal

    mov  rax, rcx       ; generate return value
    ret


getRegistersState64bit: ; rdi - contains struct GeneralRegisters64bit pointer
    mov  [rdi],      rax
    mov  [rdi+8],    rdx
    mov  [rdi+16],   rbx
    mov  [rdi+24],   rcx
    mov  [rdi+32],   rsi
    mov  [rdi+40],   rdi
    mov  [rdi+48],   rsp
    mov  [rdi+56],   rbp
    ret

getRegistersState32bit: ; rdi - contains struct GeneralRegisters32bit pointer
    mov  [rdi],      eax
    mov  [rdi+4],    edx
    mov  [rdi+8],    ebx
    mov  [rdi+12],   ecx
    mov  [rdi+16],   esi
    mov  [rdi+20],   edi
    mov  [rdi+24],   esp
    mov  [rdi+28],   ebp
    ret



fillArray32bit: ; edi contains array pointer  (test function)
    mov  rcx, 31        ; array iterator
    mov  rbx, rdi       ; array element pointer (start)

    .WhileNot0:
    mov  [rbx], rcx     ; fill array element
    add  rbx, 4         ; mov pointer to the next element
    dec  rcx            ; decrement counter
    jnz  .WhileNot0     ; jmp: non-condition jump

    mov rax, rcx        ; generate return value
    ret


decimal2binary:; rsi - array pointer
    mov  rcx, 0         ; set iterator
    mov  rbx, rsi       ; mov array element pointer (start) to base reg
    mov  edx, 2147483648; first bit

    .L1:
    mov eax, edx
    and eax, edi        ; masking (edx contains just 1 non-zero bit) Eg: 0010000
    jz .AddZero         ; jump if zero (check masking result)
    mov  [rbx], word 1  ; fill array element
    jmp .updateRegisters; jmp: non-condition jump

    .AddZero:
    mov [rbx], word 0   ; fill array element

    .updateRegisters:
    add  rbx, 4         ; mov pointer to the next element
    shr  edx, 1         ; mask update
    inc  ecx            ; increment counter

    cmp  ecx, 32
    jne   .L1           ; jump if not equal

    mov  rax, rcx       ; generate return value
    ret

findMinAndMax:; rdi - contains array size    rsi - contains array pointer
                ; rdx - contains struct MinMax pointer  FIXME

    mov rcx,    0
    mov rbx,    rsi     ; get first element pointer
    mov [rdx],  rbx     ; set first element as a min (MinMax.min)
    mov [rdx+4], rbx    ; set first element as a max (MinMax.max)

    .for:
    mov  rax, [rbx]     ; mov array element to accumulator
    cmp  [rdx], rax     ; comparison MinMax.min and array element
    jg   .setNewMin     ; jump if greater
    jmp  .toNext

    .checkMax:
    cmp  [rdx+4], rax   ; comparison MinMax.max and array element
    jl   .setNewMax     ; jump if less
    jmp  .toNext

    .setNewMin:
    mov [rdx],  rax     ; set MinMax.max
    jmp .checkMax

    .setNewMax:
    mov [rdx+4],  rax   ; set MinMax.max

    .toNext:
    inc  rcx            ; increment counter
    add  rbx,  4        ; mov array element to accumulator
    cmp  rcx, rdi       ; comparison counter with array size
    jne   .for          ; jump if not equal
    ret

findMin:  ; edi - contains array size   rsi - contains array pointer
    mov ecx,  0
    mov rbx,  rsi       ; get first element pointer
    mov edx,  [rsi]     ; get first element

    .for:
    mov  eax, [rbx]     ; mov array element to accumulator
    cmp  edx, eax       ; comparison stored value with array element
    jg   .setNewMin     ; jump if greater
    jmp  .toNext

    .setNewMin:
    mov edx,  eax

    .toNext:
    inc  rcx            ; increment counter
    add  rbx,  4        ; mov pointer to the next element
    cmp  ecx, edi       ; comparison counter with array size
    jne  .for           ; jump if not equal
    mov eax, edx        ; generate return value
    ret

findMax: ; edi - contains array size   rsi - contains array pointer
    mov ecx,  0
    mov rbx,  rsi       ; get first element pointer
    mov edx,  [rsi]     ; get first element (result will be stored at edx)

    .for:
    mov  eax, [rbx]     ; mov array element to accumulator
    cmp  edx, eax       ; comparison stored value with array element
    jl   .setNewMax     ; jump if less
    jmp  .toNext

    .setNewMax:
    mov edx,  eax

    .toNext:
    inc  rcx            ; increment counter
    add  rbx,  4        ; mov pointer to the next element
    cmp  ecx, edi       ; comparison counter with array size
    jne   .for          ; jump if not equal
    mov eax, edx        ; generate return value
    ret


calcAverage: ; edi - contains array size   rsi - contains array pointer
    mov ecx,  0
    mov rax,  0
    mov rbx,  rsi       ; get first element pointer
    mov edx,  [rsi]     ; get first element

    .for:
    add  rax, [rbx]
    inc  rcx            ; increment counter
    add  rbx,  4        ; mov pointer to the next element
    cmp  ecx, edi       ; comparison counter with array size
    jne   .for          ; jump if not equal

    mov rdx, rax
    shl rdx, 32         ; moving most significant bits to least significant bit (32)
    idiv edi
    ret

sortArray: ; edi - array size   rsi - array pointer  rdx - compare function pointer
    mov ecx, 0          ; init counter
    mov ebx, edi        ; save array size in base register
    add rsi,  4         ; mov pointer to the next element
    .for:
    mov ebx, edi        ; save array size in base register
    sub ebx, ecx
    dec ebx             ; init inner counter max value (array size - main counter - 1)
    push rcx            ; save main counter
    push rsi            ; save array pointer
    mov ecx, 0          ; init inner counter

    .inner_for:
    .call_compare_func:
    push rdi            ; rdi saving
    push rsi            ; rsi saving
    mov edi, [rsi-4]    ; passing first param
    mov esi, [rsi]      ; passing second param
    call rdx            ; call comparison function
    pop rsi             ; rsi recovery
    pop rdi             ; rdi recovery

    cmp eax, 0          ; handle comparison function result
    je .inner_for_next_step; jump if not equal

    .swap:
    mov eax, [rsi-4]
    push rax
    mov eax, [rsi]
    mov [rsi-4], eax
    pop rax
    mov [rsi], eax

    .inner_for_next_step:
    inc  ecx            ; increment inner counter
    add  rsi,  4        ; mov pointer to the next element
    cmp  ecx, ebx       ; comparison counter with max value
    jne  .inner_for     ; jump if not equal

    pop  rsi            ; rsi recovery
    pop  rcx            ; main counter recovery
    inc  ecx            ; increment counter
    mov  eax, edi       ; comparison counter with array size
    dec  eax
    cmp  ecx, eax       ; comparison counter with (array size -1 )
    jne  .for           ; jump if not equal
    ret