using Unity.MLAgents;
using UnityEngine;

public class Jumper : Agent
{

    private Rigidbody body;
    private Environment environment;
    public float jumpSpeed = 20;
    public bool isGrounded;

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
            Die();
        }
        else if (isGrounded)
        {
            AddReward(0.001f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision);
        if (collision.transform.CompareTag("Obstakel"))
        {
            Die();
        }
    }

    private void Die()
    {
        AddReward(-1f);
        environment.ResetEnvironment();
        EndEpisode();
    }

    public override void Heuristic(float[] actionsOut)
    {
        actionsOut[0] = 0f;
        /*actionsOut[1] = 0f;*/


        if (Input.GetKey(KeyCode.Space)) // Jump
        {
            //Debug.Log("Spatiebalk ingedrukt");
            actionsOut[0] = 1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            actionsOut[1] = 1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            actionsOut[1] = -1f;

        }
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Point")
        {
            Destroy(other.gameObject);
            AddReward(0.25f);
        }
    }

    public override void OnActionReceived(float[] vectorAction)
    {
        //Debug.Log("Springen aangeroepen!");
        if (vectorAction[0] != 0 && isGrounded)
        {
            //Debug.Log("springen!");
            Vector3 jumpVelocity = new Vector3(0f, jumpSpeed * 1, 0f);
            body.velocity = body.velocity + jumpVelocity;
            isGrounded = false;
        }

    }

}
