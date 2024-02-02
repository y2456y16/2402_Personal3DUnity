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
        InvokeRepeating("DealDamage", 0, damageRate);//�ݺ� ����
    }

    void DealDamage()//list�� ����� ���������� ��� �����Ѵٴ� �ǹ�
    {
        for (int i = 0; i < thingsToDamage.Count; i++)
        {
            thingsToDamage[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)//collision���� �ϸ� �ȵȴ�(�浹�ؼ� �̵��� �ȵǵ��� �ϴ� ���� �ȵǴ�)
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))//TryGetComponent�� Ȱ���Ͽ� damagable�� ã�ƿͼ� true�̸� �����ϵ���
        {
            thingsToDamage.Add(damagable);
        }
    }
    //List�� �ƴ� Hash�� ����ϴ� �͵� ��õ�Ѵٰ� �ڸ�Ʈ
    private void OnTriggerExit(Collider other)//�浹 ����� ȣ���ϴ� Exit
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            thingsToDamage.Remove(damagable);
        }
    }

}