// SystemProg_laba7_dll_client.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "SystemProg_laba7_dll_client.h"

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name

//HWND hWnd;
//MSG lpMsg;
//WNDCLASS w;
//HBITMAP hBitmap;

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY wWinMain(_In_ HINSTANCE hInstance,
                     _In_opt_ HINSTANCE hPrevInstance,
                     _In_ LPWSTR    lpCmdLine,
                     _In_ int       nCmdShow)
{
    UNREFERENCED_PARAMETER(hPrevInstance);
    UNREFERENCED_PARAMETER(lpCmdLine);

    // TODO: Place code here.

    // Initialize global strings
    LoadStringW(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
    LoadStringW(hInstance, IDC_SYSTEMPROGLABA7DLLCLIENT, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_SYSTEMPROGLABA7DLLCLIENT));

    MSG msg;

    // Main message loop:
    while (GetMessage(&msg, nullptr, 0, 0))
    {
        if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }
    }

    return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
    WNDCLASSEXW wcex;

    wcex.cbSize = sizeof(WNDCLASSEX);

    wcex.style          = CS_HREDRAW | CS_VREDRAW;
    wcex.lpfnWndProc    = WndProc;
    wcex.cbClsExtra     = 0;
    wcex.cbWndExtra     = 0;
    wcex.hInstance      = hInstance;
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_SYSTEMPROGLABA7DLLCLIENT));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_SYSTEMPROGLABA7DLLCLIENT);
    wcex.lpszClassName  = szWindowClass;
    wcex.hIconSm        = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

    return RegisterClassExW(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//
BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   hInst = hInstance; // Store instance handle in our global variable

   HWND hWnd = CreateWindowW(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, nullptr, nullptr, hInstance, nullptr);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);

   return TRUE;
}

void rotateImage(HDC & bitmap, int angle) {
    
    XFORM xForm;
    xForm.eDx = 0;
    xForm.eDy = 0;
    xForm.eM11 = (float)cos(angle);
    xForm.eM21 = (float)(sin(angle));
    xForm.eM12 = (float)-sin(angle);
    xForm.eM22 = (float)(cos(angle));

    SetWorldTransform(bitmap, &xForm);

}

void TransformAndDraw(int iTransform, HWND hWnd){

    BITMAP bm;
    HDC hDC, hmdc;
    XFORM xForm;
    RECT rect;

    // Retrieve a DC handle for the application's window.  

    hDC = GetDC(hWnd);
    

    // Set the mapping mode to LOENGLISH. This moves the  
    // client area origin from the upper left corner of the  
    // window to the lower left corner (this also reorients  
    // the y-axis so that drawing operations occur in a true  
    // Cartesian space). It guarantees portability so that  
    // the object drawn retains its dimensions on any display.  

    SetGraphicsMode(hDC, GM_ADVANCED);
    SetMapMode(hDC, MM_LOENGLISH);


    // Set the appropriate world transformation (based on the  
    // user's menu selection).  

    switch (iTransform)
    {
    case 1:        // Scale to 1/2 of the original size.  
        xForm.eM11 = (FLOAT)0.5;
        xForm.eM12 = (FLOAT)0.0;
        xForm.eM21 = (FLOAT)0.0;
        xForm.eM22 = (FLOAT)0.5;
        xForm.eDx = (FLOAT)0.0;
        xForm.eDy = (FLOAT)0.0;
        SetWorldTransform(hDC, &xForm);
        break;

    case 2:   // Translate right by 3/4 inch.  
        xForm.eM11 = (FLOAT)1.0;
        xForm.eM12 = (FLOAT)0.0;
        xForm.eM21 = (FLOAT)0.0;
        xForm.eM22 = (FLOAT)1.0;
        xForm.eDx = (FLOAT)75.0;
        xForm.eDy = (FLOAT)0.0;
        SetWorldTransform(hDC, &xForm);
        break;

    case 3:      // Rotate 30 degrees counterclockwise.  
        xForm.eM11 = (FLOAT)0.8660;
        xForm.eM12 = (FLOAT)0.5000;
        xForm.eM21 = (FLOAT)-0.5000;
        xForm.eM22 = (FLOAT)0.8660;
        xForm.eDx = (FLOAT)0.0;
        xForm.eDy = (FLOAT)0.0;
        SetWorldTransform(hDC, &xForm);
        //SetWorldTransform(hmdc, &xForm);
        break;

    case 4:       // Shear along the x-axis with a  
                      // proportionality constant of 1.0.  
        xForm.eM11 = (FLOAT)1.0;
        xForm.eM12 = (FLOAT)1.0;
        xForm.eM21 = (FLOAT)0.0;
        xForm.eM22 = (FLOAT)1.0;
        xForm.eDx = (FLOAT)0.0;
        xForm.eDy = (FLOAT)0.0;
        SetWorldTransform(hDC, &xForm);
        break;

    case 5:     // Reflect about a horizontal axis.  
        xForm.eM11 = (FLOAT)1.0;
        xForm.eM12 = (FLOAT)0.0;
        xForm.eM21 = (FLOAT)0.0;
        xForm.eM22 = (FLOAT)-1.0;
        xForm.eDx = (FLOAT)0.0;
        xForm.eDy = (FLOAT)0.0;
        SetWorldTransform(hDC, &xForm);
        break;

    case 6:      // Set the unity transformation.  
        xForm.eM11 = (FLOAT)1.0;
        xForm.eM12 = (FLOAT)0.0;
        xForm.eM21 = (FLOAT)0.0;
        xForm.eM22 = (FLOAT)1.0;
        xForm.eDx = (FLOAT)0.0;
        xForm.eDy = (FLOAT)0.0;
        SetWorldTransform(hDC, &xForm);
        break;

    }

    // Find the midpoint of the client area.  

    GetClientRect(hWnd, (LPRECT)&rect);
    DPtoLP(hDC, (LPPOINT)&rect, 2);

    // Select a hollow brush.  

    SelectObject(hDC, GetStockObject(HOLLOW_BRUSH));

    // Draw the exterior circle.  
   


    Ellipse(hDC, (rect.right / 2 - 100), (rect.bottom / 2 + 100),
        (rect.right / 2 + 100), (rect.bottom / 2 - 100));

    // Draw the interior circle.  

    Ellipse(hDC, (rect.right / 2 - 94), (rect.bottom / 2 + 94),
        (rect.right / 2 + 94), (rect.bottom / 2 - 94));

    // Draw the key.  

    Rectangle(hDC, (rect.right / 2 - 13), (rect.bottom / 2 + 113),
        (rect.right / 2 + 13), (rect.bottom / 2 + 50));
    Rectangle(hDC, (rect.right / 2 - 13), (rect.bottom / 2 + 96),
        (rect.right / 2 + 13), (rect.bottom / 2 + 50));

    // Draw the horizontal lines.  

    MoveToEx(hDC, (rect.right / 2 - 150), (rect.bottom / 2 + 0), NULL);
    LineTo(hDC, (rect.right / 2 - 16), (rect.bottom / 2 + 0));

    MoveToEx(hDC, (rect.right / 2 - 13), (rect.bottom / 2 + 0), NULL);
    LineTo(hDC, (rect.right / 2 + 13), (rect.bottom / 2 + 0));

    MoveToEx(hDC, (rect.right / 2 + 16), (rect.bottom / 2 + 0), NULL);
    LineTo(hDC, (rect.right / 2 + 150), (rect.bottom / 2 + 0));

    // Draw the vertical lines.  

    MoveToEx(hDC, (rect.right / 2 + 0), (rect.bottom / 2 - 150), NULL);
    LineTo(hDC, (rect.right / 2 + 0), (rect.bottom / 2 - 16));

    MoveToEx(hDC, (rect.right / 2 + 0), (rect.bottom / 2 - 13), NULL);
    LineTo(hDC, (rect.right / 2 + 0), (rect.bottom / 2 + 13));

    MoveToEx(hDC, (rect.right / 2 + 0), (rect.bottom / 2 + 16), NULL);
    LineTo(hDC, (rect.right / 2 + 0), (rect.bottom / 2 + 150));

    
   
    ReleaseDC(hWnd, hDC);
    
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE: Processes messages for the main window.
//
//  WM_COMMAND  - process the application menu
//  WM_PAINT    - Paint the main window
//  WM_DESTROY  - post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam){

    static BITMAP bm;
    static HDC hdc, hmdc;
    static PAINTSTRUCT ps;
    static HBITMAP hBitmap;
    static XFORM xForm;

    switch (message)
    {
    case WM_CREATE:
        ///LoadBitmap(hInst, L"bitmap1");
        hBitmap = LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(IDB_BITMAP1));


        //xForm.eM11 = (FLOAT)0.8660;
        //xForm.eM12 = (FLOAT)0.5000;
        //xForm.eM21 = (FLOAT)-0.5000;
        //xForm.eM22 = (FLOAT)0.8660;

        //xForm.eM11 = (FLOAT)0.0000;
        //xForm.eM12 = (FLOAT)1.0000;
        //xForm.eM21 = (FLOAT)-1.0000;
        //xForm.eM22 = (FLOAT)0.0000;

        xForm.eM11 = (FLOAT)1.0;
        xForm.eM12 = (FLOAT)0.0;
        xForm.eM21 = (FLOAT)0.0;
        xForm.eM22 = (FLOAT)-1.0;


        //xForm.eM11 = cos(90);
        //xForm.eM12 = sin(90);
        //xForm.eM21 = -sin(90);
        //xForm.eM22 = cos(90);
        xForm.eDx = (FLOAT)0.0;
        xForm.eDy = (FLOAT)0.0;

       /* xForm.eM21 = (float)(sin(txtRotate) - tan(txtOblique) * cos(txtRotate));
        xForm.eM12 = (float)-sin(txtRotate);
        xForm.eM22 = (float)(cos(txtRotate) + tan(txtOblique) * sin(txtRotate));*/

        
        hdc = GetDC(hWnd);

        hmdc = CreateCompatibleDC(hdc);
        SelectObject(hmdc, hBitmap);
        GetObject(hBitmap, sizeof(bm), &bm);
        ReleaseDC(hWnd, hdc);

        break;

    case WM_COMMAND:
        {
            int wmId = LOWORD(wParam);
            // Parse the menu selections:
            switch (wmId)
            {
            case IDM_ABOUT:
                DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
                break;
            case IDM_EXIT:
                DestroyWindow(hWnd);
                break;
            default:
                return DefWindowProc(hWnd, message, wParam, lParam);
            }
        }
        break;
    case WM_PAINT:
        hdc = BeginPaint(hWnd, &ps);

        SetGraphicsMode(hdc, GM_ADVANCED);

        SetWorldTransform(hdc, &xForm);

        BitBlt(hdc, 100, -100, bm.bmWidth, bm.bmHeight, hmdc, 0, 0, SRCCOPY);

        EndPaint(hWnd, &ps);

        break;


        //hmdc = CreateCompatibleDC(hdc); //Создаёт совместимый с оконным контекст памяти
        //SetWorldTransform(hdc, &xForm);
        //SetWorldTransform(hmdc, &xForm);
        //hmdc = CreateCompatibleDC(hDC); //Создаёт совместимый с оконным контекст памяти
        // SelectObject(hmdc, hBitmap);
         //GetObject(hBitmap, sizeof(bm), (LPSTR)&bm); //получаем высоту и ширину картинки
         //BitBlt(hdc, 10, 10, bm.bmWidth, bm.bmHeight, hmdc, 0, 0, SRCCOPY); //Помещает картинку на экран в точку 10, 10
         //DeleteDC(hmdc);

        //hmdc = CreateCompatibleDC(hdc); //Создаёт совместимый с оконным контекст памяти
        //SelectObject(hmdc, hBitmap); //Выбирает объект картинку
        //GetObject(hBitmap, sizeof(bm), (LPSTR)&bm); //получаем высоту и ширину картинки
        //BitBlt(hdc, 10, 10, bm.bmWidth, bm.bmHeight, hmdc, 0, 0, SRCCOPY); //Помещает картинку на экран в точку 10, 10 из памяти (hmdc)
        //DeleteDC(hmdc);

        //удаляем из памяти контекст
        //TODO: Add any drawing code that uses hdc here...


        //TransformAndDraw(3, hWnd, hBitmap);

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






















/*

LRESULT CALLBACK WindowProcedure(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{

    static HBITMAP hBitmap;
    static BITMAP bm;
    static HDC memBit;
    HDC hdc;
    PAINTSTRUCT ps;

    static XFORM xf;
    static double angle = 0;
    static int x, y, cx, cy;

    switch (message)
    {

    case WM_CREATE:

        SetClassLong(hwnd, GCL_HBRBACKGROUND, (LONG)CreateSolidBrush(RGB(0, 0, 0)));

        hBitmap = (HBITMAP)LoadImage(NULL, L"1.bmp", IMAGE_BITMAP, 0, 0, LR_LOADFROMFILE | LR_CREATEDIBSECTION);

        GetObject(hBitmap, sizeof(bm), &bm);
        hdc = GetDC(hwnd);

        memBit = CreateCompatibleDC(hdc);
        SelectObject(memBit, hBitmap);
        ReleaseDC(hwnd, hdc);

        break;

    case WM_SIZE:

        cx = LOWORD(lParam) / 2;
        cy = HIWORD(lParam) / 2;
        xf.eDx = cx;
        xf.eDy = cy;
        x = -bm.bmWidth / 2;
        y = -bm.bmHeight / 2;

        InvalidateRect(hwnd, NULL, TRUE);

        break;

    case WM_KEYDOWN:

        if (GetAsyncKeyState(VK_LEFT))
        {
            angle += 3.14 * 10.0 / 180.0;
            InvalidateRect(hwnd, NULL, FALSE);

        }

        if (GetAsyncKeyState(VK_RIGHT))
        {
            angle -= 3.14 * 10.0 / 180.0;
            InvalidateRect(hwnd, NULL, FALSE);

        }

        break;


    case WM_PAINT:

        xf.eM22 = xf.eM11 = cos(angle);
        xf.eM12 = -(xf.eM21 = sin(angle));

        hdc = BeginPaint(hwnd, &ps);

        SetGraphicsMode(hdc, GM_ADVANCED);
        SetWorldTransform(hdc, &xf);

        BitBlt(hdc, x, y, bm.bmWidth, bm.bmHeight, memBit, 0, 0, SRCCOPY);

        EndPaint(hwnd, &ps);

        break;

    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    default:
        return DefWindowProc(hwnd, message, wParam, lParam);
    }

    return 0;
}
*/