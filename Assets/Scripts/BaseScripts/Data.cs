using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Data
{
    public float[] position3D;
    public int genericIntValue;
    
    public Data(GameObject gameObjectToSave,int genericIntValueToSave)
    {
        position3D = new float[3]
        {
            gameObjectToSave.transform.position.x,
            gameObjectToSave.transform.position.y,
            gameObjectToSave.transform.position.z
        };
        genericIntValue = genericIntValueToSave;
    }
}
