using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSphereController : MonoBehaviour
{
    [SerializeField] private float startDelay;
    [SerializeField] private float reductionEachFrameTo;
    [SerializeField] private float minimumVolume;
    private Rigidbody iceRB;
    private ParticleSystem iceVFX;


    // Start is called before the first frame update
    void Start()
    {
        iceRB = GetComponent<Rigidbody>();
        iceVFX = GetComponent<ParticleSystem>();
        RandomizeSizeAndMass();
        InvokeRepeating("Melt", startDelay, 0.4f);
    }

    private void RandomizeSizeAndMass()
    {
        float reduction = 1 - Random.value * 0.5f;
        transform.localScale *= reduction;
        iceRB.mass *= reduction;
    }

    // Called from Melt
    private void Dissolution()
    {
        float volume = 4f / 3f * Mathf.PI * Mathf.Pow(transform.localScale.x, 2);

        if(volume < 0.8f && FindObjectsOfType<IceSphereController>().Length > 1)
        {
            iceVFX.Stop();
        }

        if(volume < minimumVolume)
        {
            CancelInvoke();
            Destroy(gameObject);
        }
    
    }

    // Called from Invoke Repeat
    private void Melt()
    {
        transform.localScale *= reductionEachFrameTo;
        iceRB.mass *= reductionEachFrameTo;
        Dissolution();
        Debug.Log(reductionEachFrameTo);
    }
}
