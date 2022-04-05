using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChangeLevel_to_Exterior_HDRP : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown (KeyCode.L))
        {
            Application.LoadLevel("Scene_Biomass_Exterior_HDRP");
        }
    }
}