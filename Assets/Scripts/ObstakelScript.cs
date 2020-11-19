using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstakelScript : MonoBehaviour
{
    public float zSpeed = 10;
    public bool randomSpeed = true;
    private static Vector3 initialPosition;
    private static Quaternion initialRotation;
    private float initialZSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.rotation;
        initialZSpeed = zSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float newZPos = transform.localPosition.z - (Time.deltaTime * zSpeed);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZPos);

        if(transform.localPosition.y < 0 || transform.localPosition.z < -19)
        {
            this.Respawn();
        }
    }

    public void Respawn()
    {
        transform.localPosition = initialPosition;
        transform.rotation = initialRotation;
        if (randomSpeed)
        {
            zSpeed = Random.Range(0.75f, 1.5f) * initialZSpeed;
        }
        Rigidbody body = GetComponent<Rigidbody>();
        body.angularVelocity = Vector3.zero;
        body.velocity = Vector3.zero;
    }
}
