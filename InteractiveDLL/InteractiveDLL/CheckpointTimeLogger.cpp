#include "CheckpointTimeLogger.h"

PLUGIN_API void CheckpointTimeLogger::ResetLogger()
{
	m_RTBC.clear();
	m_TRT = 0.0f;
}

PLUGIN_API void CheckpointTimeLogger::SaveCheckpointTime(const float p_RTBC)
{
	m_RTBC.push_back(p_RTBC);
	m_TRT += p_RTBC;
}

PLUGIN_API float CheckpointTimeLogger::GetTotalTime()
{
	return m_TRT;
}

PLUGIN_API float CheckpointTimeLogger::GetCheckpointTime(const int p_index)
{
	return m_RTBC[p_index];
}

PLUGIN_API int CheckpointTimeLogger::GetNumCheckpoints()
{
	return m_RTBC.size();
}
