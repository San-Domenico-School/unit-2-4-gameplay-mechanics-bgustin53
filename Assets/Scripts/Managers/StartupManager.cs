using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        SelectPlayerAndStartGame();
    }

    private void SelectPlayerAndStartGame()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object has a selectable component
                PlayerSelection playerSelection = hit.collider.GetComponent<PlayerSelection>();

                if (playerSelection != null)
                {
                    // Call the Select method on the selectable object
                    playerSelection.gameObject.SetActive(false);
                    SceneManager.LoadScene("Level1");
                }
            }
        }
    }
}
