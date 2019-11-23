using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPositionnig : MonoBehaviour
{
     Quaternion rotation;
    private void Awake()
    {
        rotation = transform.localRotation;
    }

    public void Position() => transform.localRotation = rotation;
}
