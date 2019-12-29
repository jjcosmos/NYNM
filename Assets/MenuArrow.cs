﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuArrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<Transform> Buttons;
    public int buttonIndex;
    private TextMeshPro text;
    [SerializeField] MutationScreen SignText;

    [SerializeField] int titleScene;
    [SerializeField] int playScene;
    void Start()
    {
        buttonIndex = 1;
        text = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(buttonIndex > 0)
            {
                buttonIndex--;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (buttonIndex < Buttons.Count-1)
            {
                buttonIndex++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (buttonIndex)
            {
                case 0:
                    SceneManager.LoadScene(titleScene);
                    break;
                case 1:
                    SignText.SwitchScreen();
                    break;
                case 2:
                    SceneManager.LoadScene(playScene);
                    break;
                default:
                    break;
            }
        }

        transform.position = Buttons[buttonIndex].position;
        text.text = Buttons[buttonIndex].name;
    }
}
