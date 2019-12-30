using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playonce : MonoBehaviour
{
    private static Playonce _instance;
    private AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance == null)
        {
            _instance = this;
        }
        if (this != _instance)
        {
            Destroy(this.gameObject);
        }
        audioSource = GetComponent<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.volume = 0;
        }
    }
}
