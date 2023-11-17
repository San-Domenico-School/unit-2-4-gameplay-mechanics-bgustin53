using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelection : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDisable()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
