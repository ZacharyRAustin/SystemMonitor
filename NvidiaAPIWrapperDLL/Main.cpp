#pragma once

#include "Definitions.h"
#include "NvidiaAPIWrapper.h"
#include "NvidiaAPIWrapper.cpp"
#include <Windows.h>
#include <stdio.h>
using namespace std;

NvidiaAPIWrapper* wrapper = new NvidiaAPIWrapper();

extern "C" __declspec(dllexport) DWORD getGPUTemp() {
	
	int initCheck = wrapper->init();

	if (initCheck != NVIDIA_API_INIT_SUCCESS && initCheck != NVIDIA_API_ALREADY_INITIALIZED) {
		return initCheck;
	}
	else {
		int temp = wrapper->getGPUTemp();
		return temp;
	}

}

extern "C" __declspec(dllexport) void freeWrapper() {
	free(wrapper);
}