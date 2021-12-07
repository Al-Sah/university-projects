// client.cpp : Defines the entry point for the application.
//

#include "framework.h"
#include "client.h"

// Need to link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")
// #pragma comment (lib, "Mswsock.lib")


#define MAX_LOADSTRING 100
#define DEFAULT_BUFLEN 512
#define DEFAULT_SERVER_NAME "localhost"
#define DEFAULT_PORT "27015"

// Global Variables:
HANDLE socketThread;
HINSTANCE hInst;                                // current instance
WCHAR szTitle[MAX_LOADSTRING];                  // The title bar text
WCHAR szWindowClass[MAX_LOADSTRING];            // the main window class name
SOCKET ConnectSocket = INVALID_SOCKET;
std::wstring connectionState;
HWND redSlider, greenSlider, blueSlider;

// Forward declarations of functions included in this code module:
ATOM                MyRegisterClass(HINSTANCE hInstance);
BOOL                InitInstance(HINSTANCE, int);
LRESULT CALLBACK    WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK    About(HWND, UINT, WPARAM, LPARAM);


DWORD APIENTRY connectToServer(LPVOID info) {
	WSADATA wsaData;
	
	struct addrinfo* result = NULL, *ptr = NULL, hints;
	char recvbuf[DEFAULT_BUFLEN];
	int iResult;
	int recvbuflen = DEFAULT_BUFLEN;
	ZeroMemory(recvbuf, DEFAULT_BUFLEN);
    ZeroMemory(&hints, sizeof(hints));
    hints.ai_family = AF_UNSPEC;
    hints.ai_socktype = SOCK_STREAM;
    hints.ai_protocol = IPPROTO_TCP;

	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0) {
        std::wstring tmp = L"WSAStartup failed with error: " + iResult;
        MessageBox(NULL, tmp.c_str(), (LPCWSTR)L"WSAStartup failed", MB_ICONERROR | MB_OK);
		return 1;
	}

	// Resolve the server address and port
	iResult = getaddrinfo(DEFAULT_SERVER_NAME, DEFAULT_PORT, &hints, &result);
	if (iResult != 0) {
        std::wstring tmp = L"getaddrinfo failed with error: " + iResult;
        MessageBox(NULL, tmp.c_str(), (LPCWSTR)L"getaddrinfo failed", MB_ICONERROR | MB_OK);
		WSACleanup();
		return 1;
	}

	// Attempt to connect to an address until one succeeds
	for (ptr = result; ptr != NULL; ptr = ptr->ai_next) {

		// Create a SOCKET for connecting to server
		ConnectSocket = socket(ptr->ai_family, ptr->ai_socktype, ptr->ai_protocol);
		if (ConnectSocket == INVALID_SOCKET) {
            std::wstring tmp = L"socket failed with error: " + WSAGetLastError();
            MessageBox(NULL, tmp.c_str(), (LPCWSTR)L"socket failed", MB_ICONERROR | MB_OK);
			WSACleanup();
			return 1;
		}

		// Connect to server.
		iResult = connect(ConnectSocket, ptr->ai_addr, (int)ptr->ai_addrlen);
		if (iResult == SOCKET_ERROR) {
			closesocket(ConnectSocket);
			ConnectSocket = INVALID_SOCKET;
			continue;
		}
		break;
	}
    if (ConnectSocket == INVALID_SOCKET) {
        connectionState = L"Failed to connect";
        WSACleanup();
        return 1;
    }
    else {
        connectionState = L"Connected sucsesfully";
    }

	freeaddrinfo(result);
	return 0;
}

void shutdownSocket() {
    int iResult = shutdown(ConnectSocket, SD_SEND);
    if (iResult == SOCKET_ERROR) {
        closesocket(ConnectSocket);
        WSACleanup();
        return;
    }
    closesocket(ConnectSocket);
    WSACleanup();
}

void sendData(HWND hWnd, std::string data)
{
    if (ConnectSocket == INVALID_SOCKET) {
        MessageBox(hWnd, L"INVALID_SOCKET", (LPCWSTR)L"", MB_ICONERROR | MB_OK);
        return;
    }

    int res = send(ConnectSocket, data.c_str(), data.size(), 0);
    if (res == SOCKET_ERROR) {
        std::wstring tmp = L"SOCKET_ERROR: " + WSAGetLastError();
        MessageBox(hWnd, tmp.c_str(), (LPCWSTR)L"SOCKET_ERROR", MB_ICONERROR | MB_OK);
        closesocket(ConnectSocket);
        WSACleanup();
    }
}

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
    LoadStringW(hInstance, IDC_CLIENT, szWindowClass, MAX_LOADSTRING);
    MyRegisterClass(hInstance);

    // Perform application initialization:
    if (!InitInstance (hInstance, nCmdShow))
    {
        return FALSE;
    }

    socketThread = CreateThread(nullptr, 0, connectToServer, nullptr, 0, nullptr);
    if (socketThread == nullptr) {
        std::wstring tmp = L"socketThread failed with error: " + GetLastError();
        MessageBox(NULL, tmp.c_str(), (LPCWSTR)L"socketThread failed", MB_ICONERROR | MB_OK);
        return 1;
    }


    HACCEL hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_CLIENT));
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
    wcex.hIcon          = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_CLIENT));
    wcex.hCursor        = LoadCursor(nullptr, IDC_ARROW);
    wcex.hbrBackground  = (HBRUSH)(COLOR_WINDOW+1);
    wcex.lpszMenuName   = MAKEINTRESOURCEW(IDC_CLIENT);
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
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
    static TEXTMETRIC textmetric;
    switch (message)
    {
    case WM_CREATE:
        SetTimer(hWnd, NULL, 500, (TIMERPROC)NULL);
        //CreateWindow(L"slider", L"red slider", WS_CHILD | TRACKBAR_CLASS | WS_VISIBLE, 5, 5, 200, 100, hWnd, (HMENU)"ID_RED_SLIDER", NULL, NULL);
        //CreateWindowEX(0, TRACKBAR_CLASS, L"Trackbar Control", WS_CHILD | WS_VISIBLE | TBS_AUTOTICKS | TBS_ENABLESELRANGE,
        //    15, 5, 200, 100, hWnd, (HMENU)"ID_GREEN_SLIDER", NULL, NULL);
        //CreateWindow(L"slider", L"green slider", WS_CHILD | TRACKBAR_CLASS | WS_VISIBLE, 25, 5, 200, 100, hWnd, (HMENU)"ID_BLUE_SLIDER", NULL, NULL);
       // CreateWindow(L"button", L"BIG button!", WS_CHILD | BS_PUSHBUTTON | WS_VISIBLE, 5, 5, 200, 100, hWnd, (HMENU)"ID_MYBUTTON", NULL, NULL);

        redSlider = CreateWindowEx(
            0,                               // no extended styles 
            TRACKBAR_CLASS,                  // class name 
            L"Trackbar Control",              // title (caption) 
            WS_CHILD | WS_VISIBLE | TBS_AUTOTICKS |  TBS_ENABLESELRANGE,              // style 
            100, 60,                          // position 
            200, 30,                         // size 
            hWnd,                         // parent window 
            (HMENU)"ID_RED_SLIDER",                     // control identifier 
            NULL, NULL);

        blueSlider = CreateWindowEx(
            0,                               // no extended styles 
            TRACKBAR_CLASS,                  // class name 
            L"Trackbar Control",              // title (caption) 
            WS_CHILD | WS_VISIBLE | TBS_AUTOTICKS | TBS_ENABLESELRANGE,              // style 
            100, 100,                          // position 
            200, 30,                         // size 
            hWnd,                         // parent window 
            (HMENU)"ID_BLUE_SLIDER",                     // control identifier 
            NULL, NULL);

        greenSlider = CreateWindowEx(
            0,                               // no extended styles 
            TRACKBAR_CLASS,                  // class name 
            L"Trackbar Control",              // title (caption) 
            WS_CHILD | WS_VISIBLE | TBS_AUTOTICKS | TBS_ENABLESELRANGE,              // style 
            100, 140,                          // position 
            200, 30,                         // size 
            hWnd,                         // parent window 
            (HMENU)"ID_GREEN_SLIDER",                     // control identifier 
            NULL,NULL );

    case WM_TIMER:
        InvalidateRect(hWnd, nullptr, true);
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
        {
        PAINTSTRUCT ps;
        HDC hdc = BeginPaint(hWnd, &ps);

        GetTextMetrics(hdc, &textmetric);
        TextOut(hdc, 20, 20, connectionState.c_str(), connectionState.size());
        EndPaint(hWnd, &ps);
        }
        break;
    case WM_DESTROY:
        PostQuitMessage(0);
        break;
    case WM_NOTIFY:
    {
        LPNMHDR nmhdr = reinterpret_cast<LPNMHDR>(lParam);
        if ((nmhdr->code == TRBN_THUMBPOSCHANGING) &&
            (nmhdr->hwndFrom == redSlider))
        {
            NMTRBTHUMBPOSCHANGING* nmtrb = reinterpret_cast<NMTRBTHUMBPOSCHANGING*>(lParam);
            switch (nmtrb->nReason)
            {
            case TB_THUMBTRACK:
            case TB_PAGEUP:
            case TB_PAGEDOWN:
            case TB_THUMBPOSITION:
            case TB_TOP:
            case TB_BOTTOM:
            case TB_ENDTRACK:
                //MessageBox(nullptr, TEXT("Thumb Pos Changing"), TEXT("Info"), MB_OK);
                break;
            }
        }
        break;
    }

    case WM_HSCROLL:
    {
        if ((lParam != 0) &&
            (reinterpret_cast<HWND>(lParam) == redSlider))
        {
            switch (LOWORD(wParam))
            {
            case SB_ENDSCROLL:
            case SB_LEFT:
            case SB_RIGHT:
            case SB_LINELEFT:
            case SB_LINERIGHT:
            case SB_PAGELEFT:
            case SB_PAGERIGHT:
            case SB_THUMBPOSITION:
            case SB_THUMBTRACK:
                MessageBox(nullptr, TEXT("Horz Scroll"), TEXT("Info"), MB_OK);
                break;
            }
        }
        break;
    }
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
