using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KamaLib;
using System;

[Serializable]
public class StaminaComponent : MonoBehaviour, ISkillComponent
{
    public float maxSp;
    public Stamina stamina;

    public float MaxSp => stamina.MaxSp;
    public float Sp => stamina.Sp;
    public Action OnSpChanged { get => stamina.OnSpChanged; set => stamina.OnSpChanged = value; }
    public void Start()
    {
        Debug.Log(stamina.Sp);
    }


    public void IncreaseSp(float amount)
    {
        stamina.IncreaseSp(amount);
    }

    public void SpendSp(float damage)
    {
        stamina.SpendSp(damage);
    }

    private void Awake() => stamina = new Stamina(maxSp, maxSp);
    private void Update()
    {
        if (Sp < MaxSp)
            IncreaseSp(0.005f * (Time.deltaTime * 1000));
    }

    public void Initializer(float maxSp, float sp)
    {
        stamina = new Stamina(sp, maxSp);
    }
}
