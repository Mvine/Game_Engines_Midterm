﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string p_SceneName)
    {
        SceneManager.LoadSceneAsync(p_SceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
