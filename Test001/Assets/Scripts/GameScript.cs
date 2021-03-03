using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    float speed = 50.9f;
    public Text m_Hello;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Update_Move();
        Update_Rotate();
        Update_Scale();


    }

    void Update_Move()
    {
        float keyHorizontal = Input.GetAxis("Horizontal");
        float keyVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.W))
        {
            m_Hello.transform.position += new Vector3(0, 5, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            m_Hello.transform.position += new Vector3(0, -5, 0);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            m_Hello.transform.position += new Vector3(-5, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            m_Hello.transform.position += new Vector3(5, 0, 0);
        }

        //transform.position += (Vector3.right * speed
        //    * Time.smoothDeltaTime * keyHorizontal, Space.World);
        //transform.Translate(Vector3.up * speed
        //    * Time.smoothDeltaTime * keyVertical, Space.World);


    }

    void Update_Rotate()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            m_Hello.transform.eulerAngles += new Vector3(0, 0, 5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            m_Hello.transform.eulerAngles += new Vector3(0, 0, -5);
        }
    }

    void Update_Scale()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_Hello.transform.localScale += new Vector3(2, 2, 1);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            m_Hello.transform.localScale -= new Vector3(2, 2, 1);
        }
    }
}
