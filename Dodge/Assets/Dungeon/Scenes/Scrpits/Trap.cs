using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 안에 어떤 Collinder other가 들어갔을 때");

        if(other.attachedRigidbody != null)
        {
            var player = other.attachedRigidbody.GetComponent<Playerolle_dneon>();
                if (player != null)
                player.Die();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("트리거 안에 어떤 collider나 trigger가 나왔을 때");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("트리거 안에 어떤 collider나 trigger가 들어가 가만히 있을 때");
    }
}
