using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingMonster: MonoBehaviour
{
    public int m_ChamNum = 1;
    public int m_MinNum = 1;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            var cham = Resources.Load(string.Format("챔피언{0}", m_ChamNum));
            var chamGobj = GameObject.Instantiate(cham) as GameObject;

            m_ChamNum++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var minion = Resources.Load(string.Format("미니언{0}", m_MinNum));
            var minonGobj = GameObject.Instantiate(minion) as GameObject;

            m_MinNum++;
        }
    }
}
