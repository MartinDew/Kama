using UnityEngine;
using KamaLib;
using UnityEngine.UI;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(IHealthComponent))]
[RequireComponent(typeof(IAttackComponent))]
[RequireComponent(typeof(ISkillComponent))]
[RequireComponent(typeof(ILevelComponent))]
public class PlayerComponent : MonoBehaviour
{
    private PlayerClass player;
    public IHealthComponent HealthComponent => player.HealthComponent;
    public IAttackComponent AttackComponent => player.AttackComponent;
    public ISkillComponent SkillComponent => player.SkillComponent;
    public float SkillConsumption;
    public ILevelComponent LevelComponent => player.LevelComponent;
    public AudioClip gameOverClip;
    public AudioSource swordSound;
    public GameObject gameOverScreen;
    private GameObject inventory;
    private QuestManager questManager;
    private Text levelText;
    public GameObject loadingScreen;
    private bool isDead = false;
    private int activeQuest;

    private void Awake()
    {
        inventory = GameObject.Find("Inventory");
        questManager = GameObject.Find("GameManager").GetComponent<QuestManager>();
        levelText = GameObject.Find("Level Value").GetComponent<Text>();
        SkillConsumption = 5;
        Time.timeScale = 1;
    }

    private void Start()
    {
        levelText.text = "Niveau\n" + LevelClass.defaultLevel;
        player = new PlayerClass()
        {
            AttackComponent = GetComponent<IAttackComponent>(),
            HealthComponent = GetComponent<IHealthComponent>(),
            SkillComponent = GetComponent<ISkillComponent>(),
            LevelComponent = GetComponent<ILevelComponent>()
        };

        loadingScreen.SetActive(true);
        if (SaveSystem.LoadOnStart)
            StartCoroutine(LoadMethod());
        else
            StartCoroutine(NewGameMethod());

        SaveSystem.LoadOnStart = false;

        if (activeQuest == 6)
            GameObject.Find("GameManager").GetComponent<QuestManager>().entrance.SetActive(false);
    }

    IEnumerator LoadMethod()
    {
        yield return new WaitForSeconds(1);
        loadingScreen.SetActive(false);
        LoadPlayer();
    }

    IEnumerator NewGameMethod()
    {
        yield return new WaitForSeconds(0.5f);
        loadingScreen.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && SkillComponent.Sp > SkillConsumption && !inventory.activeSelf)
            if (!isDead)
                Attack();

        if (HealthComponent.HP <= 0 && !isDead)
        {
            isDead = true;
            GetComponent<Animator>().SetBool("dead", true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ThirdPersonCameraController>().enabled = false;
            GetComponent<AudioSource>().clip = gameOverClip;
            GameObject.Find("GameManager").GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();

            StartCoroutine(ShowGameOverScreen());
            ShowGameOverScreen();
        }
    }

    private void Attack()
    {
        GetComponent<Animator>().SetTrigger("Attack");
        GetComponent<Animator>().SetInteger("Attacks", Random.Range(0, 3));
        SkillComponent.SpendSp(SkillConsumption);
        RaycastHit hit = new RaycastHit();
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;

        if (Physics.Raycast(origin, forward, out hit, AttackComponent.getTotalRange()))
            if (hit.transform.gameObject.tag == "Ennemy")
                hit.transform.gameObject.SendMessage("TakeDamage", AttackComponent.Attack());

        if (swordSound != null)
            swordSound.Play();
    }

    public int GetActiveQuest()
    {
        return activeQuest;
    }

    public void SavePlayer() => SaveSystem.SavePlayer(this);

    public void LoadPlayer()
    {
        if (File.Exists(SaveSystem.path))
        {
            PlayerData data = SaveSystem.LoadPlayer();
            Vector3 position;
            position = new Vector3(data.position[0],data.position[1],data.position[2]);

            transform.position = position;

            HealthComponent.Initialize(data.MaxHP, data.HP);
            SkillComponent.Initialize(data.MaxSP, data.SP);
            LevelComponent.Initialize(data.level, data.maxLevel, data.EXP, data.maxEXP, data.ATK, data.HP, data.SP);
            GameObject.Find("Level Value").GetComponent<Text>().text = "Niveau\n" + data.level;
            LoadInventory(data);
            activeQuest = data.activeQuest;
            GameObject.Find("GameManager").GetComponent<QuestManager>().SetActiveQuest(activeQuest);

            if (data.equippedWeapon != null)
            {
                GameObject weapon = GameObject.Find(data.equippedWeapon);
                weapon.GetComponent<ItemPickup>().item.gameObject = weapon;
                weapon.GetComponent<ItemPickup>().item.Use();
                if (weapon.GetComponentInChildren<Canvas>() != null)
                    weapon.GetComponentInChildren<Canvas>().enabled = false;
            }
        }
    }
    private void LoadInventory(PlayerData data)
    {
        bool savedHPPotions = false;
        bool savedSPPotions = false;
        GameObject collectibles = GameObject.Find("Interactables");
        ItemPickup[] itemPickups = collectibles.GetComponentsInChildren<ItemPickup>();

        Inventory.instance.items.Clear();

        for (int i = 0; i < data.itemIds.Length; i++)
            foreach (ItemPickup itemPickup in itemPickups)
                if (data.itemIds[i] == itemPickup.item.id)
                    if (itemPickup.item.name == "Health Potion")
                    {
                        if (!savedHPPotions)
                        {
                            for (int j = 0; j < data.HPpotionsCount; j++)
                                Inventory.instance.Add(itemPickup.item);
                            savedHPPotions = true;
                        }
                    }
                    else if (itemPickup.item.name == "Stamina Potion")
                    {
                        if (!savedSPPotions)
                        {
                            for (int j = 0; j < data.SPpotionsCount; j++)
                                Inventory.instance.Add(itemPickup.item);
                            savedSPPotions = true;
                        }
                    }
                    else
                    {
                        GameObject temp = Instantiate(GameObject.Find(itemPickup.name));
                        Inventory.instance.Add(itemPickup.item);
                        itemPickup.item.gameObject = temp;
                        itemPickup.item.gameObject.GetComponentInChildren<Text>().enabled = false;
                    }
    }

    private IEnumerator ShowGameOverScreen()
    {
        yield return new WaitForSeconds(2.5f);
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}