using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private SphereCollider playerCollider;
    private Light powerupIndicator;
    private Transform focalpoint;
    private float moveForce;
    public bool hasPowerup { get; private set; }

    // OnEnable is called when the player is enabled
    void OnEnable()
    {
        playerRB = GetComponent<Rigidbody>();
        playerCollider = GetComponent<SphereCollider>();
        powerupIndicator = GetComponent<Light>();
        focalpoint = GameObject.Find("Focal Point").transform;
        transform.position = GameManager.Instance.playerStartPos;
        transform.localScale = GameManager.Instance.playerScale;
        playerRB.mass = GameManager.Instance.playerMass;
        playerRB.drag = GameManager.Instance.playerDrag;
        moveForce = GameManager.Instance.playerMoveForce;
        playerCollider.material.bounciness = 0;
        powerupIndicator.intensity = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Debug.Log(verticalInput);
        playerRB.AddForce(focalpoint.forward.normalized * verticalInput * moveForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Startup"))
        {
            collision.gameObject.tag = "Ground";
            playerCollider.material.bounciness = GameManager.Instance.playerBounce;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
