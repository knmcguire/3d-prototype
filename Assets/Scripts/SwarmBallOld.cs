using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBallOld : MonoBehaviour
{
    private bool isCollected = false;
    private GameObject player;
    private Vector3 ballPosition;
    float randomPi;
    float randomRadius;
    float randomHeight;
    float angleHeight;
    float battery = 20.0f;
    [SerializeField]  float speed;
    [SerializeField]  float batteryDepletionSpeed = 0.001f;

    float timeStampCollected;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");
        randomPi = Random.Range(0, 2*Mathf.PI); 
        randomRadius = Random.Range(1.00f, 2.00f);
        randomHeight = Random.Range(0.5f, 1.5f);
        angleHeight = Random.Range(0, 2*Mathf.PI);

        speed = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        ballPosition = new Vector3(0, 0.5f, 0);
        if (isCollected)
        {

            battery = battery - batteryDepletionSpeed* (Time.timeSinceLevelLoad-timeStampCollected);

            if (battery < 0)
            {
                isCollected = false;
                transform.parent = null;
                gameObject.SetActive(false);
                this.GetComponent<SphereCollider>().enabled = true; 

            }
            float currentPi = randomPi + speed * Time.timeSinceLevelLoad;    
            float currentPiHeight = angleHeight + speed * Time.timeSinceLevelLoad;
            float circleX = randomRadius*Mathf.Sin(currentPi);
            float circleY = randomRadius*Mathf.Cos(currentPi);
            float height = randomHeight + 0.5f*Mathf.Sin(currentPiHeight);
            transform.localPosition = new Vector3(circleX, height ,circleY);


        }
    }

    public bool IsCollected{
      set{
          isCollected = true;
          transform.SetParent(player.transform);
          battery = 20.0f;

          this.GetComponent<SphereCollider>().enabled = false; 
          timeStampCollected = Time.timeSinceLevelLoad;
          //transform.Translate(ballPosition);

      }
    }


}
