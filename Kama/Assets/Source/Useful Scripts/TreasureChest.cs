using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable 
{
	Animator animator;
	public Item[] items;
    bool isOpen = false;
    Canvas interactCanvas;

	private void Awake() 
    {
		animator = GetComponent<Animator>();
	}

    private void Start()
    {
        interactCanvas = GetComponentInChildren<Canvas>();
    }

    public override void Interact()
	{
        if (!isOpen)
        {
            base.Interact();
            animator.SetTrigger("Open");
            CollectTreasure();
            interactCanvas.enabled = false;
        }
    }

	private void CollectTreasure() 
    {
        isOpen = true;
        Debug.Log("Chest opened");
        /*GameObject.Find("Item Obtained Message").GetComponent<Text>().enabled = true;
        GameObject.Find("Item Obtained Box").GetComponent<Image>().enabled = true;
        if (Input.GetKeyDown(KeyCode.C))
        {

        }

        GameObject.Find("Item Obtained Message").GetComponent<Text>().text = "Vous avez obtenu " + items[0].name;*/
        foreach (Item i in items)
			Inventory.instance.Add(i);
	}
}
