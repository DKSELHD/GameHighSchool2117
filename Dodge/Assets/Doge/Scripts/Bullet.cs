using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
       

    }

    public Vector3 m_Velocity;
    // Update is called once per frame

    public float m_Speed = 4f;
    public float m_DestroyCooltime = 5f;
    void Update()
    {
        Rigidbody rigidbody = /*gameObject.*/GetComponent<Rigidbody>();

        rigidbody.velocity = m_Velocity * m_Speed;

        m_DestroyCooltime -= Time.deltaTime;

        if (m_DestroyCooltime <= 0)
            Destroy(gameObject);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && other.attachedRigidbody.tag == "Player")
        {
            PlayerController player = other.attachedRigidbody.GetComponent<PlayerController>();
            player.Die();
        }
        
    }


}
