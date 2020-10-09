using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class TimeDisplayer : MonoBehaviour
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


    // Update is called once per frame

    private GameObject testObject;
    public GameObject m_TimerPrefab;
    

    void Start()
    {
        float thisCheckpointTime = 0.0f;

        for (int i = 0; i < GetNumCheckpoints(); i++) //Spawn in a textbox for each checkpoint
        {
            testObject = Instantiate(m_TimerPrefab);
            testObject.name = "Checkpoint Textbox #" + i;
            testObject.transform.SetParent(this.transform);
            testObject.transform.position = Vector3.zero;
            testObject.transform.localPosition = new Vector3(0, 235 - i * 50, 0); //position them appropriately 

            thisCheckpointTime = GetCheckpointTime(i);
            testObject.GetComponent<TextMeshProUGUI>().text = "Checkpoint " + (i+1) + " Time : " + thisCheckpointTime;
        }

        testObject = Instantiate(m_TimerPrefab);
        testObject.name = "Total Time Textbox";
        testObject.transform.SetParent(transform); //seperate call for the total time
        testObject.transform.position = Vector3.zero;
        testObject.transform.localPosition = new Vector3(0, -75, 0);
        testObject.GetComponent<TextMeshProUGUI>().text = "Total Time : " + GetTotalTime();
    }


    private void OnDestroy()
    {
        Debug.Log(GetTotalTime());
        Debug.Log(GetNumCheckpoints());
        ResetLogger();
    }
}
