using UnityEngine;
using UnityEngine.UI;
using KamaLib;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    private GameObject target;
    private Image bar;
    private IHealthComponent playerHealth;
    private int healthValueInt;
    [SerializeField] private Text healthValue;
    private void Awake()
    {
        healthValue = GameObject.Find("Health Value").GetComponent<Text>();
        target = GameObject.FindGameObjectWithTag("Main Character");
        playerHealth = target.GetComponent<IHealthComponent>();
        bar = GetComponent<Image>();        
    }

    public void SetFill(float fillAmount)
    {
        bar.fillAmount = fillAmount;
    }

    public void SetColor(Color color)
    {
        bar.color = color;
    }

    private float AdjustCharacterHealth()
    {
        return playerHealth.HP / playerHealth.MaxHP;
    }

    private void LateUpdate()
    {
        SetFill(AdjustCharacterHealth());
        healthValueInt = (int)(playerHealth.HP);
        healthValue.text = $"{healthValueInt} / {playerHealth.MaxHP}";
    }
}