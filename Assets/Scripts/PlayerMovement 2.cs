using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 3f;

    private Rigidbody2D body;
    private Vector2 axisMovement;
    public Joystick joystick;
    public Animator animator;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        axisMovement.x = joystick.Horizontal;
        axisMovement.y = joystick.Vertical;

    }

    private void FixedUpdate()
    {
        if (animator.GetBool("IsDead") == false)
        {
            if (axisMovement != Vector2.zero)
            {
                Move();
                animator.SetBool("IsMoving", true);
            }
            else
            {
                body.velocity = axisMovement.normalized;
                animator.SetBool("IsMoving", false);
            }
        }
        else
        {
            body.velocity = Vector2.zero;
        }
        
    }
    private void Move()
    {
        body.velocity = axisMovement.normalized * speed;
        CheckForFlipping();
    }

    private void CheckForFlipping()
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;

        if (movingLeft)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y);
        }
        if (movingRight)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y);  
        }
    }
}
