using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();
    public static Dictionary<int, ItemSpawner> itemSpawners = new Dictionary<int, ItemSpawner>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;
    public GameObject itemSpawnerPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("instance already exists, destroying object!");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int _id, string _username, Vector2 _position)
    {
        GameObject _player;
        if(_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, Quaternion.identity);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, Quaternion.identity);
        }

        _player.GetComponent<PlayerManager>().id = _id;
        _player.GetComponent<PlayerManager>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerManager>());
    }

    public void CreateItemSpawner(int _spawnerId, Vector2 _position, bool _activeItem)
    {
        GameObject _spawner = Instantiate(itemSpawnerPrefab, _position, Quaternion.identity);
        _spawner.GetComponent<ItemSpawner>().Initialize(_spawnerId, _activeItem);
        itemSpawners.Add(_spawnerId, _spawner.GetComponent<ItemSpawner>());
    }
}
