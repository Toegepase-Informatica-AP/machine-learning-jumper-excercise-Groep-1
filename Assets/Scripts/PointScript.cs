using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public float zSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0, 2.0f, 4);
        transform.localPosition = new Vector3(transform.localPosition.x + Random.Range(-2.6f, 2.6f), transform.localPosition.y, transform.localPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        float newZPos = transform.localPosition.z - (Time.deltaTime * zSpeed);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, newZPos);

        if (transform.localPosition.y < 0 || transform.localPosition.z < -18)
        {
            this.DestroyThis();
        }
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
