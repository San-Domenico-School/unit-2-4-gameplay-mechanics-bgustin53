using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Objects to Spawn")]
    [SerializeField] private GameObject iceSphere;
    [SerializeField] private GameObject powerUps;
    [SerializeField] private Collider island;

    [Header("Wave Fields")]
    [SerializeField] private int initialWave;
    [SerializeField] private int increaseEachWave;
    [SerializeField] private int maximumWave;

    private Vector3 islandSize;
    private int waveNumber;

    private void Start()
    {
        islandSize = island.bounds.size;
        waveNumber = initialWave;
        Debug.Log(GameManager.currentScene);
        
    }

    //Update is called once per frame
    void Update()
    {
        int totalIceSpheres = FindObjectsOfType<IceSphereController>().Length;

        if (totalIceSpheres == 0)
        {
            SpawnWave();
        }
    }
    
    private void SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            Instantiate(iceSphere, SetRandomPosition(), iceSphere.transform.rotation);
        }
        if (waveNumber < maximumWave)
        {
            waveNumber += increaseEachWave;
        }
    }

    private Vector3 SetRandomPosition()
    {
        float posX = (Random.value * islandSize.x) - islandSize.x / 2;
        float posZ = (Random.value * islandSize.z) - islandSize.z / 2; ;
        return new Vector3(posX, 1.5f, posZ);
    }
}
