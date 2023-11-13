using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Player Fields")]
    public Vector3 playerStartPos;
    public Vector3 playerScale;
    public float playerMass;
    public float playerDrag;
    public float playerMoveForce;
    public float playerBounce;
    public float playerRepelForce;

    [Header("Next Level")]
    public string nextLevel;

    [Header("Debug Fields")]
    public bool debugSpawnWaves;
    public bool debugPowerUpRepel;
    public bool debugSpawnPortal;
    public bool debugTransport;

    public bool switchLevel { private get; set; }
    private GameObject player;

    

    // Awake is called before any Start methods are called
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
        EnablePlayer();
        string level = "Level1";
        string nextLevel = level.Substring(0, 5) + (int.Parse(level.Substring(5)) + 1).ToString();
        Debug.Log(nextLevel);
    }

    private void EnablePlayer()
    {
        PlayerController[] inactivePlayer = GameObject.FindObjectsOfType<PlayerController>(true);
        player = inactivePlayer[0].gameObject;

        if(player != null)
        {
            player.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void SwitchLevels()
    {

    }
}
