using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class Jumper : Agent
{

    private Rigidbody body;
    private Environment environment;
    public float jumpSpeed = 100;

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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.transform.CompareTag("Obstakel"))
        {
            AddReward(-1f);
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0f;

        if (Input.GetKey(KeyCode.Space)) // Jump
        {
            actionsOut[0] = 1;
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        if(vectorAction[0] == 1)
        {
            Debug.Log("springen!");
            Vector3 translation = transform.up * jumpSpeed * Time.deltaTime;
            transform.Translate(translation, Space.World);
        }
    }

}
