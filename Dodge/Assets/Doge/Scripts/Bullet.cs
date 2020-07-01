using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public float m_Speed = 6f;
    public float m_DestroyCooltime = 5f;
    void Update()
    {
        Rigidbody rigidbody = /*gameObject.*/GetComponent<Rigidbody>();

        rigidbody.AddForce(transform.forward * m_Speed);

        m_DestroyCooltime -= Time.deltaTime;

        if (m_DestroyCooltime <= 0)
            gameObject.SetActive(false);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.tag == "Player")
        {
            PlayerController player = other.attachedRigidbody.GetComponent<PlayerController>();
            player.Die();
        }
        
    }


}
