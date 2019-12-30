using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public static int Score;
    private TextMeshProUGUI text;
    AudioSource source;
    public static ScoreKeeper _instance;
    private void Start()
    {
        _instance = this;
        source = GetComponent<AudioSource>();
        text = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        
        text.text = Score.ToString();
    }

    public void PlaySound()
    {
        source.PlayOneShot(source.clip);
    }
}
