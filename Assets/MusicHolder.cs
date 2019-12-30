using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip sceneMusic;
    public float Volume;
    void Start()
    {
        SceneMusicPlayer._instance.SwitchTracks(this.GetComponent<MusicHolder>());
    }

    
}
