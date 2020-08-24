using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinArm : MonoBehaviour
{
    public Transform m_Target;
    public float smoothTime = 0.3F;
    public Vector3 velocity = Vector3.zero;

    public Vector3 m_offset;

    void Start()
    {
        m_offset = transform.position = m_Target.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.transform.position + m_offset;
        transform.position = m_Target.transform.position + m_offset;
    }
}
