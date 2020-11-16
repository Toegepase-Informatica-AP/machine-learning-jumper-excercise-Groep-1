using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstakelScript : MonoBehaviour
{
    public float zSpeed = 10;
    private static Vector3 initialPosition;
    private static Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float newZPos = transform.localPosition.z - (Time.deltaTime * zSpeed);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZPos);

        if(transform.localPosition.y < 0 || transform.localPosition.z < -18)
        {
            //respawn
            transform.localPosition = initialPosition;
            transform.rotation = initialRotation;
        }
    }
}
