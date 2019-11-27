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
    Image msgBox;
    Text msg;

	private void Awake() 
    {
		animator = GetComponent<Animator>();
        msgBox = GameObject.Find("Item Obtained Box").GetComponent<Image>();
        msg = GameObject.Find("Item Obtained Message").GetComponent<Text>();
        msgBox.enabled = false;
        msg.enabled = false;
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

        if (items[0].name == "Health Potion")
            msg.text = "Vous avez obtenu une potion de vie!";
        else if (items[0].name == "Stamina Potion")
            msg.text = "Vous avez obtenu une potion de stamina!";

        StartCoroutine(ShowAndHide(msg, msgBox));
        foreach (Item i in items)
			Inventory.instance.Add(i);
	}

    IEnumerator ShowAndHide(Text msg, Image msgBox)
    {
        msg.enabled = true;
        msgBox.enabled = true;
        yield return new WaitForSeconds(3);
        msg.enabled = false;
        msgBox.enabled = false;
    }
}
