using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutationManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Mutation> possibleMutations;
    public Mutation activeMutation;

    public static MutationManager _instance;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if(_instance == null)
        {
            _instance = this;
        }
        if(_instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        activeMutation = possibleMutations[Random.Range(0, possibleMutations.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
