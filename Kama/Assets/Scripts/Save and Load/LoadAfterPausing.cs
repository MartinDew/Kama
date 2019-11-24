using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAfterPausing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerComponent player = GameObject.Find("Player").GetComponent<PlayerComponent>();
        player.LoadTemp();
    }
}
