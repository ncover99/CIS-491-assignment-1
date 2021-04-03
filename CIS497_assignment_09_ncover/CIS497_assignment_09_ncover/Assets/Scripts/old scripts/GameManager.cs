/*
* Nathan Cover
* GameManager.cs
* assignment 8
* class to hold functional that is non related to npcs
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
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
