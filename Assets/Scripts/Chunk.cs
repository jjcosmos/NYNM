using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Chunk : MonoBehaviour
{
    // Start is called before the first frame update
    public int chunkIndex;
    private bool triggered;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ChunkGenerator._instance.currentChunk = chunkIndex;
            ChunkGenerator._instance.UpdateCurrentChunk();
            //Debug.Log("LoadingNextChunk", this.gameObject);
        }
    }

    public void Delete()
    {
        if(chunkIndex < ChunkGenerator._instance.currentChunk - 1)
        {
            Destroy(gameObject);
        }
        
    }
}
