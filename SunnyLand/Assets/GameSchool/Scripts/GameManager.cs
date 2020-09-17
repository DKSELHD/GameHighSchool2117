using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public List<ItemComponent> m_Item
        = new List<ItemComponent>();

    public bool m_IsPlaying;
    public bool m_IsGameOver;


    public GameObject m_Player;
    public Transform m_StartPoint;

    public GameObject m_GameClearUI;
    public GameObject m_GameOverUI;

    // 추가 
    public Transform m_Target;

    public JointArm m_JointArm;
    public VariableJoystick m_Joystick;

    public UnityEngine.UI.Button m_JumpButton;

    // 수정
    public void GameOver()
    {
        m_IsGameOver = true;
        m_GameOverUI.SetActive(true);
  //      
  //      UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    
    public void GameStart()
    {
        var playerInstance =  Instantiate(m_Player,
            m_StartPoint.position, m_StartPoint.rotation);

        // 중요
        var hpComponent = playerInstance.GetComponent<HPComponent>();
        hpComponent.m_OnDie.AddListener(GameOver);

        m_JointArm.m_Target = playerInstance.transform;

        var playerController = playerInstance.
            GetComponent<PlayController>();
        playerController.m_Joystick = m_Joystick;

        m_JumpButton.onClick.AddListener(
            playerController.Jump);

        Debug.Log("GameStart");
    }
    public void Start()
    {
        m_Item.AddRange(FindObjectsOfType<ItemComponent>());
        m_IsPlaying = true;

        GameStart();
    }

    public void GameClear()
    {

        m_GameClearUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("GameClear");
    }


    public void Update()
    {

        if (m_IsGameOver) {
            if (Input.GetKeyDown(KeyCode.R)) {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
       
        var result = true;
        foreach (var Item in m_Item)
        {
            if (Item != null)
            {
                result = false;
            }
        }

        if (result)
        {
            m_IsPlaying = false;
            GameClear();
        }
    }
   
   

   


}
