using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static Dictionary<int, ItemSpawner> spawners = new Dictionary<int, ItemSpawner>();
    private static int nextSpawnerId = 1;

    public int spawnerId;
    public bool activeItem;

    private void Start()
    {
        activeItem = false;
        spawnerId = nextSpawnerId;
        nextSpawnerId++;
        spawners.Add(spawnerId, this);

        StartCoroutine(SpawnItem());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player _player = collision.GetComponent<Player>();
            if(_player.AttempPickUpItem())
            {
                ItemPickedUp(_player.id);
            }
        }
    }

    private IEnumerator SpawnItem()
    {
        yield return null;

        activeItem = true;
        ServerSend.ItemSpawned(spawnerId);
    }

    private void ItemPickedUp(int _byPlayer)
    {
        activeItem = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        ServerSend.ItemPickedUp(spawnerId, _byPlayer);
    }
}
