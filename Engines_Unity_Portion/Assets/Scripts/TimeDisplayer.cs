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

    void Start()
    {
        float thisCheckpointTime = 0.0f;

        int index = int.Parse(tag);

        //switch (tag)
        //{
        //    case "1":
        //        index = 0;
        //        break;
        //    case "2":
        //        index = 1;
        //        break;
        //    case "3":
        //        index = 2;
        //        break;
        //    case "4":
        //        index = 3;
        //        break;
        //    case "5":
        //        index = 4;
        //        break;
        //}



        if (index < GetNumCheckpoints() && index > 0)
        {
        thisCheckpointTime = GetCheckpointTime(index-1);
        this.GetComponent<TextMeshProUGUI>().text = "Checkpoint " + this.tag + " Time : " + (thisCheckpointTime);
        }
        else if (index == 5)
        {
            this.GetComponent<TextMeshProUGUI>().text = "Total Time : " + GetTotalTime();
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = "Checkpoint " + this.tag + " Time : ~";
        }


    }

    //void Update()
    //{
    //}

    private void OnDestroy()
    {
        Debug.Log(GetTotalTime());
        ResetLogger();
    }
}
