using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance;
    static public T Instance { get { return instance; } }
   
    private void Awake()
    {
        if(instance == null)
        {
            instance = FindObjectOfType<T>();
            if(instance == null)
            {
                instance = new GameObject($"[{typeof(T)}]-Singletoninstance").AddComponent<T>();
            }
        }
        else if(instance != null && instance != this)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
