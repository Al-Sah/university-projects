
// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the ROTATIONDLL_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// ROTATIONDLL_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.

#ifdef INVERSIONDLL_EXPORTS
	#define INVERSIONDLL_API __declspec(dllexport)
#else
	#define INVERSIONDLL_API __declspec(dllimport)
#endif


extern "C" INVERSIONDLL_API const int SET_NORMAL;
extern "C" INVERSIONDLL_API const int VERTICAL;
extern "C" INVERSIONDLL_API const int HORIZONTAL;

// param "type" -> type of inversion. Must be: "VERTICAL", "HORIZONTAL" or "VERTICAL | HORIZONTAL"
// param "hdc" -> source HDC. Used for: "SetGraphicsMode" and "SetWorldTransform"
// (NULL-SAFETY) pointers PBITMAP and PPOINT are used for position correction.
// Have to be passed just one parameter (PBITMAP or PPOINT)
// Returns FALSE if both pointers != NULL or passed unsuported param "type"
extern "C" INVERSIONDLL_API BOOLEAN invert(const int type, HDC hdc, PBITMAP bitmap, PPOINT newPos);
