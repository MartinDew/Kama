using System.Collections;

using System.Collections.Generic;

using UnityEngine;


public class BardExampleSetup : MonoBehaviour {

	
	public Animator characterAnimator;
	public GameObject suit;
	void Start () {
	
		characterAnimator.Play ("CharArmature|LutePlay");

		suit.SetActive (true);	
	}
	
	

}
