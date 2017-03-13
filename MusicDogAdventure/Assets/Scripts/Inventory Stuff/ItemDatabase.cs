using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    public TextAsset items;
    private Item next;
    private string text;
    private string[] jSon_to_text;
    
	
    void Awake()
    {
        char[] separators = { '|' };
        jSon_to_text = items.text.Split(separators);
        ConstructItemDatabase();
    }

    
    public Item FetchItemByID(int id)
    {
        for (int i = 0; i < jSon_to_text.Length; i++)
        {
            if(database[i].ID == id)
                return database[i];
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < jSon_to_text.Length; i++)
        {
            database.Add(Item.CreateFromJSON(jSon_to_text[i]));
        }
    }
}

[System.Serializable]
public class Item
{
    public int ID;
    public string Title;
    public string Description;
    public bool Usable;
    public string Slug;
    public Sprite Sprite;
    public bool isInInventory;

    public Item(int id, string title, string description, bool usable, string slug)
    {
        this.ID = id;
        this.Title = title;
        this.Description = description;
        this.Usable = usable;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/" + slug);
        this.isInInventory = false;
    }

    /*public Item()
    {
        ID = -1;
    }*/

    public static Item CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Item>(jsonString);
    }
}