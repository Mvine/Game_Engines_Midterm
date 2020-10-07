#pragma once
#include "CheckpointTimeLogger.h"

#ifdef __cplusplus
extern "C" {
#endif

	//Put your functions here

	//Clear Times
	PLUGIN_API void ResetLogger();
	//Save most recent time
	PLUGIN_API void SaveCheckpointTime(float p_RTBC);
	//Get total time
	PLUGIN_API float GetTotalTime();
	//Get checkpoint time at index
	PLUGIN_API float GetCheckpointTime(int p_index);
	//Get number of checkpoints
	PLUGIN_API int GetNumCheckpoints();

	
	
#ifdef __cplusplus
}
#endif