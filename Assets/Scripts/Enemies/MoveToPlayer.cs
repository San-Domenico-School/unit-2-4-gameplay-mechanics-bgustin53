using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPlayer : MonoBehaviour
{
    [SerializeField] float force;
    private NavMeshAgent agent;
    private Transform target;
    private Rigidbody enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.enabled)
        {
            moveToTarget();
        }
    }

    private void moveToTarget()
    {
        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
    }

}
