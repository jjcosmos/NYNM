using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusicPlayer : MonoBehaviour
{
    public static SceneMusicPlayer _instance;
    // Start is called before the first frame update
    private AudioSource audioSource;
    void Start()
    {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_instance == null)
        {
            _instance = this;
        }
        if(_instance != this)
        {
            Destroy(this.gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }


    public void SwitchTracks(MusicHolder sceneHolder)
    {
        
        if (audioSource.clip != sceneHolder.sceneMusic)
        {
            audioSource.clip = sceneHolder.sceneMusic;
            
            audioSource.Play();
        }
        audioSource.volume = sceneHolder.Volume;
    }
}
