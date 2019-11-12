using UnityEngine;
using UnityEngine.UI;
using KamaLib;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    GameObject target;
    private Image bar;
    IHealthComponent playerHealth;
    private int healthValueInt;
    [SerializeField] private Text healthValue;
    private void Awake()
    {
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
        healthValue.text = $"{healthValueInt}";
    }
}