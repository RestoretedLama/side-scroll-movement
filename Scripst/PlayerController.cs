using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float Runing;

   
    Rigidbody RB;
    Animator animator;
   
    bool facingRight;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        facingRight = true;

    }

    void Update()
    {
       
    }

    void FixedUpdate()
    {
      

        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(move));

        float Run = Input.GetAxisRaw("Fire3");
        animator.SetFloat("Run", Run);

        if(Run > 0) { 
        RB.velocity = new Vector3(move * Runing, RB.velocity.y, 0);
            Run++;
        }
        else
        {
            RB.velocity = new Vector3(move * runSpeed, RB.velocity.y, 0);
           
        }

        if (move > 0 && !facingRight) Flip();
        else if (move < 0 && facingRight) Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.z *= -1;
        transform.localScale = theScale;
    }
  





}
