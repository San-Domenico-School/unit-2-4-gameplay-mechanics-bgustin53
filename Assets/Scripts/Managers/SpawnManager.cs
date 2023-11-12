using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Objects to Spawn")]
    [SerializeField] private GameObject iceSphere;
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject powerUp;

    [Header("Wave Fields")]
    [SerializeField] private int initialWave;
    [SerializeField] private int increasEachWave;
    [SerializeField] private int maximumWave;

    [Header("Portal Fields")]
    [SerializeField] private int portalFirstAppearance;
    [SerializeField] private float byWaveProbability;
    [SerializeField] private float byWaveDuration;

    [Header("Island")]
    [SerializeField] private Collider island;

    private Vector3 islandSize;
    private int waveNumber;
    private bool portalInScene;
    private GameObject instantiatedPortal;

    // Start is called before the first frame update
    void Start()
    {
        islandSize = island.bounds.size;
        waveNumber = initialWave;
    }

    // Update is called once per frame
    void Update()
    {
        if (waveNumber >= portalFirstAppearance && !portalInScene)
        {
            SpawnPortal();
        }

        if (FindObjectsOfType<IceSphereController>().Length == 0 &&
           GameObject.Find("Player") != null)
        {
            SpawnWave();
        }

    }

    private void SpawnWave()
    {
        for(int i = 0; i < waveNumber; i++)
        {
            Instantiate(iceSphere, SetRandomPosition(0.0f), iceSphere.transform.rotation);
        }

        if(waveNumber < maximumWave)
        {
            waveNumber++;
        }
    }

    private void SpawnPortal()
    {
        if(Random.value < waveNumber * byWaveProbability || GameManager.Instance.debugSpawnPortal)
        {
            instantiatedPortal = Instantiate(portal, SetRandomPosition(-0.607f), portal.transform.rotation);
            StartCoroutine("CountdownTimer");
        }
    }

    private void SpawnPowerup()
    {

    }

    private Vector3 SetRandomPosition(float posY)
    {
        float posX = Random.value * islandSize.x - islandSize.x / 2;
        float posZ = Random.value * islandSize.z - islandSize.z / 2;
        return new Vector3(posX, posY, posZ);
    }

    IEnumerator CountdownTimer()
    {
        portalInScene = true;
        yield return new WaitForSeconds(waveNumber * byWaveDuration);
        portalInScene = false;
        Destroy(instantiatedPortal);
    }
}
