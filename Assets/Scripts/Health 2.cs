using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    public Animator animator;

    public HealthBar healthBar;

    private int MAX_HEALTH = 100;

    void Update()
    {

    }
    public void Damage(int amount)
    {
        if (animator.GetBool("IsDead") == false) {
            this.health -= amount;
            Debug.Log(health);
            animator.SetTrigger("Damage");
            healthBar.SetHealth(health);
            Debug.Log(health);

            if (health <= 0)
            {
                animator.SetBool("IsDead", true);
                health = -1;
            }
        }
    

    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            this.health += 0;
        }
        if (health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }
}
