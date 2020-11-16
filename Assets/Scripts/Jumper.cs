using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class Jumper : Agent
{

    private Rigidbody body;
    private Environment environment;

    public override void Initialize()
    {
        base.Initialize();
        body = GetComponent<Rigidbody>();
        environment = GetComponentInParent<Environment>();
    }

    private void FixedUpdate()
    {
        AddReward(0.001f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Obstakel"))
        {
            AddReward(-1f);
        }
    }

}
