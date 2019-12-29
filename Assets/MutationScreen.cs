using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MutationScreen : MonoBehaviour
{
    // Start is called before the first frame update
    bool infoScreen;
    private void Awake()
    {
        
    }

    void Start()
    {
        MutationManager._instance.RerollMutation();
        GetComponent<TextMeshPro>().text = "Current Mutation: \n \n" + MutationManager._instance.activeMutation.MutName;
    }


    public void SwitchScreen()
    {
        if (infoScreen)
        {
            GetComponent<TextMeshPro>().text = "Current Mutation: \n \n" + MutationManager._instance.activeMutation.MutName;
        }
        else
        {
            GetComponent<TextMeshPro>().text = MutationManager._instance.activeMutation.MutDescription;
        }

        infoScreen = !infoScreen;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
