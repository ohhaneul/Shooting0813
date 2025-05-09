using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0f;
    public float MoveSpeed
    {
        set => moveSpeed = value;
    }
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    public Vector3 MoveDir
    {
        set => moveDirection = value;
    }

    private bool isInit = false;


    private void Update()
    {
        if (isInit)
        {
            transform.position += moveSpeed * Time.deltaTime * moveDirection;
        }
    }

    public void MoveTo(Vector3 newDir)
    {
        isInit = true;
        moveDirection = newDir;
    }
}
