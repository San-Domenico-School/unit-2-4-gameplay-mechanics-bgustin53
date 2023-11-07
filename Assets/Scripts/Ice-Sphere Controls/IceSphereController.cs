using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSphereController : MonoBehaviour
{
    [SerializeField] private float startDelay;
    [SerializeField] private float reductionRate;
    [SerializeField] private float minimumVolume;
    private Rigidbody iceRB;


    // Start is called before the first frame update
    void Start()
    {
        iceRB = GetComponent<Rigidbody>();
        RandomizeSizeAndMass();
        InvokeRepeating("Melt", startDelay, Time.deltaTime);
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

        if(volume < minimumVolume)
        {
            CancelInvoke();
            Destroy(gameObject);
        }
    
    }

    // Called from Invoke Repeat
    private void Melt()
    {
        float reduction = 1 - reductionRate;
        transform.localScale *= reduction;
        iceRB.mass *= reduction;
        Dissolution();
    }
}
