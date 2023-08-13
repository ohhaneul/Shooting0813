using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isInit = false;
    private bool isMove;
    public bool MoveInput
    {
        set
        {
            isMove = value;
            if (isMove)
                weapon.FIRING = true;
            else
                weapon.FIRING = false;
        }
    }

    [SerializeField]
    private Vector2 clampMin;
    [SerializeField]
    private Vector2 clampMax;


    private Weapon weapon;
    [SerializeField]
    private GameObject projectilobj;


    private void Awake()
    {
        //���Ŀ� �ۼ�
        Invoke("InitPlayer", 2.0f);
        if (!TryGetComponent<Weapon>(out weapon))
            Debug.Log("PlayerControll.cs - Awake() - weapon ���� ����");
    }


    public void InitPlayer()
    {
        isInit = true;

        if(weapon == null)
        {
            if (TryGetComponent<Weapon>(out weapon))
            {
                Debug.Log("PlayerControll.cs - InitPlayer() - weapon ���� ����");
                weapon = gameObject.AddComponent<Weapon>();
            }

        }
        weapon.InitWeapon(projectilobj, 0.02f);
    }



    private Vector3 pos;

    private void Update()
    {
        if(isMove && isInit)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.x = Mathf.Clamp(pos.x, clampMin.x, clampMax.x);
            pos.y = Mathf.Clamp(pos.y, clampMin.y, clampMax.y);
            pos.z = transform.position.z;
            transform.position = pos;
        }
    }
}
