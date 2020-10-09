using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider p_Collider)
    {
        if (p_Collider.CompareTag("Player"))
        {
            GetComponentInChildren<Animator>().SetBool("Cycling", true);
            GetComponentInChildren<Animator>().Play("CycleMove");
        }
    }

}
