using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KamaLib;
using System;

[Serializable]
public class StandartHealthComponent : MonoBehaviour, IHealthComponent
{
    public float maxHp;
    public StandartHealthClass standartHealth;
    
    public float MaxHP => standartHealth.MaxHP;
    public float HP => standartHealth.HP;
    public Action OnHpChanged { get => standartHealth.OnHpChanged; set => standartHealth.OnHpChanged = value; }



    public void Increase(float amount)
    {
        standartHealth.Increase(amount);
    }

    public void TakeDamage(float damage)
    {
        standartHealth.TakeDamage(damage);
    }

    private void Awake() => standartHealth = new StandartHealthClass(maxHp, maxHp);

    public void Initialiser(float maxHp, float hp) => standartHealth = new StandartHealthClass(maxHp, hp);
}
