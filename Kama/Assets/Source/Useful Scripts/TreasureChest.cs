using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : Interactable 
{
	Animator animator;
	public Item[] items;
    bool isOpen = false;

	private void Awake() 
    {
		animator = GetComponent<Animator>();
	}

	public override void Interact()
	{
        if (!isOpen)
        {
            base.Interact();
            animator.SetTrigger("Open");
            CollectTreasure();
        }
    }

	private void CollectTreasure() 
    {
        isOpen = true;
        Debug.Log("Chest opened");
		foreach (Item i in items)
			Inventory.instance.Add(i);
	}
}
