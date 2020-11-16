using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Environment : MonoBehaviour
{

    private Jumper jumper;
    private TextMeshPro score;

    public void OnEnable()
    {
        jumper = transform.GetComponentInChildren<Jumper>();
        score = transform.GetComponentInChildren<TextMeshPro>();
    }

    private void FixedUpdate()
    {
        System.Console.WriteLine("test");
        score.text = jumper.GetCumulativeReward().ToString("f2");
    }
}
