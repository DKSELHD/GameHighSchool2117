using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        var damagable = other.GetComponent<IDamageable>();

        if (damagable == null)
            return;

        DamageData damageData = new DamageData();
        damageData.damage = 10f;
        damageData.buff = null;
        damageData.player = gameObject;

        damagable.TakeDamage(damageData);
    }

}
