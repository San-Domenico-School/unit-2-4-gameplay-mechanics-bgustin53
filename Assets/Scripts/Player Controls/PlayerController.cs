using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private Transform focalPoint;
    private float mass;
    private float drag;
    private float force;
    public bool hasPowerup { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRB.AddForce(focalPoint.forward * verticalInput * force * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //
    }
}
