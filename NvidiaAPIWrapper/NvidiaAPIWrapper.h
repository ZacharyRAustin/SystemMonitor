#pragma once
#include <Windows.h>

class NvidiaAPIWrapper {
public:
	NvidiaAPIWrapper();
	DWORD getGPUTemp();
	int init();
};