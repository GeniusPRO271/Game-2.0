using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public Animator animator;

    public HealthBar healthBar;
    public IteamDrop iteamDrop;
    private int MAX_HEALTH = 100;


    public void Damage(int amount)
    {
        if (animator.GetBool("IsDead") == false) {
            this.health -= amount;
            animator.SetTrigger("Damage");
            healthBar.SetHealth(health);

            if (health <= 0)
            {
                animator.SetBool("IsDead", true);
                Destroy(gameObject, 1f);
                iteamDrop.DropIteam();
                health = -1;
            }
        }
    

    }

    public void UpdateMaxHealth(int amount)
    {
        MAX_HEALTH = MAX_HEALTH + amount;
    }
}
