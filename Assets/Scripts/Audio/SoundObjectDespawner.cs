using UnityEngine;

namespace GameManagement
{
    public class SoundObjectDespawner : MonoBehaviour
    {
        public void DespawnSoundObject(float despawnTime){
            Destroy(gameObject, despawnTime);
        }
        //ifSound is a Loop Sound to start playing the next sound earlier
        public void DespawnSoundObjectWithOffset(AudioClip clip ,float despawnOfset)
        {
            Destroy(gameObject, clip.length - despawnOfset);
        }
    }
}
