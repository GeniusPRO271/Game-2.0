using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IteamDrop : MonoBehaviour
{
    public WeightedRandomList<GameObject> IteamToDrop;
    public Transform EnemyPos;
    public void DropIteam()
    {
        GameObject item = IteamToDrop.GetRandom();
        Vector2 position = new Vector2(EnemyPos.position.x, EnemyPos.position.y - 0.14f);
        GameObject drop = Instantiate(item, position,Quaternion.identity);
        
    }
}
