using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerolle_dneon : MonoBehaviour
{

    
    // Start is called before the first frame update

    public Rigidbody m_Rigidbody;

    public float m_Speed = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
    

        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(xAxis, 0, zAxis).normalized * m_Speed;
        Vector3 movement = velocity * Time.deltaTime;
        transform.position = transform.position + movement;

    
        m_Rigidbody.velocity = velocity;

    }

    public void Die()
    {
        Debug.Log("사망");
        gameObject.SetActive(false);



    }

}
