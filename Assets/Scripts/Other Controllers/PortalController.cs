using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    private Vector3 initialScale;
    private float scaleRate = 1.1f;

    private void OnEnable()
    {
        initialScale = transform.localScale;
        transform.localScale = Vector3.one * .1f;
        InvokeRepeating("ScaleUp", 0, .03f);
    }

    private void OnDisable()
    {
        transform.localScale = initialScale;
    }

    private void ScaleUp()
    {
        if (transform.localScale.magnitude < initialScale.magnitude)
        {
            transform.localScale *= scaleRate;
        }
        else
        {
            CancelInvoke();
        }
    }


}
