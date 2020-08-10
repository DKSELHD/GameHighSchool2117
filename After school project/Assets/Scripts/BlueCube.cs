using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueCube : MonoBehaviour
{

    public float m_Speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * m_Speed * Time.deltaTime;
        
    }

    public void OnPointDownEvent()
    {
        GameManager.Instance.DamageLife();
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "plane")
        {
            Destroy(gameObject);
            GameManager.Instance.AddScore();
        }
    }
}
