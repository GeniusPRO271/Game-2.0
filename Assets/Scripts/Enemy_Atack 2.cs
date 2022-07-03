using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Atack: MonoBehaviour
{
    public Transform atackPoint;
    public float atackRange = 0.5f;
    public LayerMask enemyLayers;
    public int AtackDamge;
    public float AtackInterval = 1f;
    float nextAtackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAtackTime)
        {
            Enemy_Atacking();
            nextAtackTime = Time.time + 1f / AtackInterval;
            Debug.Log(nextAtackTime);

        }
    }
    void Enemy_Atacking()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(atackPoint.position, atackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().Damage(AtackDamge);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (atackPoint == null) return;
        Gizmos.DrawWireSphere(atackPoint.position, atackRange);
    }
}
