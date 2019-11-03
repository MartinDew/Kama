using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/* Sits on all InventorySlots. */

public class InventorySlot : MonoBehaviour {

	public Image icon;
	public Button removeButton;

	private Item item;	// Current item in the slot
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Main Character");
    }

    // Add item to the slot
    public void AddItem (Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
		removeButton.interactable = true;
	}

	// Clear the slot
	public void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
		removeButton.interactable = false;
	}

	// If the remove button is pressed, this function will be called.
	public void RemoveItemFromInventory ()
	{
        item.gameObject.SetActive(true);
        item.gameObject.transform.position = player.transform.position;
        item.gameObject.transform.position = new Vector3(player.transform.position.x + 2, player.transform.position.y + 2, player.transform.position.z + 2);
        Inventory.instance.Remove(item);
	}

	// Use the item
	public void UseItem ()
	{
		if (item != null)
		{
			item.Use();
		}
	}

}
