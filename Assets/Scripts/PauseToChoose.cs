using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseToChoose : MonoBehaviour
{
    public IteamChoose iteam;
    public void PauseChoose()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
        iteam.GetUpgrade();
    }
}
