using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSwarmBallController : MonoBehaviour
{
    FlyingSwarmBall flyingSwarmBall;
        static protected float battery = 20.0f;

    public GameObject player;
    bool ballIsInField = true;
    bool ballIsAroundPlayer = false;

    public bool isCollected = false;

    // Start is called before the first frame update
    void Start()
    {
        flyingSwarmBall = new FlyingSwarmBall();
        player = GameObject.Find("Character");
    }

    // Update is called once per frame
    void Update()
    {
            if (isCollected)
                {

                    if(!ballIsAroundPlayer)
                    {
                        BallAroundPlayer();
                    }
                    battery = flyingSwarmBall.BatteryDepletion(battery);
                    if(0 > battery){
                        isCollected = false;
                    }
                    gameObject.transform.localPosition =  flyingSwarmBall.RandomMovement();

                }else{

                    if(!ballIsInField){
                        BallBackInField();
                    }
                }

    }

    void BallAroundPlayer(){
        flyingSwarmBall.randomizeValues();
        this.transform.SetParent(player.transform);
        this.GetComponent<SphereCollider>().enabled = false; 
        ballIsInField = false;
        ballIsAroundPlayer = true;
    }

    void BallBackInField(){
            battery = 20.0f;
            transform.parent = null;
            gameObject.SetActive(false);
            this.GetComponent<SphereCollider>().enabled = true; 
            ballIsInField = true;
    }

    public bool IsCollected{
      set{
          isCollected = true;
      }
    }

}
