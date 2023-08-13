using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController player;

    private GameObject obj;
    private void Awake()
    {
        obj = GameObject.Find("Player");
        if (obj != null)
        {
            if (!GameObject.Find("Player").TryGetComponent<PlayerController>(out player))
                Debug.Log("InputManager.cs - Awake() - player ���� ����.");
        }
        else
            Debug.Log("InputManager.cs - Awake() - player ������Ʈ Ž�� ����.");
    }

    private void OnMouseDown()
    {
        player.MoveInput = true;
    }
    private void OnMouseUp()
    {
        player.MoveInput = false;
    }
}
