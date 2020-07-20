using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float m_Speed = 10f;
    // Update is called once per frame

    private void Update()
    {


        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        Vector2 inputValue = new Vector2(xAxis, yAxis);


        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    inputValue.x = -1;
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    inputValue.x = 1;
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    inputValue.y = - 1;
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    inputValue.y = 1;
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{

        //}

        Vector3 movement = inputValue * m_Speed * Time.deltaTime;
        transform.position += movement;
    }
    //void Update()
    //{



    //    Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

    //    float yAxis = Input.GetAxis("Vertical");

    //    rigidbody.AddForce(new Vector3(yAxis, 0) * m_Speed);
    //}
}