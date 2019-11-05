using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTextureOnSpawn : MonoBehaviour
{
    public Material[] textures;

    private void Awake()
    {
        //Material texture = ;
        GetComponent<SkinnedMeshRenderer>().material = textures[Random.Range(0, textures.Length)];
    }
}
