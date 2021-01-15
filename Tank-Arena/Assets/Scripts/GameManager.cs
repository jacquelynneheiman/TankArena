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
    public List<TankData> players;
    public List<Transform> availableSpawnLocations;

    public List<Transform> unavailableSpawnLocations;

    public TankData playerPrefabs;
    public Camera cameraPrefab;
    public InputManager inputManager;

    [Header("UI Components")]
    public Image shieldFill;
    public Image healthFill;

    public CinemachineVirtualCamera playerCamera;

    private void Start()
    {
        playerCamera = FindObjectOfType<CinemachineVirtualCamera>();
    }
    public void StartGame()
    {
        players.Add(SpawnPlayer());
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
}
