using UnityEngine;
using KamaLib;
using UnityEngine.UI;
using System.Collections;
using System.IO;

[RequireComponent(typeof(IHealthComponent))]
[RequireComponent(typeof(IAttackComponent))]
[RequireComponent(typeof(ISkillComponent))]
[RequireComponent(typeof(ILevelComponent))]
public class PlayerComponent : MonoBehaviour
{
    // public GameObject target;
    private PlayerClass player;
    //private IHealthComponent targetHealth;
    public IHealthComponent HealthComponent => player.HealthComponent;
    public IAttackComponent AttackComponent => player.AttackComponent;
    public ISkillComponent SkillComponent => player.SkillComponent;
    public float SkillConsumption = 5;
    public ILevelComponent LevelComponent => player.LevelComponent;
    public AudioClip gameOverClip;
    public GameObject gameOverScreen;
    public AudioSource swordSound;
    private GameObject inventory;
    private bool isDead = false;
    private int activeQuest;

    private void Awake()
    {
        inventory = GameObject.Find("Inventory");
        player = new PlayerClass()
        {
            AttackComponent = GetComponent<IAttackComponent>(),
            HealthComponent = GetComponent<IHealthComponent>(),
            SkillComponent = GetComponent<ISkillComponent>(),
            LevelComponent = GetComponent<ILevelComponent>()
        };

        if (SaveWhenPausing.LoadOnUnpause)
        {
            LoadTemp();
            SaveWhenPausing.LoadOnUnpause = false;
        }

        if (SaveSystem.LoadOnStart)
        {
            LoadPlayer();
            SaveSystem.LoadOnStart = false;
        }
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
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;

            HealthComponent.Initialize(data.MaxHP, data.HP);
            SkillComponent.Initialize(data.MaxSP, data.SP);
            LevelComponent.Initialize(data.level, data.maxLevel, data.EXP, data.maxEXP, data.ATK, data.HP, data.SP);
            GameObject.Find("Level Value").GetComponent<Text>().text = "Niveau\n" + LevelComponent.CurrentLevel;
            LoadInventory(data);
            activeQuest = data.activeQuest;
            GameObject.Find("GameManager").GetComponent<QuestManager>().SetActiveQuest(activeQuest);
            Debug.Log("save " + activeQuest);
        }
    }

    private void LoadInventory(PlayerData data)
    {
        bool savedPotions = false;
        GameObject collectibles = GameObject.Find("Interactables");
        ItemPickup[] itemPickups = collectibles.GetComponentsInChildren<ItemPickup>();

        Inventory.instance.items.Clear();

        for (int i = 0; i < data.itemIds.Length; i++)
            foreach (ItemPickup itemPickup in itemPickups)
                if (data.itemIds[i] == itemPickup.item.id)
                    if (itemPickup.item.name == "Health Potion")
                    {
                        if (!savedPotions)
                        {
                            for (int j = 0; j < data.potionsCount; j++)
                                Inventory.instance.Add(itemPickup.item);
                            savedPotions = true;
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

    public void SaveTemp() => SaveWhenPausing.TempSave(this);

    public void LoadTemp()
    {
        if (File.Exists(SaveWhenPausing.path))
        {
            TempData data = SaveWhenPausing.TempLoad();
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;

            HealthComponent.Initialize(data.MaxHP, data.HP);
            SkillComponent.Initialize(data.MaxSP, data.SP);
            LevelComponent.Initialize(data.level, data.maxLevel, data.EXP, data.maxEXP, data.ATK, data.HP, data.SP);
            GameObject.Find("Level Value").GetComponent<Text>().text = "Niveau\n" + LevelComponent.CurrentLevel;
            TempLoadInventory(data);
            activeQuest = data.activeQuest;
            GameObject.Find("GameManager").GetComponent<QuestManager>().SetActiveQuest(activeQuest);
        }
        Debug.Log(activeQuest);
    }

    private void TempLoadInventory(TempData tempData)
    {
        bool savedPotions = false;
        GameObject collectibles = GameObject.Find("Interactables");
        ItemPickup[] itemPickups = collectibles.GetComponentsInChildren<ItemPickup>();

        Inventory.instance.items.Clear();

        for (int i = 0; i < tempData.itemIds.Length; i++)
            foreach (ItemPickup itemPickup in itemPickups)
                if (tempData.itemIds[i] == itemPickup.item.id)
                    if (itemPickup.item.name == "Health Potion")
                    {
                        if (!savedPotions)
                        {
                            for (int j = 0; j < tempData.potionsCount; j++)
                                Inventory.instance.Add(itemPickup.item);
                            savedPotions = true;
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