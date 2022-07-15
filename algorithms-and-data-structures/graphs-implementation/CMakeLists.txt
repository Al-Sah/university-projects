cmake_minimum_required(VERSION 3.17)
project(graphs)

set(CMAKE_CXX_STANDARD 17)

add_executable(graphs main.cpp GraphsContainer.cpp GraphsContainer.h Graphs.cpp Graphs.h)