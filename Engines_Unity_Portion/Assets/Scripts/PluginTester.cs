using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PluginTester : MonoBehaviour
{


    public List<Transform> m_CheckpointLocations;

    private int m_CurrentCheckpoint = 0;

    private const string DLL_NAME = "InteractiveDLL";

    //Methods
    [DllImport(DLL_NAME)]
    private static extern void ResetLogger();

    //Setters
    [DllImport(DLL_NAME)]
    private static extern void SaveCheckpointTime(float p_RTBC);

    //Getters
    [DllImport(DLL_NAME)]
    private static extern float GetCheckpointTime(int p_index);

    [DllImport(DLL_NAME)]
    private static extern int GetNumCheckpoints();

    [DllImport(DLL_NAME)]
    private static extern float GetTotalTime();



    private float m_lastTime = 0.0f;

    public void SaveTimeTest(float p_CheckpointTime)
    {
        SaveCheckpointTime(p_CheckpointTime);
        p_CheckpointTime = 0.0f;
    }

    public float LoadTimeTest(int p_index)
    {
        if (p_index >= GetNumCheckpoints())
        {
            return -1;
        }
        else
        {
            return GetCheckpointTime(p_index);
        }
    }

    public float LoadTotalTimeTest()
    {
        return GetTotalTime();
    }

    public void ResetLoggerTest()
    {
        ResetLogger();
    }


    void Start()
    {
        m_lastTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                Debug.Log(LoadTimeTest(i));
            }

        }
    }

    void OnTriggerEnter()
    {

            

        float currentTime = Time.time;
        float checkpointTime = currentTime - m_lastTime;
        m_lastTime = currentTime;

        Debug.Log(checkpointTime);
        SaveTimeTest(checkpointTime);

        m_CurrentCheckpoint++;

        if (m_CurrentCheckpoint >= m_CheckpointLocations.Count) 
        {
            m_CurrentCheckpoint = 0;
        }

        this.transform.position = m_CheckpointLocations[m_CurrentCheckpoint].position;


    }

    void OnDestroy()
    {
        Debug.Log(LoadTotalTimeTest());
        ResetLoggerTest();
    }

}