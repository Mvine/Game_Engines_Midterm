#include "Wrapper.h"

CheckpointTimeLogger timeLogger;

PLUGIN_API void ResetLogger()
{
	return timeLogger.ResetLogger();
}

PLUGIN_API void SaveCheckpointTime(float p_RTBC)
{
	return timeLogger.SaveCheckpointTime(p_RTBC);
}

PLUGIN_API float GetTotalTime()
{
	return timeLogger.GetTotalTime();
}

PLUGIN_API float GetCheckpointTime(int p_index)
{
	return timeLogger.GetCheckpointTime(p_index);
}

PLUGIN_API int GetNumCheckpoints()
{
	return timeLogger.GetNumCheckpoints();
}
