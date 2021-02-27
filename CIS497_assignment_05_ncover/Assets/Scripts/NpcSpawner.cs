/*
* Nathan Cover
* NpcSpawner.cs
* assignment 5
* Class that manages the gameplay loop and spawning of npcs and keeping track of the different npcs types
*/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class NpcSpawner : MonoBehaviour
{
    private bool _gameEnd = true;
    private bool _betForCops = true;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private int amountToSpawn = 10;
    [SerializeField] private NpcFactory factory;
    [SerializeField] private List<GameObject> npcs = new List<GameObject>();
    private Bounds _spawnBounds;

    // Start is called before the first frame update
    void Start()
    {
        _gameEnd = true;
        _spawnBounds = GetComponent<BoxCollider2D>().bounds;
        SpawnNpcs(amountToSpawn);
        _gameEnd = false;
        Time.timeScale = 0;
    }

    // spawn 1 of each npc, then spawns a randomized amount of extras
    public void SpawnNpcs(int amount)
    {
        // just to make sure there is at least 1 of each
        CreateNpc("Criminal");
        CreateNpc("Cop");
        CreateNpc("Citizen");
        
        // additional spawning
        for (int i = 0; i < amountToSpawn; i++)
        {
            var chance = Random.Range(0, 100);
            
            if(chance <= 40)
                CreateNpc("Criminal");
            else if (chance <= 50)
                CreateNpc("Cop");
            else
                CreateNpc("Citizen");
        }
    }

    private void Update()
    {
        EndCondition();
        UpdateList();
        

        if (_gameEnd == true && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(Application.loadedLevel);
        }
    }

    // check how many citizens and criminals there are, trigger ends depending on what you bet
    private void EndCondition()
    {
        if (_gameEnd == false)
        {
            if (CountCriminals() <= 0)
            {
                if (_betForCops)
                {
                    Win();
                }
                else
                {
                    Lose();
                }
            }
            if (CountCitizens() <= 0)
            {
                if (_betForCops)
                {
                    Lose();
                }
                else
                {
                    Win();
                }
            }   
        }
    }

    private void Win()
    {
        Debug.Log("you win");
        Time.timeScale = 0;
        winScreen.SetActive(true);
        _gameEnd = true;
    }

    private void Lose()
    {
        Debug.Log("you lose");
        Time.timeScale = 0;
        loseScreen.SetActive(true);
        _gameEnd = true;
    }

    // could probably use observer pattern to make make a list of current NPCs a lot more clean and efficient
    private void UpdateList()
    {
        foreach (var x in npcs)
        {
            if (x == null)
            {
                npcs.Remove(x);
                break;   
            }
        }
    }

    // count the amount of citizens in the npc list
    private int CountCitizens()
    {
        var npcCount = 0;
        foreach (var x in npcs)
        {
            if (x != null)
            {
                if (x.GetComponent<Citizen>() != null)
                    npcCount++;
            }
        }
        Debug.LogFormat("there are " + npcCount + " citizens");
        return npcCount;
    }

    // count the amount of criminals in the npc list
    private int CountCriminals()
    {
        var npcCount = 0;
        foreach (var x in npcs)
        {
            if (x != null)
            {
                if (x.GetComponent<Criminal>() != null)
                    npcCount++;
            }
        }
        Debug.LogFormat("there are " + npcCount + " criminals");
        return npcCount;
    }

    // create an npc of specified type, randomize its starting location, and add it to the list of npcs
    public void CreateNpc(string type)
    {
        var tempNpc = factory.CreateNpc(type);
        
        var spawnPos = new Vector2(
            Random.Range(_spawnBounds.min.x, _spawnBounds.max.x),
            Random.Range(_spawnBounds.min.y, _spawnBounds.max.y));

        tempNpc.transform.position = new Vector3(spawnPos.x, spawnPos.y, 0);
        npcs.Add(tempNpc);
    }

    // set by buttons to specify what you're betting for
    public void SetBet(bool forCops)
    {
        startScreen.SetActive(false);
        _betForCops = forCops;
        Time.timeScale = 1;
    }
}
