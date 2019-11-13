using UnityEngine;
using KamaLib;
using UnityEngine.UI;

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
    public Text levelText;
    private GameObject inventory;
    private bool isDead = false;

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
        LevelComponent.InitializeStats(HealthComponent.HP, SkillComponent.Sp, AttackComponent.baseDamage);
    }

    private void Start()
    {
        //player.HealthComponent.OnHpChanged();
        //player.SkillComponent.OnSpChanged += () => Debug.Log($"The character has {player.SkillComponent.Sp}");
        player.LevelComponent.OnLevelChanged += () =>
        {
            levelText.text = "Niveau\n" + LevelComponent.CurrentLevel; 
            HealthComponent.Initialize(LevelComponent.CurrentHP, LevelComponent.CurrentHP);
            SkillComponent.Initialize(LevelComponent.CurrentSP, LevelComponent.CurrentSP);
        };
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && SkillComponent.Sp > SkillConsumption && !inventory.activeSelf)
            if (!isDead)
                Attack();

        if (Input.GetKeyDown(KeyCode.Backspace))
            HealthComponent.TakeDamage(10);

        if (HealthComponent.HP <= 0 && !isDead)
        {
            isDead = true;
            GetComponent<Animator>().SetBool("dead", true);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DirectedCameraController>().enabled = false;
        }
    }

    private void Attack()
    {
        //Animator anim;
        GetComponent<Animator>().SetTrigger("Attack");
        GetComponent<Animator>().SetInteger("Attacks", Random.Range(0, 3));
        SkillComponent.SpendSp(SkillConsumption);
        RaycastHit hit = new RaycastHit();
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;

        if (Physics.Raycast(origin, forward, out hit, AttackComponent.getTotalRange()))
        {
            if (hit.transform.gameObject.tag == "Ennemy")
                hit.transform.gameObject.SendMessage("TakeDamage", AttackComponent.Attack());
        }
    }

    public void SavePlayer() => SaveSystem.SavePlayer(this);

    public void LoadPlayer()
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
        levelText.text = "Niveau\n" + LevelComponent.CurrentLevel;
        SaveInventory(data);
    }

    private void SaveInventory(PlayerData data)
    {
        bool savedPotions = false;
        GameObject collectibles = GameObject.Find("Interactables");
        ItemPickup[] itemPickups = collectibles.GetComponentsInChildren<ItemPickup>();

        for (int i = 0; i < data.itemIds.Length; i++)
            foreach (ItemPickup itemPickup in itemPickups)
                if (data.itemIds[i] == itemPickup.item.id)
                {
                    if (itemPickup.item.name == "Health Potion")
                    {
                        for (int j = 0; j < data.potionsCount; j++)
                            if (!savedPotions)
                                Inventory.instance.Add(itemPickup.item);

                        savedPotions = true;
                    }
                    else
                        Inventory.instance.Add(itemPickup.item);
                }
    }
}