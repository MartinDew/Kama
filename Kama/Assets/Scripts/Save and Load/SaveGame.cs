using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public void Start()
    {
        GameObject.Find("Player").GetComponent<PlayerComponent>().SavePlayer();
    }
}
