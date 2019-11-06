using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KamaLib;

[RequireComponent(typeof(IHealthComponent))]
[RequireComponent(typeof(IAttackComponent))]
public class EnnemyComponent : MonoBehaviour
{
    private EnnemyClass ennemy;
    public IHealthComponent HealthComponent => ennemy.EnnemyHealthComponent;
    public IAttackComponent AttackComponent => ennemy.EnnemyAttackComponent;
    //public IAnimationHelper AnimationHelper;
    public EnnemyController ennemyController;
    public int Level;
    public PlayerComponent player;
    void Awake()
    {
        ennemy = new EnnemyClass()
        {
            EnnemyHealthComponent = GetComponent<IHealthComponent>(),
            EnnemyAttackComponent = GetComponent<IAttackComponent>(),
        };
        //AnimationHelper = GetComponent<IAnimationHelper>();
        ennemyController = GetComponent<EnnemyController>();
    }

    // Update is called once per frame
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Main Character").GetComponent<PlayerComponent>();

        ennemy.EnnemyHealthComponent.OnHpChanged += () =>
        {
            Debug.Log($"ennemy has {ennemy.EnnemyHealthComponent.HP} life remaining");
        };
    }

    private void Update()
    {
        //Debug.Log(($"ennemy has {ennemy.EnnemyHealthComponent.HP}"));
        if (ennemy.EnnemyHealthComponent.HP <= 0 && !ennemyController.death)
        {            
            ennemyController.Die();
            StartCoroutine(DestroyTheEnemy()); // Roule le timer pour utiliser le yield return
            DestroyTheEnemy();
            player.LevelComponent.UpdateEXP(Level * LevelClass.enemyEXP);
            Debug.Log($"Player has {player.LevelComponent.CurrentEXP} EXP!");
        }
    }

    private IEnumerator DestroyTheEnemy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
