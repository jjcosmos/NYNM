using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMover : MonoBehaviour
{
    // Start is called before the first frame update
    public static float WorldMoveSpeed;
    [SerializeField] float viewableMoveSpeed = WorldMoveSpeed;
    public void Update()
    {
        WorldMoveSpeed = viewableMoveSpeed;
    }
}
