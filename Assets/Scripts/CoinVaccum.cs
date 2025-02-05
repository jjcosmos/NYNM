﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinVaccum : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody RB;
    bool playerTagged;
    Transform player;
    float timer;
    bool hasMutation;
    void Start()
    {
        timer = 1;
        RB = transform.parent.GetComponent<Rigidbody>();

        if(MutationManager._instance.activeMutation.mutIndex == 1)
        {
            hasMutation = true;
        }
        else
        {
            hasMutation = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hasMutation && playerTagged)
        {
            timer += .5f;
            RB.MovePosition(Vector3.MoveTowards(transform.parent.position, player.position, Time.deltaTime * timer));
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTagged = true;
            player = other.transform;
        }
    }
}
