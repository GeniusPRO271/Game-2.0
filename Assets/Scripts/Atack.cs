using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    public Animator animator;

    public Transform atackPoint;
    public float atackRange = 0.5f;
    public LayerMask enemyLayers;
    public int AtackDamge;
    public float AtackSpeed = 0.5f;
    float nextAtackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAtackTime)
        {
            Attack();
            nextAtackTime = Time.time + 1f / AtackSpeed;

        }
    }
    void Attack()
    {
        animator.SetTrigger("IsAtacking");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(atackPoint.position, atackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().Damage(AtackDamge);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (atackPoint == null) return;
        Gizmos.DrawWireSphere(atackPoint.position, atackRange);
    }
    public void UpdateAtackDamage(int ammount)
    {
        AtackDamge = AtackDamge + ammount;
    }
    public void UpdateAtackRange(int ammount)
    {
        atackRange = atackRange + ammount;
    }
}
