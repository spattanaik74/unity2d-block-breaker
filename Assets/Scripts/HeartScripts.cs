using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScripts : MonoBehaviour
{
    //cached reference
    Ball hearlife;

    private void Start()
    {
        LifeOfHeart();
    }

    private void LifeOfHeart()
    {
        hearlife = FindObjectOfType<Ball>();
        if(tag == "Heart")
        {
            hearlife.HeartCounts();
        }
    }
    public void LossHeart()
    {
        Destroy(gameObject);
    }

}
