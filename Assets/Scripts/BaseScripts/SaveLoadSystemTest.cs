using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

static public class SaveLoadSystemTest
{
    static public List<GameObject> saveableObjects = new List<GameObject>();
    const string savePath = "/TestFileSave.SavedFiles";

    static public void SaveData(Data dataToSave)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + savePath;
        FileStream fileStream = new FileStream(path, FileMode.Create);
        formatter.Serialize(fileStream, dataToSave);
        fileStream.Close();
    }
    static public Data LoadData()
    {
        string path = Application.persistentDataPath + savePath;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);
            Data datatoLoad = formatter.Deserialize(fileStream) as Data;
            fileStream.Close();
            return datatoLoad;
        }
        else
        {
            Debug.Log("HELLOIAMNOTHEREHEHEHEHEHHEHLOL");
            return null;
        }
    }
    static public  void SaveMultipleData(Data dataToSave ,int counter)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + savePath;
        FileStream fileStream = new FileStream(path + counter, FileMode.Create);
        formatter.Serialize(fileStream, dataToSave);
        fileStream.Close();   
    }
    static public void LoadMultipleObjects()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + savePath;
        for (int i = 0; i < saveableObjects.Count; i++)
        {
            if (File.Exists(path))
            {
                FileStream fileStream = new FileStream(path + i, FileMode.Open);
                Data datatoLoad = formatter.Deserialize(fileStream) as Data;
                saveableObjects[i].transform.position = new Vector3(datatoLoad.position3D[0], datatoLoad.position3D[1], datatoLoad.position3D[2]);
                fileStream.Close();
            }
            else
            {
                Debug.Log("HELLOIAMNOTHEREHEHEHEHEHHEHLOL");
            }
        }
    }
   
}
