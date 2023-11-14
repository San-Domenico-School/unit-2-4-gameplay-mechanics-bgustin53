using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Levels Fields")]
    public int lastLevel;
    public GameObject[] waypoints;

    [Header("Debug Fields")]
    public bool debugSpawnWaves;
    public bool debugPowerUpRepel;
    public bool debugSpawnPortal;
    public bool debugTransport;

    public bool switchLevel { private get; set; }
    public bool gameOver { private get; set; }
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

        // Remove this, it is just for later.
        string level = "Level1";
        string nextLevel = level.Substring(0, 5) + (int.Parse(level.Substring(5)) + 1).ToString();
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
        if(switchLevel || gameOver)
        {
            SwitchLevels();
        }
    }

    private void SwitchLevels()
    {
        // Get the name of the currently active scene
        string currentScene = SceneManager.GetActiveScene().name;

        // Extract the level number from the scene name
        int nextLevel = int.Parse(currentScene.Substring(5)) + 1;
        if(nextLevel > lastLevel)
        {
            gameOver = true;
            Debug.Log("You won");
        }


        // Create the name of the next scene based on the current level
        string nextScene = "Level" + nextLevel;

        // If the game is over, reset to Level 1
        if (gameOver)
        {
            nextScene = "Level1";
        }

        // Load the next scene
        SceneManager.LoadScene(nextScene);
    }
}
