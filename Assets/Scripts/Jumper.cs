using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class Jumper : Agent
{

    private Rigidbody body;
    private Environment environment;
    public float jumpSpeed = 20;

    public override void Initialize()
    {
        base.Initialize();
        body = GetComponent<Rigidbody>();
        environment = GetComponentInParent<Environment>();
    }

    public override void OnEpisodeBegin()
    {
        transform.localPosition = new Vector3(0f, 0.5f, -16f);
        body.angularVelocity = Vector3.zero;
        body.velocity = Vector3.zero;
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    public void FixedUpdate()
    {
        if (transform.localPosition.y < 0 || transform.localPosition.z < -19)
        {
            AddReward(-1f);
            EndEpisode();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.transform.CompareTag("Obstakel"))
        {
            AddReward(-1f);
            EndEpisode();
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0f;

        if (Input.GetKey(KeyCode.Space)) // Jump
        {
            actionsOut[0] = 1f;
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        Debug.Log("Springen aangeroepen!");
        if(vectorAction[0] != 0 && transform.position.y <= 1)
        {
            AddReward(0.2f);
            Debug.Log("springen!");
            Vector3 jumpVelocity = new Vector3(0f, jumpSpeed * vectorAction[0], 0f);
            body.velocity = body.velocity + jumpVelocity;
        }
    }

}
