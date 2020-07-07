using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector3 m_Velocity;
    // Update is called once per frame

    
    void Update()
    {
        
        
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
