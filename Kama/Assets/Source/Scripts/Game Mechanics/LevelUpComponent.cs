using UnityEngine;

public class LevelUpComponent : MonoBehaviour
{
    private int CurrentLevel;
    private int EXP;
    private int maxEXP = defaultEXP;
    private bool isMaxLevel = false;
    private bool attackPoints;
    private bool skillPoints;
    public int enemyLevel; // for testing

    private const int maxLevel = 50;
    private const int defaultEXP = 100; // for the first level, maxEXP is 100

    public void UpdateEXP(int exp)
    {
        if (!isMaxLevel)
        {
            EXP += exp;
            if (EXP >= maxEXP)
            {
                LevelUp();
                maxEXP += 100;
                // Method: choose if you want atk or def
            }
            Debug.Log("EXP before next level: " + (maxEXP - EXP));
        }
        Debug.Log("You are at max level");
    }

    private void LevelUp()
    {
        CurrentLevel++;
        EXP = 0;
        if (CurrentLevel == maxLevel)
            isMaxLevel = true;
        Debug.Log("You are now level " + CurrentLevel);
    }

    private void GainEXP() => UpdateEXP(enemyLevel * 10);
}
