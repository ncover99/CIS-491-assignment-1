/*
 * Nathan Cover
 * GameManager.cs
 * Assignment_02
 * functionality for handling some ui, gameover, starting a new game and spawning enemies
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Assignment_02
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverScreen = null;
        [SerializeField] private GameObject _startScreen = null;
        private bool _gameOver = false;
        private int _kills = 0;
        [SerializeField] private Text _killsText = null;
        [SerializeField] private GameObject Enemy = null;
        [SerializeField] private List<Transform> _spawners = null;
    
        // Start is called before the first frame update
        void Awake()
        {
            _killsText.text = _kills.ToString();
            _gameOver = false;
        }
    
        void Start()
        {
            Time.timeScale = 0;
            _startScreen.SetActive(true);
            InvokeRepeating("SpawnEnemy", 2.0f, 5f);
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && !_gameOver)
            {
                Time.timeScale = 1;
                _startScreen.SetActive(false);
            }
            if (_gameOver && Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                _gameOver = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    
        private void SpawnEnemy()
        {
            var amountToSpawn = Random.Range(1, 4);
            Debug.Log("SPAWNING " + amountToSpawn + " ENEMIES");
            for (int x = 0; x < amountToSpawn; x++)
            {
                var temp = Random.Range(0, 3);
                var enemy = Instantiate(Enemy, _spawners[x]);
                enemy.GetComponent<CanTakeDamage>()._gameManager = this;
            }
        }
        
        public void GameOver()
        {
            Time.timeScale = 0;
            _gameOverScreen.SetActive(true);
            _gameOver = true;
        }
    
        public void UpdateKills()
        {
            _kills++;
            _killsText.text = _kills.ToString();
        }
    }   
}
