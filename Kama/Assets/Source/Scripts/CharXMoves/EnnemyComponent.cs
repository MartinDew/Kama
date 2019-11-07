using System.Collections;
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
    public PlayerComponent target;
    void Awake()
    {
        ennemy = new EnnemyClass()
        {
            EnnemyHealthComponent = GetComponent<IHealthComponent>(),
            EnnemyAttackComponent = GetComponent<IAttackComponent>(),
        };
        //AnimationHelper = GetComponent<IAnimationHelper>();
        ennemyController = GetComponent<EnnemyController>();
        target = GameObject.FindGameObjectWithTag("Main Character").GetComponent<PlayerComponent>();
    }

    void Start()
    {

        ennemy.EnnemyHealthComponent.OnHpChanged += () =>
        {
            Debug.Log($"ennemy has {ennemy.EnnemyHealthComponent.HP} life remaining");
        };
    }

    private void Update()
    {
        if (ennemy.EnnemyHealthComponent.HP <= 0 && !ennemyController.death)
        {            
            ennemyController.Die();
            StartCoroutine(DestroyTheEnemy()); // Roule le timer pour utiliser le yield return
            DestroyTheEnemy();
            target.LevelComponent.UpdateEXP(Level * LevelClass.enemyEXP);
            Debug.Log($"Player has {target.LevelComponent.CurrentEXP} EXP!");
        }
    }

    private IEnumerator DestroyTheEnemy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
