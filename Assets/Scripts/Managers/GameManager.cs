using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Metrics from GDD")]
    public float playerMass;
    public float playerDrag;
    public float playerPushForce;

    [Header("IceSphere Metrics from GDD")]
    public float iceSphereMass;
    public float iceSphereDrag;
    public float iceSpherePushForce;

    private GameObject gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
