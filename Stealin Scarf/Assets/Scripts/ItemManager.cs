using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    GameObject[] items = new GameObject[5];
    public Image[] sprites = new Image[5];

    public Sprite emptySprite;

    public int activeSlot = 0;

    public Transform spawnPoint;

    public AudioSource playSound;

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (activeSlot >= 4)
            {
                activeSlot = 0;
            }
            else
            {
                activeSlot++;
            }

        }
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (activeSlot <= 0)
            {
                activeSlot = 4;
            }
            else
            {
                activeSlot--;
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveItem();
        }
    }


    public void AddItem(GameObject go, int slotNum)
    {
        items[slotNum] = go;
        go.SetActive(false);
       
        sprites[slotNum].sprite = go.GetComponent<Item>().sprite;
        
        playSound.Play();

    }

    public void RemoveItem()
    {
        if (items[activeSlot] != null)
        {
            Debug.Log($"dropping  {activeSlot + 1}");
            items[activeSlot].gameObject.transform.position = spawnPoint.position;

            items[activeSlot].SetActive(true);
            items[activeSlot].GetComponent<Rigidbody>().velocity = GameObject.Find("Platyer").GetComponent<Rigidbody>().velocity;

            items[activeSlot] = null;
            sprites[activeSlot].sprite = emptySprite;
            playSound.Play();
        }
        
    }

    public (bool, int) SpaceCheck()
    {
        //check slot for free space then if its full check for other free spaces

        if (items[activeSlot] == null)
        {
            return (true, activeSlot);
        }
        else
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    return (true, i);
                }
            }
        }
        
        return (false, -1);
        
        
    }

}
