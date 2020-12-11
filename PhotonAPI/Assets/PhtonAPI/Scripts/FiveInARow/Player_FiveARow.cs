using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_FiveARow : MonoBehaviour
{
    public Side m_Side;
    private LevelScript_FiveInARow m_LevelScript;

    public void Awake()
    {
        m_LevelScript = FindObjectOfType<LevelScript_FiveInARow>();


    }

    public void Update()
    { 
        if(Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {

                //카메라 오브젝트를 선택하려고 할 때에 
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
                {
                    if (hit.collider != null)
                    {
                        var point = hit.collider.GetComponent<Point>();
                        if (point != null)
                        {
                            m_LevelScript.LetGoOfTheHorse(m_Side, point.m_Point);
                        }
                    }
                }
            }
        }
        
        
    }
}
