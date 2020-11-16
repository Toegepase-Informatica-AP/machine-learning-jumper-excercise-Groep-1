using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public float zSpeed = 10;
    private static Vector3 standardSpawnpoint;

    // Start is called before the first frame update
    void Start()
    {
        standardSpawnpoint = new Vector3(0, 0.5f, 4);
        transform.position = new Vector3(standardSpawnpoint.x + Random.Range(-2.6f, 2.6f), standardSpawnpoint.y, standardSpawnpoint.z);
    }

    // Update is called once per frame
    void Update()
    {
        float newZPos = transform.localPosition.z - (Time.deltaTime * zSpeed);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZPos);

        if (transform.localPosition.y < 0 || transform.localPosition.z < -19)
        {
            Destroy(gameObject);
        }
    }
}
