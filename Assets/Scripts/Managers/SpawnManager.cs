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
    [SerializeField] private int increaseEachWave;
    [SerializeField] private int maximumWave;

    [Header("Portal Fields")]
    [SerializeField] private int portalFirstAppearance;
    [SerializeField] private float byWaveProbability;
    [SerializeField] private float byWaveDuration;

    [Header("Island")]
    [SerializeField] private GameObject island;

    private Vector3 islandSize;
    private int waveNumber;
    private bool portalActive;

    // Start is called before the first frame update
    void Start()
    {
        islandSize = island.GetComponent<MeshCollider>().bounds.size;
        waveNumber = initialWave;
        if(GameManager.Instance.debugTransport)
        {
            byWaveDuration = 99;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waveNumber > portalFirstAppearance && !portalActive)
        {
            EnablePortal();
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
            Instantiate(iceSphere, SetRandomPosition(0), iceSphere.transform.rotation);
        }

        if(waveNumber < maximumWave)
        {
            waveNumber += increaseEachWave;
        }
    }

    private void EnablePortal()
    {
        if(Random.value < waveNumber * byWaveProbability * Time.deltaTime || GameManager.Instance.debugSpawnPortal)
        {
            portal.transform.position = SetRandomPosition(portal.transform.position.y);
            StartCoroutine("PortalCountdownTimer");
        }
    }

    private void SpawnPowerup()
    {

    }

    private Vector3 SetRandomPosition(float posY)
    {
        float posX = Random.Range(-islandSize.x / 2.75f, islandSize.x / 2.75f);
        float posZ = Random.Range(-islandSize.z / 2.75f, islandSize.z / 2.75f);
        return new Vector3(posX, posY, posZ);
    }

    IEnumerator PortalCountdownTimer()
    {
        portal.SetActive(true);
        portalActive = true;
        yield return new WaitForSeconds(waveNumber * byWaveDuration);
        portalActive = false;
        portal.SetActive(false);
    }
}
