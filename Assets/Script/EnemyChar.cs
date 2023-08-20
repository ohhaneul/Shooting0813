using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChar : PoolLabel, IDamage
{
    [SerializeField]
    private int currentHP;
    private int maxHP = 5;
    private SpriteRenderer sr;
    private bool isAlive;

    private Movement2D movement;

    private void Awake()
    {
        if(!TryGetComponent<SpriteRenderer>(out sr))
        {
            Debug.Log("EnemyChar.cs - Awake() - sr 참조 실패");
        }

        if (! TryGetComponent<Movement2D>(out movement))
        {
            Debug.Log("EnemyChar.cs - Awake() - movement 참조 실패");
        }
    }

    public override void InitInfo()
    {
        base.InitInfo();
        currentHP = maxHP;
        sr.color = Color.white;
        isAlive = true;

        movement.MoveTo(Vector3.down);
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        OnHit();

        if (currentHP < 1)
        {
            OnDie();
        }
    }



    //데미지 받았을때 효과
    private void OnHit()
    {
        StopCoroutine("HitColor");  
        StartCoroutine("HitColor");
    }

    private GameObject effObj;

    //사망처리
    public void OnDie()
    {
        isAlive = false;
        // todo : 사망 이펙트 처리
        effObj = ObjectPoolManager.Inst.pools[(int)ObjectType.OT_Effect_01].Pop();
        effObj.transform.position = transform.position;
        // todo : 사망 사운드 처리
        Push();
    }

    private IEnumerator HitColor()
    {
        sr.color = Color.red;
        yield return YieldInstructionCache.WaitForSeconds(0.05f);
        if (gameObject.activeSelf)
            sr.color = Color.white;
    }
}
