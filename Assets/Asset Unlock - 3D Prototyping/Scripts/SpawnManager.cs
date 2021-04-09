using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]  float spawnRangeX = 20;
    [SerializeField] float spawnRangeZ = 20;

    [SerializeField] float spawnPosY = 1;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void  SpawnRandomBall()
    {
        GameObject pooledBall = ObjectPooler.SharedInstance.GetPooledObject();
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),
            spawnPosY, Random.Range(-spawnRangeZ, spawnRangeZ));
         if (pooledBall != null)
            {
                pooledBall.SetActive(true); // activate it
                pooledBall.transform.position = spawnPos; 
            }
    }

}
