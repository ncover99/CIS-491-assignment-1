/*
* Nathan Cover
* NpcSpawner.cs
* assignment 6
* Class calls to the different npc factories to spawn npcs, the player gets to choose which npc to spawn, and npcs
 * are spawned randomly within a volume
*/

using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class NpcSpawner : MonoBehaviour
{
    [SerializeField] private NPCCreator _npcCreator;
    private Bounds _spawnBounds;
    private GameObject NpcBase;
    [SerializeField] private Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        NpcBase = Resources.Load("NPC_Shell") as GameObject;
        _npcCreator = new NeutralCreator();
        _spawnBounds = GetComponent<BoxCollider2D>().bounds;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(Application.loadedLevel);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _npcCreator = new NeutralCreator();
            Debug.Log("spawner switched to Citizen");
            buttonText.text = "Spawn Citizen";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _npcCreator = new HeroCreator();
            Debug.Log("spawner switched to Cop");
            buttonText.text = "Spawn Cop";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _npcCreator = new EnemyCreator();
            Debug.Log("spawner switched to Criminal");
            buttonText.text = "Spawn Criminal";
        }
    }

    public void CreateNpc()
    {
        var temp = Instantiate(NpcBase);
        var tempNpc = _npcCreator.CreateNpc(temp);
        
        var spawnPos = new Vector2(
            Random.Range(_spawnBounds.min.x, _spawnBounds.max.x),
            Random.Range(_spawnBounds.min.y, _spawnBounds.max.y));

        tempNpc.transform.position = new Vector3(spawnPos.x, spawnPos.y, 0);
    }
}
