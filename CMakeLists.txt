cmake_minimum_required(VERSION 3.19)
project(asm_laba1)

enable_language(ASM_NASM)
set(CMAKE_ASM_NASM_OBJECT_FORMAT elf64)
set(CMAKE_ASM_NASM_LINK_EXECUTABLE "ld <CMAKE_ASM_NASM_LINK_FLAGS> <LINK_FLAGS> <OBJECTS> -o <TARGET> <LINK_LIBRARIES>")
set(CMAKE_ASM_NASM_FLAGS "${ASM_NASM_FLAGS} -g -Fdwarf")

set(CMAKE_CXX_STANDARD 20)


add_executable(asm_laba1 functions.asm main.cpp)



#[[
add_custom_target(s_asm_laba1 main.cpp)
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -S")
set_target_properties(s_asm_laba1 PROPERTIES CMAKE_CXX_FLAGS)]]
