using UnityEngine;

public class ItemPickup : Interactable
{
	public Item item;	// Item to put in the inventory if picked up
    bool wasPickedUp;

    // When the player interacts with the item
    public override void Interact()
	{
		base.Interact();
        item.gameObject = gameObject;
		PickUp();
	}

	// Pick up the item
	void PickUp ()
	{
		Debug.Log("Picking up " + item.name);
		wasPickedUp = Inventory.instance.Add(item);	// Add to inventory

        if (wasPickedUp)
            item.gameObject.SetActive(false);    // Hide the item from the scene
	}
}