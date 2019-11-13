using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region singleton
    public static PlayerManager instance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Main Character");
        instance = this;
    }

    public GameObject player;
    public GameObject equippedWeapon;

    #endregion
}
