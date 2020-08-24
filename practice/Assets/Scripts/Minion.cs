using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour, IDamageable
{
    public void TakeDamage(DamageData damage)
    {
        Debug.LogFormat("{0}에게 죽었다.", damage.player.name);
        Destroy(gameObject);
    }
}
