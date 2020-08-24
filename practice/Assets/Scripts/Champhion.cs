using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champhion : MonoBehaviour, IDamageable
{
    public void TakeDamage(DamageData damage)
    {
        Debug.LogFormat("{0}에서 챔피언은 {1}의 데미지를 받았다.",
         damage.player.name, damage.damage);
    }
}
