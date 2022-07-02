using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateStats : MonoBehaviour
{

    public void UpdatePlayerStats(Scriptalbe_Items iteam)
    {
        Debug.Log(iteam.MovementSpeed);
        Debug.Log(iteam.AtackArea);
        Debug.Log(iteam.Atack);
        Debug.Log(iteam.Health);
        int Armor = iteam.Armor;
        gameObject.GetComponent<PlayerMovement>().UpdatePlayerMovement(iteam.MovementSpeed);
        gameObject.GetComponent<Atack>().UpdateAtackRange(iteam.AtackArea);
        gameObject.GetComponent<Atack>().UpdateAtackDamage(iteam.Atack);
        gameObject.GetComponent<Health>().UpdateMaxHealth(iteam.Health);
    }
}
