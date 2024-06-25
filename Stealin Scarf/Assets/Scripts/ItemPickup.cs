using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    ItemManager itemManager;

    void Start()
    {
        itemManager = GameObject.FindObjectOfType<ItemManager>();
    }

    protected override void Interact()
    {
        (bool free, int slotNum) = itemManager.SpaceCheck();
        if (free)
        {
            itemManager.AddItem(this.gameObject, slotNum);
        }
    }
}
