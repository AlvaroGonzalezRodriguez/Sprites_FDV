using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpMovement : MonoBehaviour
{
     private Rigidbody2D rigidbody2d;
     private Animator animator;
     private bool maxHeigh = false;
     private float jumpMax = -1.93506f;
     private float jumpTemp = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float j = Input.GetAxisRaw("Jump");
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if(animator.GetBool("isDead") == false)
        {
            if(h == -1.0f)
            {
                animator.SetBool("isWalking", true);
                transform.localScale = new Vector3(-0.5f,0.5f,1.0f);
                //spriteRenderer.flipX = true;
                rigidbody2d.AddForce(new Vector3(h*2,0,0));
            } else if (h == 1.0f)
            {
                animator.SetBool("isWalking", true);
                transform.localScale = new Vector3(0.5f,0.5f,1.0f);
                //spriteRenderer.flipX = false;
                rigidbody2d.AddForce(new Vector3(h*2,0,0));
            } else if( h == 0) {
                animator.SetBool("isWalking", false);
                if(rigidbody2d.velocity.y == 0)
                {
                    rigidbody2d.velocity = new Vector2(0.0f, rigidbody2d.velocity.y);
                }
            }

            if(j == 0)
            {
                if(jumpTemp != j)
                {
                    maxHeigh = true;
                    jumpMax = transform.position.y + 1.1f;
                }
            }
            if(j == 1.0f && maxHeigh == false)
            {
                jumpTemp = j;
                rigidbody2d.AddForce(new Vector3(0,j*4,0));
                if(transform.position.y > jumpMax || j != jumpTemp)
                {
                    maxHeigh = true;
                }
            } else if(maxHeigh == true)
            {
                Vector3 v3Velocity = rigidbody2d.velocity;
                if(v3Velocity.y == 0.0f)
                {
                    jumpTemp = 0.0f;
                    maxHeigh = false;
                }
            }

            Attack(animator);

        }
    }

    private void Attack(Animator animator){
        float a = Input.GetAxisRaw("Fire3");

        if(a == 1.0f)
        {
            animator.SetBool("isAttacking", true);
        } else if (a == 0.0f)
        {
            animator.SetBool("isAttacking", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "EnemyZombie"){
            animator.SetBool("isDead", true);
        }
    }

}
