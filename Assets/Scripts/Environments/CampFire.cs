using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    private List<IDamagable> thingsToDamage = new List<IDamagable>();

    private void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);//반복 실행
    }

    void DealDamage()//list에 저장된 데미지들을 모두 적용한다는 의미
    {
        for (int i = 0; i < thingsToDamage.Count; i++)
        {
            thingsToDamage[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)//collision으로 하면 안된다(충돌해서 이동이 안되도록 하는 것은 안되니)
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))//TryGetComponent를 활용하여 damagable을 찾아와서 true이면 실행하도록
        {
            thingsToDamage.Add(damagable);
        }
    }
    //List가 아닌 Hash로 사용하는 것도 추천한다고 코멘트
    private void OnTriggerExit(Collider other)//충돌 종료시 호출하는 Exit
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            thingsToDamage.Remove(damagable);
        }
    }

}