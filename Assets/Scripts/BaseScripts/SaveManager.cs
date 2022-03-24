using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : BaseSingleton<SaveManager>
{
    [SerializeField] List<GameObject> saveables = new List<GameObject>();
    public List<GameObject> SaveAbles { get { return saveables; } set { saveables = value; } }
    Data data;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        AddSaveablesToSaveLoadSystem();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        SaveLoadSystemTest.LoadMultipleObjects();
    }
    [ContextMenu("Save")]
    public void Save()
    {
        for (int i = 0; i < saveables.Count; i++)
        {  
            SaveLoadSystemTest.SaveMultipleData(new Data(saveables[i],1),i);
        }
        
    }
    void AddSaveablesToSaveLoadSystem()
    {
        for (int i = 0; i < saveables.Count; i++)
        {
            SaveLoadSystemTest.saveableObjects.Add(saveables[i]);
        }
    }

}
