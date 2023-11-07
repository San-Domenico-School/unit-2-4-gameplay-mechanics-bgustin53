using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushInteractor : MonoBehaviour
{
    private Rigidbody iceSphereRB;

    private void Start()
    {
        iceSphereRB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Rigidbody playerRB = player.GetComponent<Rigidbody>();
            PlayerController playerController = player.GetComponent<PlayerController>();
            Vector3 direction = (player.transform.position - transform.position).normalized;
            if (!playerController.powerup)
            {
                playerRB.AddForce(direction * iceSphereRB.mass, ForceMode.Impulse);
            }
            else
            {
                iceSphereRB.AddForce(-direction * playerRB.mass, ForceMode.Impulse);
            }
        }
    }
}
