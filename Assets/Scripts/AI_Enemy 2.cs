using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Animator animator;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("IsDead") == false)
        {
            animator.SetBool("IsWalking", true);
            distance = Vector2.Distance(transform.position, player.transform.position);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        }
    }
}
