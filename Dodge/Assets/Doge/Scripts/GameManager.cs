using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text m_ScrollUi;
    public Text m_RestartUI;

    public PlayerController m_playerController;
    public List<GameObject> m_BulletSpawners;

    public bool m_IsPlaying;
    public float m_Score;

    
    private void Start()
    {
        GameStart();
    }

    private void GameStart()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsPlaying)
        {
            m_Score = m_Score + Time.deltaTime;
            m_ScrollUi.text = string.Format("Score : [0]", m_Score);
        }
        
    }
}
