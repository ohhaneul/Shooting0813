using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : PoolLabel
{
    [SerializeField]
    private string targetTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            collision.GetComponent<IDamage>().TakeDamage(1);    //공격력 1
            Push(); //닿으면 공격 그 사라짐
        }

        //collision.GetComponent<EnemyChar>();
        //collision.GetComponent<PlayerController>();

    }
}
