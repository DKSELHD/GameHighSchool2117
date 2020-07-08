using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap2 : MonoBehaviour
{
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision에 어떤 collision과 충돌이 끝났을 때");

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision에 어떤 collisio과 충돌이 일어나고 있을 때");
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.rigidbody != null)
        {
            var player = collision.rigidbody
                .GetComponent<Playerolle_dneon>();
            if (player != null)
                player.Die();
        }

        Debug.Log("Collision이 어떤 collision과 충돌이 일어 났을 때");
    }
}
