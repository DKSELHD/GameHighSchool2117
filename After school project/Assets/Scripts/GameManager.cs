using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int m_Lifecount = 3;
    public int m_Scroe = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore()
    {
        m_Scroe++;
    }

    public void DamageLife()
    {
        m_Lifecount--;
        if(m_Lifecount <= 0)
        {
            //GameOver;
        }
    }
}
