using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<ItemComponent> m_Item
        = new List<ItemComponent>();

    public bool m_IsPlaying;

    public GameObject m_GameClearUI;

   
    public void Start()
    {
        m_Item.AddRange(FindObjectsOfType<ItemComponent>());
        m_IsPlaying = true;
    }

    public void GameClear()
    {

        m_GameClearUI.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("GameClear");
    }


    public void Update()
    {

        if (!m_IsPlaying) return;

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
    public void GameOver()
    {
        Debug.Log("GameOver");
    }

    public void GameStart()
    {
        Debug.Log("GameStart");

    }

   


}
