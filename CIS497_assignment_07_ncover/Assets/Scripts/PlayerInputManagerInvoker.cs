/*
* Nathan Cover
* PlayerInputManagerInvoker.cs
* assignment 7
* Class that managers controlling a player and what actions get recorded
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Assignment_07
{
    public class PlayerInputManagerInvoker : MonoBehaviour
    {
        [SerializeField] private Receiver _receiver = null;
        private SetTransform _recordTransforms;
        [SerializeField] private Text _stepCounter = null;
        
        // Start is called before the first frame update
        void Start()
        {
            _recordTransforms = new SetTransform(_receiver);
            _stepCounter.text = "Steps: 0";
        }

        // Update is called once per frame
        void Update()
        {
            Move();

            _stepCounter.text = "Steps: " + _recordTransforms.GetStepCount();
            
            // reset the game
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
            // undo movement step
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _recordTransforms.Undo();
            }
        }

        private void Move()
        {
            // record the current transforms and then take a step either 90 degrees clockwise or counter clockwise
            if(Input.GetKeyDown(KeyCode.A))
            {
                _recordTransforms.Execute();
                _receiver.Rotate(new Vector3(0,0,90));
            }
            if(Input.GetKeyDown(KeyCode.D))
            {
                _recordTransforms.Execute();
                _receiver.Rotate(new Vector3(0,0,-90));
            }
            
            // record the current transforms and then take a step either forward or backward
            if(Input.GetKeyDown(KeyCode.W))
            {
                _recordTransforms.Execute();
                _receiver.Step(transform.up);
            }
            if(Input.GetKeyDown(KeyCode.S))
            {
                _recordTransforms.Execute();
                _receiver.Step(-transform.up);
            }
        }
    }
}
