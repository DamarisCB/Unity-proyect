using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpHeigth;
    float velX, velY;
    Rigidbody2D rb;
    public Transform groudcheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    Animator anim;
    //daño
    public float recoilX;
    public float recoilY;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groudcheck.position, groundCheckRadius, whatIsGround);

       if (isGrounded)
        {
            anim.SetBool("Jump", false);
        }else
        {
            anim.SetBool("Jump", true);
        }

        FlipCharacter();
        Attack();




    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    public void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Attack", true);
        }else
        {
            anim.SetBool("Attack", false);
        }

    }

    public void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeigth);
        }
    }

    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);

        if (rb.velocity.x != 0)
        {
            anim.SetBool("Run", true);
        } else
        {
            anim.SetBool("Run", false);
        }
    }

    public void FlipCharacter()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(4, 4, 4);
        }
        else if(rb.velocity.x <0)
        {
            transform.localScale = new Vector3(-4, 4, 4);
        }
    }
   
}
