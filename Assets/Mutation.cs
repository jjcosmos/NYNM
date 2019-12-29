using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Mutation
{
    // Start is called before the first frame update
    public string MutName;
    public Sprite MutImage;
    public int mutIndex;
    [TextArea] public string MutDescription;

    public Mutation(string mutName)
    {
        MutName = mutName;
    }

    public bool IsSame(Mutation mut)
    {
        if(mutIndex == mut.mutIndex)
        {
            return (true);
        }
        return false;
    }
    
}
