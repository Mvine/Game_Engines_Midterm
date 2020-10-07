#pragma once
#include "PluginSettings.h"

#include <vector>

class PLUGIN_API CheckpointTimeLogger
{

public:
	void ResetLogger();

	void SaveCheckpointTime(float p_RTBC);

	float GetTotalTime();
	float GetCheckpointTime(int p_index);
	int GetNumCheckpoints();

private:
	float m_TRT = 0.0f;
	std::vector<float> m_RTBC;

	
};

