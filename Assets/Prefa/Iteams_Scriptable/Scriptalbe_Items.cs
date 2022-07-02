using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Iteam", menuName ="Iteam")]
public class Scriptalbe_Items : ScriptableObject
{
    public string IteamName;
    public string description;

    public Sprite IteamLogo;

    public int Atack;
    public int MovementSpeed;
    public int Armor;
    public int Health;
    public int AtackArea;

}
