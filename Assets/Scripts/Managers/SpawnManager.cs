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
    [SerializeField] private float portalByWaveProbability;
    [SerializeField] private float portalByWaveDuration;

    [Header("PowerUp Fields")]
    [SerializeField] private int PowerUpFirstAppearance;
    [SerializeField] private float PowerUpByWaveProbability;
    [SerializeField] private float PowerUpByWaveDuration;

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
            portalByWaveDuration = 99;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((waveNumber > portalFirstAppearance || GameManager.Instance.debugSpawnPortal) && !portalActive)
        {
            SetObjectActive(portal, portalByWaveDuration);
        }

        if (FindObjectsOfType<IceSphereController>().Length == 0 &&
           GameObject.Find("Player") != null)
        {
            SpawnIceWave();
        }

    }

    private void SpawnIceWave()
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

    private void SetObjectActive(GameObject obj, float byWaveProbability)
    {
        if(Random.value < waveNumber * byWaveProbability * Time.deltaTime || GameManager.Instance.debugSpawnPortal)
        {
            portal.transform.position = SetRandomPosition(portal.transform.position.y);

            StartCoroutine(CountdownTimer(portalByWaveDuration));
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

    IEnumerator CountdownTimer(float byWaveDuration)
    {
        portal.SetActive(true);
        portalActive = true;
        yield return new WaitForSeconds(waveNumber * byWaveDuration);
        portalActive = false;
        portal.SetActive(false);
    }
}
