using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwon : MonoBehaviour
{
    public int index = 0;
    public GameObject[] Player;
    public new GameObject gameObject;

    public Vector2 PlayerObj;
    void Start()
    {
        
        gameObject =Instantiate(Player[index]);
    }

    void Update()
    {
        PlayerObj = new Vector2(transform.position.x, transform.position.y);
        //�L�[�������ꂽ�Ƃ��ɃI�u�W�F�N�g�̎�ނ�ς���
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            Destroy(gameObject);
            ++index;
            if(index == Player.Length) { index = 0; }
            gameObject = Instantiate(Player[index]);
        }

    }
}
