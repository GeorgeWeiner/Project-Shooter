using System.Collections;
using System.Collections.Generic;
using Inputs;
using UnityEngine;

public class Fmod_Testscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
        }
    }
}
