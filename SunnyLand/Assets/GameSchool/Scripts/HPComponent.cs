using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPComponent : MonoBehaviour
{
    public int m_Hp = 10;
    public UnityEvent m_OnTakeDamage;
    public UnityEvent m_OnReal;
    public UnityEvent m_OnDie;

    public virtual void TakeDamage(int damage)
    {
        m_OnTakeDamage.Invoke();

        m_Hp -= damage;
        if(m_Hp <= 0)
        {
            m_OnDie.Invoke();
        }
    }

    public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
}
