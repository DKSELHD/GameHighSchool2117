using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour/*, IPointerDownHandler*/
{ 
    //public void OnPointerDown(PointerEventData eventData)
    //{

    //    Debug.Log("오브젝트를 눌렀디");
        
    //}

    public void OnPointerDownEvenr(BaseEventData eventData)
    {

        Debug.Log("오브젝트를 눌렀디");

    }

}
