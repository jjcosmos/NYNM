using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChunkGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public static ChunkGenerator _instance;
    [SerializeField] int chunkSize = 60;
    [SerializeField] int lookAheadCount = 5;
    public int currentChunk;
    [SerializeField] private UnityEvent RemoveOld;

    public int loadedChunkIndex;
    [SerializeField] List<Chunk> Chunks;
    private void Awake()
    {
        //DontDestroyOnLoad(this);
        _instance = this;
    }

    public void UpdateCurrentChunk()
    {
        RemoveOld.Invoke();
        //Debug.Log($"current plus look is {currentChunk + lookAheadCount} and loaded index is {loadedChunkIndex} . ");
        if((currentChunk + lookAheadCount) >= loadedChunkIndex)
        {
            this.LoadChunk();
        }
    }

    private void LoadChunk()
    {
        //Debug.Log("Hit Load");
        loadedChunkIndex++;
        int rand = Random.Range(1, Chunks.Count);
        Chunk chonk = Instantiate(Chunks[rand], new Vector3(0, 0, loadedChunkIndex * chunkSize), Quaternion.identity); 
        chonk.chunkIndex = loadedChunkIndex;
        RemoveOld.AddListener(chonk.Delete);
    }

    void Start()
    {
        for (int i = 1; i < 4; i++)
        {
            
            Chunk chonk = Instantiate(Chunks[0], new Vector3(0, 0, i * chunkSize), Quaternion.identity);
            chonk.chunkIndex = i;
            RemoveOld.AddListener(chonk.Delete);
        }
        loadedChunkIndex = 3;
    }


    
    // Update is called once per frame
    void Update()
    {
        
    }
}
