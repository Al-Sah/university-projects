// inversion_dll.cpp : Defines the exported functions for the DLL.

#include "pch.h"
#include "inversion_dll.h"

INVERSIONDLL_API const int SET_NORMAL((int)0x00000000);
INVERSIONDLL_API const int VERTICAL((int)0x00000001);
INVERSIONDLL_API const int HORIZONTAL((int)0x00000010);

INVERSIONDLL_API BOOLEAN invert(const int type, HDC hdc, PBITMAP bitmap, PPOINT newPos) {

    XFORM xForm = { 0 };
    if (newPos != NULL && bitmap != NULL) return FALSE;
    if (newPos != NULL) {
        xForm.eDx = newPos->x;
        xForm.eDy = newPos->y;
    }
    switch (type) {
    case SET_NORMAL: 
        xForm.eM11 = (FLOAT)1.0;
        xForm.eM22 = (FLOAT)1.0;
        break;
    case VERTICAL:
        xForm.eM11 = (FLOAT)-1.0;
        xForm.eM22 = (FLOAT)1.0;
        if (bitmap != NULL) {
            xForm.eDx = bitmap->bmWidth - 1;
        }
        break;
    case HORIZONTAL:
        xForm.eM11 = (FLOAT)1.0;
        xForm.eM22 = (FLOAT)-1.0;
        if (bitmap != NULL) {
            xForm.eDy = bitmap->bmHeight - 1;
        }
        break;
    case VERTICAL | HORIZONTAL:
        xForm.eM11 = (FLOAT)-1.0;
        xForm.eM22 = (FLOAT)-1.0;
        if (bitmap != NULL) {
            xForm.eDx = bitmap->bmWidth - 1;
            xForm.eDy = bitmap->bmHeight - 1;
        }
        break;
    default:
        return FALSE;
    }
    SetGraphicsMode(hdc, GM_ADVANCED);
    SetWorldTransform(hdc, &xForm);
    return TRUE;
}
