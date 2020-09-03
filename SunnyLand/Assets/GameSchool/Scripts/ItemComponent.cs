using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemComponent : MonoBehaviour
{
    public UnityEvent m_BeAteEvent;

    public virtual void BeAte()
    {
        m_BeAteEvent.Invoke();
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
