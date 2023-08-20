using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))] // = 해당 오브젝트에 해당 컴포넌트가 없으면 신규로 추가
[RequireComponent(typeof(CircleCollider2D))]


public class Meteorite : MonoBehaviour
{
    private Rigidbody2D rig;
    private CircleCollider2D col;
 

    private void Awake()
    {
        if (!TryGetComponent<Rigidbody2D>(out rig))
            Debug.Log("Meteorite.cs - Awake() - rig 참조실패");
        else
        {
            rig.gravityScale = 2f;
        }

        if (!TryGetComponent<CircleCollider2D>(out col))
            Debug.Log("Meteorite.cs - Awake() - col 참조실패");
        else
        {
            col.isTrigger = true;
            col.radius = 0.125f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plater") && collision.TryGetComponent<IDamage>(out IDamage damage))
        {
            damage.TakeDamage(999);
        }
    }
}
