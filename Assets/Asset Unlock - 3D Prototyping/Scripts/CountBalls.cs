using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountBalls : MonoBehaviour
{
    public TextMeshProUGUI CounterText;

    [SerializeField] private int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Ball")&&other.gameObject!=null){
            //other.gameObject.SetActive(false);
            //FlyingSwarmBallController swarmBall = other.gameObject.GetComponent<FlyingSwarmBallController>();
            //swarmBall.isCollected = true;
            SwarmBallOld swarmBall = other.gameObject.GetComponent<SwarmBallOld>();
            swarmBall.IsCollected = true;
            Count += 1;
            CounterText.text = "Count : " + Count;

        }

    }
}
