using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HPComponent : MonoBehaviour
{
    public UnityEvent m_OnTakeDamage;
    public UnityEvent m_OnReal;
    public UnityEvent m_OnDie;

    public virtual void TakeDamage(int damage)
    {
        m_OnTakeDamage.Invoke();
    }

    public virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
}
