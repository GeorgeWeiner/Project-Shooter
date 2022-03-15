using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvent/AudioEvent",fileName ="ScriptableEvent",order = 0)]
public class AudioEvent : ScriptableEvent
{
    [SerializeField] List<AudioClip> audioClipsToPlay;
    protected override void EventFunction<Transform>( Transform soundPos)
    {
        for (int i = 0; i < audioClipsToPlay.Count; i++)
        {
            var tempObj = new GameObject();
            tempObj.transform.position = soundPos.transform.position;
            var tempAudioSource = tempObj.AddComponent<AudioSource>();
            tempAudioSource.PlayOneShot(audioClipsToPlay[i]);
            Destroy(tempObj, audioClipsToPlay[i].length);
            Debug.Log("Hello");
        }  
    }
    //public override void StartEvent<T>(T parameter)
    //{
    //    base.StartEvent(parameter);
    //}
}
