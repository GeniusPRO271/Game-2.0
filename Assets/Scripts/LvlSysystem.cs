using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LvlSysystem : MonoBehaviour
{
    public int level;
    public int currentXp;
    public int requireXp;
    public PauseToChoose pauseToChoose;
    public XpBar xpBar;
    public float additionMultiplaier = 300;
    public float powerMultiplaier = 2;
    public float divisonMultiplaier = 7;

    void Start()
    {
        requireXp = CalculateRequireXp();
        xpBar.SetMaxXp(requireXp,0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(currentXp);
            GainXp(15);
        }
        if (currentXp > requireXp)
        {
            LevelUp();
            pauseToChoose.PauseChoose();
        }
    }
    public void GainXp(int xpGained)
    {
        currentXp += xpGained;
        int currentXpInt = (int) currentXp;
        xpBar.SetXP(currentXpInt);

    }
    public void LevelUp()
    {
        level++;
        currentXp = Mathf.RoundToInt(currentXp - requireXp);
        requireXp = CalculateRequireXp();
        xpBar.SetMaxXp(requireXp, currentXp);

    }
    public int CalculateRequireXp()
    {
        int solveForRequireXP = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveForRequireXP += (int)Mathf.Floor(levelCycle + additionMultiplaier * Mathf.Pow(powerMultiplaier, levelCycle / divisonMultiplaier));
        }
        return solveForRequireXP / 4;

    }
}
