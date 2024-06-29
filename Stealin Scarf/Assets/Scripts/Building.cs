using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Building : MonoBehaviour
{
    public Transform[] itemSpawns;

    float houseWealth;

    public GameObject[] itemPool;

    // items are added by selecting a random item and checking its rarity against an rng, if no items successfully pass, the spawn point is not spawnin nothing pal


    private void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {

        foreach (Transform itemSpawn in itemSpawns)
        {
            List<GameObject> checkedItems = new List<GameObject>();
            //while (checkedItems.Count <= itemPool.Length)
            //{
            //    GameObject checkingItem = itemPool[Random.Range(0, itemPool.Length - 1)];
            //    if (checkedItems.Contains(checkingItem))
            //    {
            //        continue;
            //    }

            //    if (checkingItem.GetComponent<Item>().spawnRarity >= Random.value)
            //    {
            //        Instantiate(checkingItem, itemSpawn);
            //    }
            //    checkedItems.Add(checkingItem);

            //}

            for (int i = 0; i < 14; i++)
            {
                GameObject checkingItem = itemPool[Random.Range(0, itemPool.Length - 1)];
                if (checkedItems.Contains(checkingItem))
                {
                    continue;
                }

                if (checkingItem.GetComponent<Item>().spawnRarity >= Random.value)
                {
                    Instantiate(checkingItem, itemSpawn);
                }
                checkedItems.Add(checkingItem);
            }
        }

        
    }
}
