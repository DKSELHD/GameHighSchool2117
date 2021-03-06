﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//추가
using Photon.Pun;

//수정
public class Point : MonoBehaviourPun
{
    private LevelScript_FiveInARow m_LevelScript;
    public Vector2Int m_Point;
    //수정
    public Side m_Side;

    public void Awake()
    {
        m_LevelScript = FindObjectOfType
            <LevelScript_FiveInARow>();
    }

    public void ClickEvent()
    {
        Side side = Side.Other;

        if (m_LevelScript.m_Turn == Turn.Red)
        {
            side = Side.Red;
        }
        else if (m_LevelScript.m_Turn == Turn.Blue)
        {
            side = Side.Blue;
        }

        //수정
        //m_LevelScript.LetGoOfTheHorse(side, m_Point);
        m_LevelScript.photonView.RPC("LetGoOfTheHorse", RpcTarget.All, (int)side,
            m_Point.x, m_Point.y);
    }

    //추가
    [PunRPC]
    public void SetColor(float r, float g, float b)
    {
        var renderer = GetComponent<Renderer>();
        renderer.material.color = new Color(r, g, b);
    }
}
