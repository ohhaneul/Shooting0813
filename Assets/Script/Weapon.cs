using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������Ÿ���� ��������, �߻� �۾�
public class Weapon : MonoBehaviour
{
    private bool isInit = false;
    private GameObject projectilePrefab;
    private float attackRate;


    public void InitWeapon(GameObject newprefab, float newRate)
    {
        isInit = true;

        projectilePrefab = newprefab;
        attackRate = newRate;
    }

    private bool isFiring;
    public bool FIRING
    {
        set
        {
            isFiring = value;

            if(isInit)
            {
                if(isFiring)
                {
                    //����߽�~!
                    StartCoroutine("TryAttack");    //StartCoroutine(TryAttack());�ε� �� �� ���� ������ �۸� �Ʒ�ó�� ���� ���� ���� �ٲ�ߵ�

                }
                else
                {
                    //�������
                    StopCoroutine("TryAttack");
                }
            }
        }
        get // get => isFiring; �̰Ŷ� �Ȱ�����
        {
            return isFiring;
        }
 
    }
    private GameObject obj;

    private IEnumerator TryAttack()
    {
        while (true)
        {
            //������Ÿ�� �߻�
            // obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // obj.GetComponent<Movement2D>().MoveTo(Vector2.up);

            obj = ObjectPoolManager.Inst.pools[(int)ObjectType.OT_Projectile_01].Pop();
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
            obj.GetComponent<Movement2D>().MoveTo(Vector3.up);


            //yield return new WaitForSeconds(attackRate);    //attackRate��ŭ ���
            yield return YieldInstructionCache.WaitForSeconds(attackRate);
        }
    }


}
