using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory : MonoBehaviour {

	#region Singleton

	public static Inventory instance;

	void Awake () => instance = this;

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 10;	// Nombre d'inventory slot

	// Liste des items de l'inventaire
	public List<Item> items = new List<Item>();

	// Ajouter un nouvel item si il y a de la place
	public bool Add (Item item)
	{
		if (item.showInInventory) {
			if (items.Count >= space) {
				Debug.Log("Not enough room.");
				return false;
			}

			items.Add (item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke ();
		}
        return true;
	}

	// Retirer un item
	public void Remove (Item item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}
