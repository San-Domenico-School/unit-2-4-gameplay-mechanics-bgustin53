using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToGround : MonoBehaviour
{
    private bool isOnGround;
    private Transform parentTransform;

    // Start is called before the first frame update
    void Start()
    {
        parentTransform = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOnGround)
        {
            parentTransform.position = new Vector3(parentTransform.position.x,
                                                   parentTransform.position.y - 0.01f,
                                                   parentTransform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }
}
