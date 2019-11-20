using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    Transform target;

    private void Start() => target = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

    void Update() => transform.LookAt(target);
}
