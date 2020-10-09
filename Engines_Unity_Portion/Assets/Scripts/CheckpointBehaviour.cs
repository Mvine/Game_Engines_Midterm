using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{

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

    //Public Variables
    public List<Transform> m_CheckpointLocations;

    //Private Variables
    public int m_CurrentCheckpoint = 0;
    private float m_lastTime = 0.0f;


    //Public Methods
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




    //Monobehaviour Methods
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

    void OnTriggerEnter() //The checkpoint body teleports away to the next checkpoint location after the player makes contact
    {
        //Clock the time between checkpoints
        float currentTime = Time.time;
        float checkpointTime = currentTime - m_lastTime;
        m_lastTime = currentTime;

        SaveTimeTest(checkpointTime);

        //Send the checkpoint to the next location
        m_CurrentCheckpoint++;

        if (m_CurrentCheckpoint >= m_CheckpointLocations.Count) //If the last checkpoint is hit the checkpoint returns to the beginning
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