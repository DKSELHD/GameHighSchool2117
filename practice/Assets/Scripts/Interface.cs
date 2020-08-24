using UnityEngine;

public struct DamageData
{
    public float damage;
    public object[] buff;
    public GameObject player;


}

public interface IDamageable
{
    void TakeDamage(DamageData damage);
    
}



// IDamageable을 상속한 컴포넌트 2개 (챔피언, 미니언

//public class xxx : monobehavior, idamageable



