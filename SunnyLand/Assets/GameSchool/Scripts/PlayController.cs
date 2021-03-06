﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour
{

    public Transform m_Sprite;

    private Rigidbody2D m_Rigidbody2D;

    public float m_xAxisSpeed = 3f;

    public float m_YJumpPower = 3f;

    public int m_JumpCount = 0;

    public Animator m_Animator;
    public bool m_IsJumping = false;

    public bool m_IsClimbing = false;

    public bool m_IsTouchLadder = false;

    public float m_ClimbSpeed = 5f;

    public float m_HitReconveringTime = 0;

    public VariableJoystick m_Joystick;

    private bool m_InputJump = false;

    public void Jump()
    {
        m_InputJump = true;
    }


    protected void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    protected void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        xAxis += m_Joystick.Horizontal;
        yAxis += m_Joystick.Vertical;

        var inputJump = m_InputJump;
        m_InputJump = false;

        m_HitReconveringTime -= Time.deltaTime;
        
        if(m_HitReconveringTime > 0)
        {
            ClimbingExit();

            m_Animator.SetBool("TakingDamage", true);
            return;
        }
        else
        {
            m_Animator.SetBool("TakingDamage", false);
        }

        if(m_IsTouchLadder && Mathf.Abs(yAxis) > 0.5f)
        {
            m_IsClimbing = true;
        }

        if(!m_IsClimbing)
        {
            Vector2 velocity = m_Rigidbody2D.velocity;
            velocity.x = xAxis * m_xAxisSpeed;
            m_Rigidbody2D.velocity = velocity;

            if (xAxis > 0)
                m_Sprite.localScale = new Vector3(1, 1, -1);
            else if (xAxis < 0)
                m_Sprite.localScale = new Vector3(-1, 1, 1);

            if ((Input.GetKeyDown(KeyCode.Space)
                || inputJump )
                && m_JumpCount <= 1
                )
            {
                m_Rigidbody2D.AddForce(Vector3.up * m_YJumpPower);

                m_JumpCount++;
            }

            m_IsJumping = Mathf.Abs(velocity.y) >= 0.1f ? true : false;

            m_Animator.SetBool("isJumping", m_IsJumping);
            m_Animator.SetFloat("velocity X", Mathf.Abs(xAxis));
            //var animator = GetComponent<Animator>();
            //animator.SetFloat("velocity Y", velocity.y);

            //점프 애니메이션
            m_Animator.SetFloat("velocity Y", velocity.y);

           
        }
        else
        {

            m_Rigidbody2D.constraints = 
                m_Rigidbody2D.constraints 
                | RigidbodyConstraints2D.FreezePosition;


            Vector3 movement = Vector3.zero;
            movement.x = xAxis * m_ClimbSpeed * Time.deltaTime;
            movement.y = yAxis * m_ClimbSpeed * Time.deltaTime;

            transform.position += movement;

            if(Input.GetKeyDown(KeyCode.Space)
                || inputJump)
            {
                ClimbingExit();
            }

            m_Animator.SetBool("IsClibing", m_IsClimbing);
            m_Animator.SetFloat("ClibingSpeed",
                Mathf.Abs(xAxis) + Mathf.Abs(yAxis));
            
        }
        
    }

    

    private void ClimbingExit()
    {
        m_Rigidbody2D.constraints =
            m_Rigidbody2D.constraints & ~RigidbodyConstraints2D.FreezePosition;
        m_IsClimbing = false;

        m_Animator.SetBool("IsClibing", m_IsClimbing);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            //Debug.DrawRay(contact.point, contact.normal, Color.white);
            if (contact.normal.y > 0.5f)
            {
                m_JumpCount = 0;

                if (contact.rigidbody)
                {
                    var hp = contact.rigidbody.GetComponent<HPComponent>();

                    if (hp)
                    {
                        hp.TakeDamage(10);
                    }
                }
            }
            
            else if (contact.rigidbody && contact.rigidbody.tag == "Enemy")
            {
                if(m_HitReconveringTime <= 0)
                {
                    var hp = GetComponent<HPComponent>();
                    hp.TakeDamage(10);

                    m_HitReconveringTime = 1f;
                }
                //if(m_HitReconveringTime <=0) // 피격시 무제한, 무적
               
                

                //m_Animator.SetTrigger("TakeDamage");
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {
            m_IsTouchLadder = true;
        }
        else if(collision.tag == "Item")
        {
            ItemComponent item = collision.
                GetComponent<ItemComponent>();
            if (item != null)
                item.BeAte();
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ladder")
        {
            m_IsTouchLadder = false;

            ClimbingExit();
        }
    }

    
    

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if ( collision.tag == "Ladder";

    //}
}
    


 
