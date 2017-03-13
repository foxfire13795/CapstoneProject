using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    GameObject inventoryPanel;
    GameObject slotPanel;
    ItemDatabase database;
    public GameObject inventorySlot;
    public GameObject inventoryItem;

    private int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();

        slotAmount = 10;
        inventoryPanel = GameObject.Find("InventoryPanel");
        slotPanel = inventoryPanel.transform.FindChild("SlotPanel").gameObject;
        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item(-1,"","",false,""));
            slots.Add(Instantiate(inventorySlot));
            slots[i].GetComponent<SlotScript>().id = i;
            slots[i].transform.SetParent(slotPanel.transform);
        }
        AddItemOnStart(0);
    }

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        itemToAdd.isInInventory = true;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemToAdd;
                itemObj.GetComponent<ItemData>().slot = i;
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.localPosition = new Vector2(15.5f, -18.5f);
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;              
                break;
            }
        }
    }

    public void AddItemOnStart(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        itemToAdd.isInInventory = true;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == -1)
            {
                items[i] = itemToAdd;
                GameObject itemObj = Instantiate(inventoryItem);
                itemObj.GetComponent<ItemData>().item = itemToAdd;
                itemObj.GetComponent<ItemData>().slot = i;
                itemObj.transform.SetParent(slots[i].transform);
                itemObj.transform.localPosition = new Vector2(0, 0);
                itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                itemObj.name = itemToAdd.Title;
                break;
            }
        }
    }

    public void removeItem(int id)
    {
        Item itemToRemove = database.FetchItemByID(id);
        if (itemToRemove == null) return;
        itemToRemove.isInInventory = false;
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == id)
            {
                items[i].ID = -1;
                break;
            }
        }
        Destroy(GameObject.Find(itemToRemove.Title));
    }

    public bool CheckIfItemIsInInventory(int itemIndex)
    {
        Item item = database.FetchItemByID(itemIndex);
        if (item != null && item.isInInventory)
        {
            return true;
        }
        return false;
    }
}