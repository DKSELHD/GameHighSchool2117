using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    float object_speed = 40.4f;
    public Object m_Cube;

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

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(1, 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(-1, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(0, 0, 1));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(0, 0, -1));
        }
    }

    void Update_Rotate()
    {
        if (Input.GetKey(KeyCode.T))
        {
            transform.eulerAngles += new Vector3(5, 0, 0);
        }
        if (Input.GetKey(KeyCode.Y))
        {
            transform.eulerAngles -= new Vector3(5, 0, 0);
        }
    }

    void Update_Scale()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.localScale += new Vector3(2, 2, 2);
        }
        if(Input.GetKey(KeyCode.E))
        {
            transform.localScale -= new Vector3(2, 2, 2);
        }
    }
}
