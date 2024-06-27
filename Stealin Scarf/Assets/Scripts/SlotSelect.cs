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
        if (itemManager.activeSlot == 0)
        {
            slots[0].sprite = active;
        }
        else slots[0].sprite = inactive;
        if (itemManager.activeSlot == 1)
        {
            slots[1].sprite = active;
        }
        else slots[1].sprite = inactive;
        if (itemManager.activeSlot == 2)
        {
            slots[2].sprite = active;
        }
        else slots[2].sprite = inactive;
        if (itemManager.activeSlot == 3)
        {
            slots[3].sprite = active;
        }
        else slots[3].sprite = inactive;
        if (itemManager.activeSlot == 4)
        {
            slots[4].sprite = active;
        }
        else slots[4].sprite = inactive;
    }

}
