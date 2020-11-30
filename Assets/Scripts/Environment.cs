using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Environment : MonoBehaviour
{

    private Jumper jumper;
    private TextMeshPro score;
    private ObstakelScript obstakel;
    public float averageRespawnTime = 1;
    private float respawnTime;
    public GameObject pointPrefab;
    public bool points = true;
    private List<GameObject> pointsList;

    public void OnEnable()
    {
        jumper = transform.GetComponentInChildren<Jumper>();
        score = transform.GetComponentInChildren<TextMeshPro>();
        obstakel = transform.GetComponentInChildren<ObstakelScript>();
        respawnTime = averageRespawnTime;
        StartCoroutine(PointSpawning());
        pointsList = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        score.text = $"{jumper.GetCumulativeReward().ToString("f2")} - {obstakel.count}";
        if(obstakel.count > 10)
        {
            obstakel.count = 0;
            jumper.EndEpisode();
        }
    }

    public void ResetEnvironment()
    {
        foreach (GameObject point in pointsList)
        {
            Destroy(point);
        }

        obstakel.Respawn();
        
    }

    IEnumerator PointSpawning()
    {
        while (points)
        {
            yield return new WaitForSeconds(respawnTime);
            respawnTime = Random.Range(averageRespawnTime * 0.5f, averageRespawnTime * 1.5f);
            GameObject point = Instantiate(pointPrefab, transform.position, Quaternion.identity, transform) as GameObject;
            pointsList.Add(point);
            point.transform.position = transform.position;
        }
    }
}
