using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    Item[] allItems;

    public LayerMask buildingMask;

    public float score;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            Score();
    }

    public void Score()
    {
        allItems = GameObject.FindObjectsOfType<Item>();

        foreach (Item item in allItems)
        {
            Building newItemHouse = Physics.OverlapSphere(item.transform.position, 5f, buildingMask)[0].GetComponent<Building>();
            if (Physics.OverlapSphere(item.transform.position, 5f, buildingMask)[0].GetComponent<Building>() == item.OGHouse.GetComponent<Building>())
                continue;

            float houseDiff = item.OGHouse.GetComponent<Building>().houseWealth - newItemHouse.houseWealth;
            score += item.value * Mathf.Sign(houseDiff) + houseDiff;
        }
        Debug.Log(score);
        //return score;
    }


}
