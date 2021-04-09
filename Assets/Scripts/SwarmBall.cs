using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwarmBall
{
    [SerializeField]  float batteryDepletionSpeed = 0.001f;

    float timeStampCollected;


    public float BatteryDepletion(float battery_f)
    {
        battery_f = battery_f - batteryDepletionSpeed* (Time.timeSinceLevelLoad-timeStampCollected);

        return battery_f;
    }


}
