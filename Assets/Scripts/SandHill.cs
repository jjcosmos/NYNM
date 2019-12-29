using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandHill : MonoBehaviour
{
    private static float boost = 20000;
    private bool used;
    private bool hasMutation;
    private void Start()
    {
        if(MutationManager._instance.activeMutation.mutIndex == 4)
        {
            hasMutation = true;
        }
        else
        {
            hasMutation = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hasMutation && !used && collision.transform.CompareTag("Player"))
        {
            if (collision.transform.GetComponent<Rigidbody>())
            {
                collision.transform.GetComponent<Rigidbody>().AddForce(collision.transform.forward * boost + Vector3.up * 1200);
                used = true;
            }
        }
    }
}
