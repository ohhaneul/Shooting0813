using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 프로젝타일을 생성관리, 발사 작업
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
                    //무기발싸~!
                    StartCoroutine("TryAttack");    //StartCoroutine(TryAttack());로도 할 수 있음 하지만 글면 아래처럼 간단 ㄴㄴ 많이 바꿔야됨

                }
                else
                {
                    //사격중지
                    StopCoroutine("TryAttack");
                }
            }
        }
        get // get => isFiring; 이거랑 똑같은거
        {
            return isFiring;
        }
 
    }
    private GameObject obj;

    private IEnumerator TryAttack()
    {
        while (true)
        {
            //프로젝타일 발사
            // obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            // obj.GetComponent<Movement2D>().MoveTo(Vector2.up);

            obj = ObjectPoolManager.Inst.pools[(int)ObjectType.OT_Projectile_01].Pop();
            obj.transform.position = transform.position;
            obj.transform.rotation = Quaternion.identity;
            obj.GetComponent<Movement2D>().MoveTo(Vector3.up);


            //yield return new WaitForSeconds(attackRate);    //attackRate만큼 대기
            yield return YieldInstructionCache.WaitForSeconds(attackRate);
        }
    }


}
