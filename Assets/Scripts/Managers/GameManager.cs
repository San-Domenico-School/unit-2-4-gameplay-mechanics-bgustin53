using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
        //This is a common approach to handling a class with a reference to itself.
        //If instance variable doesn't exist, assign this object to it
        if (Instance == null)
            Instance = this;
        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one GameManager object in a scene at a time.
        else if (Instance != this)
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
