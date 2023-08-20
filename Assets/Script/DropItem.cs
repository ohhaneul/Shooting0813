using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))] // = 해당 오브젝트에 해당 컴포넌트가 없으면 신규로 추가
[RequireComponent(typeof(CircleCollider2D))]

public class Dropitem : PoolLabel
{
    private Rigidbody2D rig;
    private CircleCollider2D col;

    private void Awake()
    {
        if (!TryGetComponent<Rigidbody2D>(out rig))
            Debug.Log("DropItem.cs - Awake() - col 참조실패 ");
        else
        {
            rig.gravityScale = 1f;
        }

        if (!TryGetComponent<CircleCollider2D>(out col))
            Debug.Log("DropItem.cs - Awake() - col 참조실패");
        else
        {
            col.isTrigger = true;
            col.radius = 0.5f;
        }
    }

    private Vector2 dropDir;

    public override void InitInfo()
    {
        base.InitInfo();
        dropDir.x = Random.Range(-1f, 1f);
        dropDir.y = Random.Range(3f, 5f);
        rig.velocity = dropDir;
        rig.gravityScale = 0;
        isSetTarget = false;
    }

    private bool isSetTarget;
    private GameObject moveTargetObj;
    private float moveTime;

    public void SetTarget(GameObject newTarget)
    {
        moveTargetObj = newTarget;
        isSetTarget = true;
        moveTime = 0f;

        rig.gravityScale = 0;
        rig.velocity = Vector2.zero;

    }

    private void FixedUpdate()
    {
        
    }


    private void Update()
    {
        moveTime += Time.deltaTime;

        if (isSetTarget && moveTargetObj.activeSelf)
        {
            transform.position = Vector3.Lerp(transform.position, moveTargetObj.transform.position, moveTime / 2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //todo : gameManager 스코어 증가 처리
            Push();
        }
    }
}

