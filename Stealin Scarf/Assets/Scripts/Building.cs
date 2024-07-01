using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Building : MonoBehaviour
{
    public Transform[] itemSpawns;

    public float houseWealth;

    public GameObject[] itemPool;

    // items are added by selecting a random item and checking its rarity against an rng, if no items successfully pass, the spawn point is not spawnin nothing pal


    private void Start()
    {
        SpawnItems();
        houseWealth = itemSpawns.Length * 100;
    }

    void SpawnItems()
    {
        foreach (Transform itemSpawn in itemSpawns)
        { 
            GameObject bingus = itemPool[Random.Range(0, itemPool.Length - 1)];
            bingus = Instantiate(bingus, itemSpawn);
            bingus.GetComponent<Item>().OGHouse = gameObject;
        } 
    }
}
