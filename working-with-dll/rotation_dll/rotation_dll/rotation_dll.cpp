// rotation_dll.cpp : Defines the exported functions for the DLL.

#include "pch.h"
#include "rotation_dll.h"


ROTATIONDLL_API void rotate(UINT16 rotation_angle) {

}

ROTATIONDLL_API void helloWorld(HWND hWnd) {
	MessageBox(hWnd, L"rotation dll", L"Hello World", MB_OK | MB_ICONINFORMATION);
}


