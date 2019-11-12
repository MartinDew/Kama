using UnityEngine;
using KamaLib;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EXPBar : MonoBehaviour
{
    public GameObject target;
    private Image bar;
    ILevelComponent playerEXP;
    private int EXP;
    [SerializeField] private Text expValue;
    private void Awake()
    {
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
        /*if (playerEXP.CurrentEXP != 0)
            return playerEXP.CurrentEXP / playerEXP.maxEXP;
        else*/
            return 0;
    }

    private void LateUpdate()
    {
        SetFill(AdjustEXP());
        EXP = playerEXP.CurrentEXP;
        expValue.text = $"{EXP}";
    }
}