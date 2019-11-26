using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/* This object manages the inventory UI. */

public class InventoryUI : MonoBehaviour {

	public GameObject inventoryUI;
	public Transform itemsParent;	
    bool inventoryOpened = false;
	Inventory inventory;
    new ThirdPersonCameraController camera;
	GameObject save;
    GameObject load;

	private void Awake()
	{
		save = GameObject.Find("Save");
        load = GameObject.Find("Load");
	}
	private void Start ()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;
        camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdPersonCameraController>();
    }

	// Check to see if we should open/close the inventory
	private void Update ()
	{
		if (Input.GetButtonDown("Inventory"))
		{
            inventoryOpened = !inventoryOpened;
            if (inventoryOpened)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
				save.SetActive(true);
				load.SetActive(true);
                GameObject.Find("InventoryTooltip").GetComponent<Text>().text = "Fermer l'inventaire (i)";
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
				save.SetActive(false);
				load.SetActive(false);
                GameObject.Find("InventoryTooltip").GetComponent<Text>().text = "Ouvrir l'inventaire (i)";
            }
            camera.enabled = !camera.enabled;
			inventoryUI.SetActive(!inventoryUI.activeSelf);
			UpdateUI();
		}
	}

	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	public void UpdateUI ()
	{
		InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			}
            else
			{
				slots[i].ClearSlot();
			}
		}
	}

}
