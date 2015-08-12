#pragma once
#include <stdio.h>
#include "NvidiaAPIWrapper.h"
#include "nvapi.h"
#include "Definitions.h"


static bool initialized = false;

//constructor
NvidiaAPIWrapper::NvidiaAPIWrapper() {

}

//get the gpu temp
DWORD NvidiaAPIWrapper::getGPUTemp() {
	if (initialized) {
		NV_GPU_THERMAL_SETTINGS temp;
		NvU32 gpuCount = 0;
		NvPhysicalGpuHandle gpuHandles[NVAPI_MAX_PHYSICAL_GPUS];

		//make sure there is a gpu we can use
		if (NvAPI_EnumPhysicalGPUs(gpuHandles, &gpuCount)) {
			return NO_GPU_FOUND;
		}

		//prepare temp for usage
		ZeroMemory(&temp, sizeof(NV_GPU_THERMAL_SETTINGS));
		temp.version = NV_GPU_THERMAL_SETTINGS_VER;

		//get the thermal settings for the first gpu
		if (NvAPI_GPU_GetThermalSettings(gpuHandles[0], NVAPI_THERMAL_TARGET_ALL, &temp) != NVAPI_OK) {
			return NVIDIA_API_GET_THERMAL_SETTINGS_FAILED;
		}

		//make sure that there is a thermal sensor available
		if (temp.count == 0) {
			return NO_THERMAL_SENSORS_FOUND;
		}

		//return the temp for the first thermal sensor
		return temp.sensor[0].currentTemp;
	}
	return NVIDIA_API_NOT_INITIALIZED;
}

//intialize the nvapi 
int NvidiaAPIWrapper::init() {
	if (!initialized) {
		if (NvAPI_Initialize() != NVAPI_OK) {
			return NVIDIA_API_INIT_FAILED;
		}
		initialized = true;
		return NVIDIA_API_INIT_SUCCESS;
	}
	return NVIDIA_API_ALREADY_INITIALIZED;
}