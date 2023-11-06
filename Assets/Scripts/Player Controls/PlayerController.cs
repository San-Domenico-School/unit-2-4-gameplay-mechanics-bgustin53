using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force;
    private Rigidbody playerRB;
    private Transform focalPoint;
    private float mass;
    private float drag;

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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
    }
}
