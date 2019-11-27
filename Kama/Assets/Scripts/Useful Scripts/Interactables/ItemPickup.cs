using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : Interactable
{
	public Item item;	// Item to put in the inventory if picked up
    bool wasPickedUp;
	Canvas interactCanvas; 
    Image msgBox;
    Text msg;
    string[] labels = new string[]
    {
        "Vous avez obtenu KAMA!",
        "Vous avez obtenu une épée de fer!",
        "Vous avez obtenu une potion de vie!",
        "Vous avez obtenu une potion de stamina!"
    };

    // When the player interacts with the item
    private void Start()
	{
		interactCanvas = GetComponentInChildren<Canvas>(); 
        msgBox = GameObject.Find("Item Obtained Box").GetComponent<Image>();
        msg = GameObject.Find("Item Obtained Message").GetComponent<Text>();
        msgBox.enabled = false;
        msg.enabled = false;
    }
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
        if (item.name == "KAMA")
            msg.text = labels[0];
        else if (item.name == "IronSword")
            msg.text = labels[1];
        else if (item.name == "Health Potion")
            msg.text = labels[2];
        else if (item.name == "Stamina Potion")
            msg.text = labels[3];

        wasPickedUp = Inventory.instance.Add(item);	// Add to inventory
        
        if (wasPickedUp)
		{
            StartCoroutine(ShowAndHide());

            item.gameObject.transform.position = new Vector3(0, 0, 0);

			// Supprimer le canvas de pickup si il existe
			if (interactCanvas != null)
				interactCanvas.enabled = false;
        }
	}
    IEnumerator ShowAndHide()
    {
        msg.enabled = true;
        msgBox.enabled = true;
        yield return new WaitForSeconds(3);
        msg.enabled = false;
        msgBox.enabled = false;
    }
}