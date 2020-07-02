using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationBulletSpawner : MonoBehaviour
{

    public GameObject m_Bullet;


    public float m_RoatitonSpeed = 60f;
    public float m_AttackInterval = 1f;
    private float m_AttackCooltime = 0f;


    void Update()
    {

        // 공격 선쿨타임
        m_AttackCooltime += Time.deltaTime;
        if (m_AttackCooltime >= m_AttackInterval)
        {
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            // 공격 선쿨타임 초기화.
            m_AttackCooltime = 0;
        }

      
        

        transform.Rotate(0, m_RoatitonSpeed * Time.deltaTime, 0);
    }
}

