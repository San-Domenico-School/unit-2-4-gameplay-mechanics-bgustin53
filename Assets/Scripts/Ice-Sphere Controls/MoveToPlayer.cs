using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] NavMeshAgent navMeshAgent;
    private GameObject player;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        navMeshAgent.SetDestination(playerRb.transform.position);
    }
}
