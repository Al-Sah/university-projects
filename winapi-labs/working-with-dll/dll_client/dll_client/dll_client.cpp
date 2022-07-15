// dll_client.cpp : Defines the entry point for the application.

#include "framework.h"
#include "dll_client.h"
#include "rotation_dll.h"


#define MAX_LOADSTRING 100
#define DEBUG
#define LOADIOG_LIBRARY_PATH L"C:\\Users\\Al_Sah\\source\\winapi-labs\\working-with-dll\\inversion_dll\\Debug\\inversiondll.dll"

HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

//typedef BOOLEAN (CALLBACK*DLL_INVERT)(const int, HDC, PBITMAP, PPOINT);
using DLL_INVERT = BOOLEAN(*)(const int, HDC, PBITMAP, PPOINT);
DLL_INVERT dllInvert;
INT HORIZONTAL_INVERSION;
INT VERTICAL_INVERSION;
INT SET_NORMAL;

int APIENTRY wWinMain(_In_ HINSTANCE hInstance, _In_opt_ HINSTANCE hPrevInstance, _In_ LPWSTR lpCmdLine, _In_ int nCmdShow){
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_DLLCLIENT, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    HINSTANCE hDLL;
    hDLL = LoadLibrary(LOADIOG_LIBRARY_PATH);
    
    WCHAR errorCode[5];
    swprintf_s(errorCode, 5, L"%d", GetLastError());
    if (hDLL == NULL) {
        MessageBox(NULL, (LPCWSTR)errorCode, L"Failed to load dll", MB_OK);
        return 0;
    }
    else {
        dllInvert = (DLL_INVERT)GetProcAddress(hDLL, "invert");
        if (dllInvert == NULL) {
            MessageBox(NULL, L"Function invert", L"Loading failed", MB_OK);
            return 0;
        }
        
        INT *pHI = (INT*)GetProcAddress(hDLL, "HORIZONTAL");
        if (pHI == NULL) {
            MessageBox(NULL, L"Variable HORIZONTAL", L"Loading failed", MB_OK);
            return 0;
        }else {
            HORIZONTAL_INVERSION = *pHI;
        }

        INT* pVI = (INT*)GetProcAddress(hDLL, "VERTICAL");
        if (pVI == NULL) {
            MessageBox(NULL, L"Variable HORIZONTAL", L"Loading failed", MB_OK);
            return 0;
        }
        else {
            VERTICAL_INVERSION = *pVI;
        }

        INT* pNoI = (INT*)GetProcAddress(hDLL, "SET_NORMAL");
        if (pNoI == NULL) {
            MessageBox(NULL, L"Variable SET_NORMAL", L"Loading failed", MB_OK);
            return 0;
        }
        else {
            SET_NORMAL = *pNoI;
        }
        //MessageBox(NULL, L"inversion_dll", L"DLL loaded", MB_OK);
    }

    // Perform application initialization:
    if (!InitInstance(hInstance, nCmdShow)) {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_DLLCLIENT));
    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0)){
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg)){
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    if (hDLL != NULL) {
        FreeLibrary(hDLL);
    }
    return (int) msg.wParam;
}


ATOM MyRegisterClass(HINSTANCE hInstance){
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);
    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_DLLCLIENT));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_DLLCLIENT);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

BOOL InitInstance(HINSTANCE hInstance, int nCmdShow){
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   if (!hWnd){
      return FALSE;
   }
   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);
   return TRUE;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam){

    static BITMAP bm;
    static HBITMAP hBitmap;
    static HDC hdc, hmdc;
    static PAINTSTRUCT ps;
    static RECT rect;
    static POINT center;
    static XFORM xForm; 
    static std::function<void()> action;

    switch (message){

    case WM_CREATE:
        //hBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BITMAP1)); // загрузка картинки 
        hBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BITMAP1));
        //helloWorld(hWnd);
        hdc = GetDC(hWnd);
        hmdc = CreateCompatibleDC(hdc);
        SelectObject(hmdc, hBitmap);
        GetObject(hBitmap, sizeof(bm), &bm);
        

        GetClientRect(hWnd, (LPRECT)&rect); // Определение центра HDC
        
        center.x = rect.right / 2;
        center.y = rect.bottom / 2;
        action = []() {
            dllInvert(SET_NORMAL, hdc, NULL, &center);
        };
        
        /*xForm.eM11 = (FLOAT)1.0;
        xForm.eM22 = (FLOAT)1.0;*/
       /* SetGraphicsMode(hdc, GM_ADVANCED);
        SetGraphicsMode(hmdc, GM_ADVANCED);
        SetWorldTransform(hmdc, &xForm);*/
        ReleaseDC(hWnd, hdc);
        break;

    case WM_SIZE:
    case WM_MOVE:
        GetClientRect(hWnd, (LPRECT)&rect);
        center.x = rect.right / 2;
        center.y = rect.bottom / 2;
        break;

    case WM_COMMAND:
        switch (LOWORD(wParam)) {

        case IDM_ABOUT:
            DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
            break;
        case IDM_EXIT:
            DestroyWindow(hWnd);
            break;

        case ID_ROTATION_LEFT90:
            action = []() {
                rotate(LEFT_90, hdc, center);
            };
            InvalidateRect(hWnd, NULL, TRUE);
            break;
        case ID_ROTATION_RIGHT90:
            action = []() {
                rotate(RIGHT_90, hdc, center);
            };
            InvalidateRect(hWnd, NULL, TRUE);
            break;
        case ID_ROTATION_SETNORMAL:
            action = []() {
                rotate(SET_DEFAULT, hdc, center);
            };
            rotate(SET_DEFAULT, hdc, center);
            InvalidateRect(hWnd, NULL, TRUE);
            break;

        case ID_INVERSION_HORIZONTAL:
            action = []() {
                dllInvert(HORIZONTAL_INVERSION, hdc, NULL, &center);
            };
            InvalidateRect(hWnd, NULL, TRUE);
            break;
        case ID_INVERSION_VERTICAL:
            action = []() {
                dllInvert(VERTICAL_INVERSION, hdc, NULL, &center);
            };
            InvalidateRect(hWnd, NULL, TRUE);
            break;
        case ID_INVERSION_BOTH:
            action = []() {
                dllInvert(VERTICAL_INVERSION | HORIZONTAL_INVERSION, hdc, NULL, &center);
            };
            //dllInvert(VERTICAL_INVERSION | HORIZONTAL_INVERSION, hmdc, &bm, NULL);
            //dllInvert(VERTICAL_INVERSION | HORIZONTAL_INVERSION, hdc, NULL, &center);
            InvalidateRect(hWnd, NULL, TRUE);
            break;
        case ID_INVERSION_SETNORMAL:
            action = []() {
                dllInvert(SET_NORMAL, hdc, NULL, &center);
            };
            InvalidateRect(hWnd, NULL, TRUE);
            break;
        default:
            return DefWindowProc(hWnd, message, wParam, lParam);
        }
        break;
    case WM_PAINT:
        hdc = BeginPaint(hWnd, &ps);

        action();
        BitBlt(hdc, -bm.bmWidth / 2, -bm.bmHeight / 2, bm.bmWidth, bm.bmHeight, hmdc, 0, 0, SRCCOPY);

        EndPaint(hWnd, &ps);
        break;

    case WM_DESTROY:

        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hWnd, message, wParam, lParam);
    }
    return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
    UNREFERENCED_PARAMETER(lParam);
    switch (message)
    {
    case WM_INITDIALOG:
        return (INT_PTR)TRUE;

    case WM_COMMAND:
        if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
        {
            EndDialog(hDlg, LOWORD(wParam));
            return (INT_PTR)TRUE;
        }
        break;
    }
    return (INT_PTR)FALSE;
}

