using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRhythmMove : MonoBehaviour {

    private float speed = 9.0f;
    public Vector3 target;
    public Vector3[] lines;
    public int currentLine;
    private bool canDestroy;
    private GameObject itemToDestroy;

	// Use this for initialization
	void Start () {
        target = transform.position;
        currentLine = 3;

        lines = new Vector3[5];

        for(int i = 0; i < lines.Length; i++)
        {
            lines[i].Set(i - 2, transform.position.y, 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) && currentLine != 0)
        {
            currentLine--;
            target = lines[currentLine];
        }
        if (Input.GetKeyDown(KeyCode.D) && currentLine != 4)
        {
            currentLine++;
            target = lines[currentLine];
        }
        if (Input.GetMouseButtonDown(0) && canDestroy)
        {
            Destroy(itemToDestroy);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Col1" || 
            col.gameObject.tag == "Col2" || 
            col.gameObject.tag == "Col3" || 
            col.gameObject.tag == "Col4" || 
            col.gameObject.tag == "Col5")
        {
            canDestroy = true;
            itemToDestroy = col.gameObject;
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        canDestroy = false;
        itemToDestroy = null;
    }
}
