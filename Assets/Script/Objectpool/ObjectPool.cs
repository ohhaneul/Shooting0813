using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject poolObj; //풀로 관리할 대상 오브젝트
    [SerializeField]
    private int allocateCount;  //한 번 생성할 때 몇개를 생성할지

    private Stack<PoolLabel> poolStack = new Stack<PoolLabel>();

    private int objMaxCount;    //풀을 통해 만들어낸 대상 객체의 총합
    private int objActiveCount; //풀의 오브젝트 중 활성화되어 사용중인 오브젝트 개수

    private void Awake()
    {
        objMaxCount = 0;
        objActiveCount = 0;
        Allocate();
    }

    private void Allocate()
    {
        for (int i = 0; i < allocateCount; i++)
        {
            GameObject allocateObj = Instantiate(poolObj, transform);   //자신의 자식 오브젝트로 생성
            allocateObj.GetComponent<PoolLabel>().Create(this);
            poolStack.Push(allocateObj.GetComponent<PoolLabel>());
            allocateObj.name = allocateObj.name + '_' + objMaxCount;
            objMaxCount++;
        }
    }

    public GameObject Pop()
    {
        if (objActiveCount >= objMaxCount)
            Allocate();

        PoolLabel returnObj = poolStack.Pop();
        returnObj.gameObject.SetActive(true);
        returnObj.InitInfo();
        objActiveCount++;
        return returnObj.gameObject;
    }

    public void Push(PoolLabel obj)
    {
        if(obj.gameObject.activeSelf)
        {
            obj.gameObject.SetActive(false);
            poolStack.Push(obj);
            objActiveCount--;
        }
    }
}
