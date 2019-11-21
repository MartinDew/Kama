using System.Collections;
using UnityEngine;
using KamaLib;
using UnityEngine.UI;

[RequireComponent(typeof(IHealthComponent))]
[RequireComponent(typeof(IAttackComponent))]
public class EnnemyComponent : MonoBehaviour
{
    static private int goblinsKilled = 0;
    private EnnemyClass ennemy;
    bool questHasBeenGiven = false;
    public IHealthComponent HealthComponent => ennemy.EnnemyHealthComponent;
    public IAttackComponent AttackComponent => ennemy.EnnemyAttackComponent;
    public bool isBoss = false;
    private GameObject questText;
    private GameObject lea;
    //public IAnimationHelper AnimationHelper;
    public EnnemyController ennemyController;
    public int level;
    public PlayerComponent target;
    public AudioClip winMusic;
    public GameObject winScreen;
    AudioSource audioSource;
    void Awake()
    {
        level = 2;
        ennemy = new EnnemyClass()
        {
            EnnemyHealthComponent = GetComponent<IHealthComponent>(),
            EnnemyAttackComponent = GetComponent<IAttackComponent>(),
        };
        ennemyController = GetComponent<EnnemyController>();
        target = GameObject.FindGameObjectWithTag("Main Character").GetComponent<PlayerComponent>();
        lea = GameObject.Find("NPC Léa");
    }

    void Start()
    {
        questText = GameObject.Find("QuestText");
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

            if (questText.GetComponent<Text>().text == "- Éliminer 5 goblins")
                goblinsKilled++;

            /// À la place de gérer ça sur un ennemi indépendant fait toi un quest manager que tu donnera au game manager pis qui gère toutes tes quêtes. 
            /// Dans ce cas-ci il pourrait incrémenter les goblins morts.
            if (goblinsKilled == 5 && !questHasBeenGiven && questText.GetComponent<Text>().text == "- Éliminer 5 goblins")
            {
                questText.GetComponent<Text>().text = "- Aller voir Léa";
                lea.GetComponent<DialogueTrigger>().dialogue.sentences = new string[4];
                lea.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "Bravo! Tu as réussi à éliminer assez de goblins!";
                lea.GetComponent<DialogueTrigger>().dialogue.sentences[1] = "Cependant, il te reste une terrible épreuve à traverser.";
                lea.GetComponent<DialogueTrigger>().dialogue.sentences[2] = "Tu dois entrer dans le sombre donjon et vaincre Kragz,\n le chef des goblins.";
                lea.GetComponent<DialogueTrigger>().dialogue.sentences[3] = "Voici la clé, tu en auras besoin pour ouvrir la porte.\n Bonne chance!";
                questHasBeenGiven = true;
            }

            if (isBoss)
            {
                audioSource.clip = winMusic;
                audioSource.volume = .5f;
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
    }

    private IEnumerator DestroyTheEnemy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
