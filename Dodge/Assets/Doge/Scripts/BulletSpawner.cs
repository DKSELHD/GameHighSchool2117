using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject m_Bullet;

   
    public float m_RoatitonSpeed = 60f;
    public float m_AttackInterval = 1f;
    private float m_AttackCooltime = 0f;
    

    // Update is called once per frame
    void Update()
    {

        // 공격 선쿨타임
        m_AttackCooltime += Time.deltaTime;
        if(m_AttackCooltime >= m_AttackInterval)
        {
            GameObject bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            // 공격 선쿨타임 초기화.
            m_AttackCooltime = 0;
        }

        //GameObject.Find("Player"); // 너무 무거워서 자주 안사용한다. 게임 오브젝트의 이름
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // 이것을 주로 자주 사용한다. Player
        //GameObject.FindObjectsOfType<PlayerController>(); // 혹은 이것을 주로 쓴다. s가 붙였을 때는 한개가 아닌 여러 게임 오브젝트를 찾는다. 
        
        if(player != null)
        {
            Vector3 attacketPoint = player.transform.position;
            attacketPoint.y = transform.position.y;
            transform.LookAt(attacketPoint);
        }
        
        //transform.Rotate(0, m_RoatitonSpeed * Time.deltaTime, 0);
    }
}
