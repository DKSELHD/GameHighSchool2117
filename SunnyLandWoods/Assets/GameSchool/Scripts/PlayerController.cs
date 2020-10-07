using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D m_Rigidbody2D;
    public float m_MovementSpeed = 5f;
    public float m_JumpSpeed = 10f;

    private void FixedUpdate()
    {
        var xAxis = Input.GetAxis("Horizontal");
        var yAxis = Input.GetAxis("Vertical");

        Vector2 velocity = m_Rigidbody2D.velocity;
        velocity.x = xAxis * m_MovementSpeed;

        if(yAxis > 0.1f)
        {
            velocity.y = m_JumpSpeed;
        }

        m_Rigidbody2D.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       foreach (var contact in collision.contacts)
        {
            if(contact.normal.y > -0.8f)
            {
                Vector2 velocity = m_Rigidbody2D.velocity;

                if (velocity.y > 0)
                    velocity.y = 0;

                m_Rigidbody2D.velocity = velocity;

            }
        }
    }


}
