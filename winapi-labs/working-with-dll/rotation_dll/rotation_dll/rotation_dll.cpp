// rotation_dll.cpp : Defines the exported functions for the DLL.

#include "pch.h"
#include "rotation_dll.h"


ROTATIONDLL_API const int SET_DEFAULT((int)0x00000000);
ROTATIONDLL_API const int LEFT_90((int)0x00000001);
ROTATIONDLL_API const int RIGHT_90((int)0x00000010);

ROTATIONDLL_API void rotate(const int type, HDC hdc, POINT newPos) {
	XFORM xForm = { 0 };
    xForm.eDx = newPos.x;
    xForm.eDy = newPos.y;

    switch (type) {
    case SET_DEFAULT:
        xForm.eM11 = (FLOAT)1.0;
        xForm.eM22 = (FLOAT)1.0;
        break;
    case LEFT_90:
        xForm.eM12 = (FLOAT)-1.0;
        xForm.eM21 = (FLOAT)1.0;
        break;
    case RIGHT_90:
        xForm.eM12 = (FLOAT)1.0;
        xForm.eM21 = (FLOAT)-1.0;
        break;
    default:
        break;
    }
    SetGraphicsMode(hdc, GM_ADVANCED);
    SetWorldTransform(hdc, &xForm);
}

ROTATIONDLL_API void helloWorld(HWND hWnd) {
	MessageBox(hWnd, L"rotation dll", L"Hello World", MB_OK | MB_ICONINFORMATION);
}


