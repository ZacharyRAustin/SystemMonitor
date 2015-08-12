#pragma once
#include <stdio.h>
#include "NvidiaAPIWrapper.h"
#include "nvapi.h" //going to have to get this and set up your environment correctly
#include "Definitions.h"
using namespace std;

void main() {
	NvidiaAPIWrapper* wrapper = new NvidiaAPIWrapper();

	//try to init the nvapi
	if (wrapper->init() != NVIDIA_API_INIT_FAILED) {
		DWORD temp = wrapper->getGPUTemp();
		if (temp < 0) {
			printf("Failed to get current temperature\n");
		}
		else {
			printf("%u degrees C\n", temp);
		}

	}
	else {
		printf("Initialization failed\n");
	}

	//get rid of our object
	delete(wrapper);


	system("pause");
}