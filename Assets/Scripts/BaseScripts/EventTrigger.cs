using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger: MonoBehaviour
{
    [SerializeField] List<ScriptableEvent> eventsForThisTrigger;
    [SerializeField] Transform soundPos;
    [SerializeField] List<Transform> enemySpawnPositions;
    void Start()
    {
        PlayGivenEvents();
    }
    void PlayGivenEvents()
    {
        foreach (var scriptableEvent in eventsForThisTrigger)
        {
            switch (scriptableEvent.TypeOfThisEvent)
            {
                case TypeOfThisEvent.audioEvent:
                    scriptableEvent.StartEvent<Transform>( soundPos);
                    break;
                case TypeOfThisEvent.enemyEvent:
                    for (int i = 0; i < enemySpawnPositions.Count; i++)
                    {
                        scriptableEvent.StartEvent<Transform>(enemySpawnPositions[i]);
                    }
                    
                    break;
                default:
                    break;
            }

            
        }
    }
}
