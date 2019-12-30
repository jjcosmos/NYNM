using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //add puntos
        
        if (other.CompareTag("Player"))
        {
            //Debug.Log("triggerenter " + other.name);
            ScoreKeeper.Score++;
            Destroy(this.gameObject);
        }
        
    }
}
