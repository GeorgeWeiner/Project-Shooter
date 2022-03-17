using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    public void Play()
    {
        GetComponent<Animation>().Play();
    }
}
