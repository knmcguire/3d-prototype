using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSwarmBall : SwarmBall
{

     float randomPi;
     float randomRadius;
      float randomHeight;
      float angleHeight;
    [SerializeField]  float speed =3.0f;


    public FlyingSwarmBall()
    {


    }

    public void randomizeValues()
    {
        randomPi = Random.Range(0, 2*Mathf.PI); 
        randomRadius = Random.Range(1.00f, 2.00f);
        randomHeight = Random.Range(0.5f, 1.5f);
        angleHeight = Random.Range(0, 2*Mathf.PI);
    }

    public Vector3 RandomMovement()
    {       float time = Time.timeSinceLevelLoad;
            float currentPi = randomPi + speed * time;    
            float currentPiHeight = angleHeight + speed * time;
            float circleX = randomRadius*Mathf.Sin(currentPi);
            float circleY = randomRadius*Mathf.Cos(currentPi);
            float height = randomHeight + 0.5f*Mathf.Sin(currentPiHeight);
            

            return new Vector3(circleX, height ,circleY);
    }
}
