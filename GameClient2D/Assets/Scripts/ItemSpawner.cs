using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public int spawnerId;
    public bool activeItem;
    public SpriteRenderer itemModel;

    private Vector2 basePosition;

    public void Initialize(int _spawnerId, bool _activeItem)
    {
        spawnerId = _spawnerId;
        activeItem = _activeItem;
        itemModel.enabled = _activeItem;

        basePosition = transform.position;
    }

    public void ItemSpawned()
    {
        activeItem = true;
        itemModel.enabled = true;
    }

    public void ItemPickedUp()
    {
        activeItem = false;
        itemModel.enabled = false;
    }
}
