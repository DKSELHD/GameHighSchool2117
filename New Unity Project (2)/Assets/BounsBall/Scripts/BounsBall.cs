using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounsBall : MonoBehaviour
{
    public Rigidbody m_Rigidbody;
    public float m_Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var xAxis = Input.GetAxis("Horizontal");
        var zAxis = Input.GetAxis("Vertical");

        if(xAxis == 0 && zAxis == 0)
        {
            var velocity = m_Rigidbody.velocity;

            float breakFactor = 0.8f;
            velocity.x
                = velocity.x
                * (1f - breakFactor * Time.deltaTime);
            velocity.z
                = velocity.z
                * (1f - breakFactor * Time.deltaTime);

            m_Rigidbody.velocity = velocity;
        }
        else
        {
            var velocity = new Vector3(xAxis, 0, zAxis);
            velocity = velocity.normalized;
            velocity *= m_Speed;
            velocity.y = m_Rigidbody.velocity.y;

            m_Rigidbody.velocity = velocity;
        }
    }
}
