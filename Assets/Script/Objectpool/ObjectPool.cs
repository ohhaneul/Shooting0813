using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject poolObj; //Ǯ�� ������ ��� ������Ʈ
    [SerializeField]
    private int allocateCount;  //�� �� ������ �� ��� ��������

    private Stack<PoolLabel> poolStack = new Stack<PoolLabel>();

    private int objMaxCount;    //Ǯ�� ���� ���� ��� ��ü�� ����
    private int objActiveCount; //Ǯ�� ������Ʈ �� Ȱ��ȭ�Ǿ� ������� ������Ʈ ����

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
            GameObject allocateObj = Instantiate(poolObj, transform);   //�ڽ��� �ڽ� ������Ʈ�� ����
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
