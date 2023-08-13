using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;

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
