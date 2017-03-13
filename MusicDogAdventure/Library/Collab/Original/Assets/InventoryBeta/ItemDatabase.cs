using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour
{
    private List<Item> database = new List<Item>();
    public TextAsset items;
    private Item test;
    private string text;
    private string[] jSon_to_text;
    
	
    void Start()
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
            database.Add(JsonUtility.FromJson<Item>(jSon_to_text[i]));
        }
    }
}

[System.Serializable]
public class Item
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Usable { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }
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

    public Item()
    {
        this.ID = -1;
    }
}