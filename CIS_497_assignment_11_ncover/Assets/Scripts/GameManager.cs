/*
* Nathan Cover
* GameManager.cs
* assignment_11
* Class for some misc functionality
*/

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Assignment_08
{
    public class GameManager : MonoBehaviour
    {

        // Update is called once per frame
        void Update()
        {
            // reset the game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
