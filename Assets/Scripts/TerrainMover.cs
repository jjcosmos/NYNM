using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMover : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] float moveSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position -= new Vector3(0, 0, WorldMover.WorldMoveSpeed);
    }
}
