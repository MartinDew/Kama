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
    public int level;
    public bool isBoss = false;
    private EnnemyController ennemyController;
    private PlayerComponent target;
    public AudioClip winMusic;
    public GameObject winScreen;
    public AudioSource swordSound;
    private AudioSource audioSource;
    private QuestManager questManager;
    void Awake()
    {
        questManager = GameObject.Find("GameManager").GetComponent<QuestManager>();
        level = 2;
        target = GameObject.FindGameObjectWithTag("Main Character").GetComponent<PlayerComponent>();
    }

    void Start()
    {
        ennemy = new EnnemyClass()
        {
            EnnemyHealthComponent = GetComponent<IHealthComponent>(),
            EnnemyAttackComponent = GetComponent<IAttackComponent>(),
        };
        ennemyController = GetComponent<EnnemyController>();
        audioSource = GameObject.Find("GameManager").GetComponent<AudioSource>();

        ennemy.EnnemyHealthComponent.OnHpChanged += () =>
        {
            Debug.Log($"Enemy has {ennemy.EnnemyHealthComponent.HP} Health left");
        };
    }

    private void Update()
    {
        if (ennemy.EnnemyHealthComponent.HP <= 0 && !ennemyController.death)
        {
            ennemyController.Die();
            StartCoroutine(DestroyTheEnemy());
            DestroyTheEnemy();
            target.LevelComponent.UpdateEXP(level * LevelClass.enemyEXP);
            Debug.Log($"Player has {target.LevelComponent.CurrentEXP} EXP!");

            if (questManager.GetActiveQuest() == 3)
            {
                questManager.goblinsKilled++;
                if (questManager.goblinsKilled == 5)
                    questManager.SetActiveQuest(questManager.GetActiveQuest() + 1);
            }

            if (isBoss)
            {
                audioSource.clip = winMusic;
                audioSource.volume = .5f;
                audioSource.loop = false;
                audioSource.Play();

                StartCoroutine(ShowWinScreen());
                ShowWinScreen();
            }
        }
    }

    private IEnumerator ShowWinScreen()
    {
        yield return new WaitForSeconds(2.5f);
        winScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        swordSound = null;
    }

    private IEnumerator DestroyTheEnemy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
