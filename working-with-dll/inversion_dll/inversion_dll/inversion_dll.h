
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


extern INVERSIONDLL_API void invert(void);

extern INVERSIONDLL_API enum inversion_type;