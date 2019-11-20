using UnityEngine;
using KamaLib;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EXPBar : MonoBehaviour
{
    public GameObject target;
    private Image bar;
    private ILevelComponent playerEXP;
    private int XPValueInt;
    [SerializeField] private Text XPValue;
    private void Awake()
    {
        if (target == null )
            target = GameObject.FindGameObjectWithTag("Main Character");
        playerEXP = target.GetComponent<ILevelComponent>();
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

    private float AdjustEXP()
    {
        return playerEXP.CurrentEXP / playerEXP.maxEXP;
    }

    private void LateUpdate()
    {
        SetFill(AdjustEXP());
        XPValueInt = (int)playerEXP.CurrentEXP;
        XPValue.text = $"{XPValueInt} / {playerEXP.maxEXP}";
    }
}