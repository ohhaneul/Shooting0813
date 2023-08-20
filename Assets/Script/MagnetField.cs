using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetField : MonoBehaviour
{
    private CircleCollider2D col;

    public float MagnetRadius
    {
        set => col.radius = value;
    }

    private void Awake()
    {
        if (!TryGetComponent<CircleCollider2D>(out col))
            Debug.Log("MagnetField.cs - Awake() - col 참조실패");
        else
        {
            col.isTrigger = true;
            col.radius = 2f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item") && collision.TryGetComponent<Dropitem>(out Dropitem item))
        {
            item.SetTarget(transform.parent.gameObject);
        }
    }
}
