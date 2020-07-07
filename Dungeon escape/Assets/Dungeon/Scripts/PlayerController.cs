using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public float m_Speed = 3f;
    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        rigidbody.AddForce(new Vector3(xAxis, 0, yAxis) * m_Speed);
    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log("사망");
    }
}
