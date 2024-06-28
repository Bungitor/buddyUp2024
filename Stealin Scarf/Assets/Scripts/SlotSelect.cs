using UnityEngine;
using UnityEngine.UI;

public class SlotSelect : MonoBehaviour
{
    public Sprite active;
    public Sprite inactive;
 
    public Image[] slots = new Image[5];

    ItemManager itemManager;

    private void Awake()
    {
        itemManager = GameObject.FindObjectOfType<ItemManager>();
    }

    private void Update()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (itemManager.activeSlot == i)
            {
                slots[i].sprite = active;
            }
            else slots[i].sprite = inactive;
        }
    }


    



}
