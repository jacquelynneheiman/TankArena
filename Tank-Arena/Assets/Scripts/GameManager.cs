using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

    [Header("Player Info")]
    public List<TankData> players;
    public InputManager inputManager;

    [Header("Pickups")]
    public List<Pickup> availablePickups;

    [Header("Spawning")]
    public List<Transform> availableSpawnLocations;
    public List<Transform> unavailableSpawnLocations;
    public List<Transform> powerUpSpawns;

    [Header("Prefabs")]
    public TankData playerPrefabs;
    public Camera cameraPrefab;
    public Pickup[] pickupPrefabs;

    [Header("UI Components")]
    public Image shieldFill;
    public Image healthFill;

    [Header("Camera Components")]
    public CinemachineVirtualCamera playerCamera;

    private void Start()
    {
        playerCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }
    public void StartGame()
    {
        players.Add(SpawnPlayer());

        for(int i = 0; i < powerUpSpawns.Count; i++)
        {
            availablePickups.Add(SpawnPickup(i));
        }
    }

    TankData SpawnPlayer()
    {
        TankData player = Instantiate<TankData>(playerPrefabs);

        Transform spawnLocation = availableSpawnLocations[Random.Range(0, availableSpawnLocations.Count)];
        player.transform.position = spawnLocation.position;
        player.transform.rotation = spawnLocation.rotation;
        player.shield.shieldIndicator = shieldFill;
        player.health.healthFill = healthFill;

        unavailableSpawnLocations.Add(spawnLocation);
        availableSpawnLocations.Remove(spawnLocation);

        inputManager.data = player;

        Camera camera = Instantiate<Camera>(cameraPrefab);
        
        playerCamera.Follow = player.transform;
        playerCamera.LookAt = player.transform;

        return player;
    }

    Pickup SpawnPickup(int i)
    {
        int index = Random.Range(0, pickupPrefabs.Length - 1);
        Pickup pickup = Instantiate<Pickup>(pickupPrefabs[index]);

        pickup.transform.SetParent(powerUpSpawns[i], false);
        pickup.transform.localPosition = new Vector3(0f, .5f, 0f);

        return pickup;
    }

    
}
