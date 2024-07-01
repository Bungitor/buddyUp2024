using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
        {
            Score();
            Debug.Log($"Score: {score}");
            score = 0;
        }
    }

    public void Score()
    {
        allItems = GameObject.FindObjectsOfType<Item>();

        foreach (Item item in allItems)
        {
            Building closestBuilding = FindClosestBuilding(item);
            if (closestBuilding == null) continue;
            if (closestBuilding == item.OGHouse) continue;

            Building newBuilding = closestBuilding;

            float houseDiff = item.OGHouse.GetComponent<Building>().houseWealth - newBuilding.houseWealth;
            score += item.value * Mathf.Sign(houseDiff) + houseDiff;
        }
        
        //return score;
    }

    Building FindClosestBuilding(Item item)
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("building");
        float currentClosestBuildingDistance = 100;
        GameObject closestBuilding = null;
        foreach (GameObject building in buildings)
        {
            float distanceFromItemToBuilding = Vector3.Distance(building.transform.position, item.transform.position);
            if (distanceFromItemToBuilding < currentClosestBuildingDistance)
            {
                closestBuilding = building;
                currentClosestBuildingDistance = distanceFromItemToBuilding;
            }
        }
        if (currentClosestBuildingDistance > 7)
        {
            return null;
        }
        return closestBuilding.GetComponent<Building>();

    }
    private void OnDrawGizmos()
    {
        allItems = GameObject.FindObjectsOfType<Item>();
        foreach (Item item in allItems)
        {
            Gizmos.DrawWireSphere(item.transform.position, 5f);
        }

    }

}
