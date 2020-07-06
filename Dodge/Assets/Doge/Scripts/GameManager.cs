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

   
    private void Start() // 씬 시작시
    {
        GameStart(); // 게임 시작
    }

    private void GameStart() // 게임이 시작되면
    {
        m_IsPlaying = true; // 플레이를 활성화하고.
        m_Score = 0f; // 스코어를 0으로 변경
        m_RestartUI.gameObject.SetActive(false); // 리스타트 UI 비활성화
        m_playerController.gameObject.SetActive(true); // 플레이어 활성화

        // 불랫스포너들 활성화

        for(int i = 0; i < m_BulletSpawners.Count; i++)
        {
            m_BulletSpawners[i].gameObject.SetActive(true);
        }

        throw new NotImplementedException();
    }

    public void GameOver()
    {
        m_IsPlaying = false;
        m_RestartUI.gameObject.SetActive(true);
        m_playerController.gameObject.SetActive(false);

        for(int i = 0; i < m_BulletSpawners.Count; i++)
        {
            m_BulletSpawners[i].gameObject.SetActive(false);
        }
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        for (int i = 0; i < bullets.Length; i++)
        {
            Destroy(bullets[i].gameObject);
        }

        float topscore = PlayerPrefs.GetFloat("TopScore", 0); // Topscore 키를 가지고 최고점 가지고 옴 
        if(topscore < m_Score) //현재 내가 낸 점수가 최고로 높다면 
        {
            topscore = m_Score; // 내가 낸 점수를 최고 점수로 하슈
        }
        PlayerPrefs.SetFloat("TopScore", topscore); // TopScore에 최고점 을 저장하고 
        PlayerPrefs.Save(); // 저장

        m_RestartUI.text
        = string.Format("게임오버\n최고점 : {0}\n다시 시작하려면 R버튼 누르셈요.", topscore);
          
                
    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsPlaying)
        {
            m_Score = m_Score + Time.deltaTime;
            m_ScrollUi.text = string.Format("Score : {0}", m_Score);
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                GameStart();
            }
        }
        
    }
}
