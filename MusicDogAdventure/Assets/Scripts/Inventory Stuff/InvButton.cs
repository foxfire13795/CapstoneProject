using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvButton : MonoBehaviour {

    public bool inventoryActive;

    private GameObject UI;
    private PlayerController player;

    void Awake()
    {
        inventoryActive = false;
        UI = GameObject.Find("InventoryPanel");
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        UI.GetComponent<CanvasGroup>().alpha = 0;
        UI.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void toggleUI()
    {
        // hide inventory, allow player movement
        if (inventoryActive)
        {
            UI.GetComponent<CanvasGroup>().alpha = 0;
            UI.GetComponent<CanvasGroup>().blocksRaycasts = false;
            player.canMove = true;
            inventoryActive = false;
        }
        // show inventory, disable player movement
        else
        {
            UI.GetComponent<CanvasGroup>().alpha = 1;
            UI.GetComponent<CanvasGroup>().blocksRaycasts = true;
            player.canMove = false;
            player.target = player.transform.localPosition;
            inventoryActive = true;
        }
    }
}
