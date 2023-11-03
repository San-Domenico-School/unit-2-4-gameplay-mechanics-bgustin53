using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melting : MonoBehaviour
{
    private float startMelting = 2.0f;
    private float meltSpeed = 0.1f;
    private float meltVolume = 0.01f;
    private float minimumVolume = 0.05f;
    private Rigidbody enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        InvokeRepeating("Melt", startMelting, meltSpeed);
    }

    private void Melt()
    {
        transform.localScale = transform.localScale * (1 - meltVolume);
        enemyRB.mass = enemyRB.mass * (1 - meltVolume);
        float volume = 4.0f / 3.0f * Mathf.PI * Mathf.Pow(transform.localScale.x, 2);
        if(volume < minimumVolume)
        {
            Destroy(gameObject);
        }
    }
     
}
