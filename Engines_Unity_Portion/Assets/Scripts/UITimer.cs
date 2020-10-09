using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI m_Timer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_Timer.text = Time.timeSinceLevelLoad.ToString("f2");
    }
}
