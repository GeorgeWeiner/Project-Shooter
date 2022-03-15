using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvent/EnemyEvent", fileName = "ScriptableEvent", order = 0)]
public class EnemyEvent : ScriptableEvent
{
    [SerializeField] List<GameObject> enemiesToSpawnPerSpawnPoint;
    protected override void EventFunction<T>(T parameter)
    {
        for (int i = 0; i < enemiesToSpawnPerSpawnPoint.Count; i++)
        {
            Debug.Log("HEHEHEHEHHEEH");
        }
    }
}
