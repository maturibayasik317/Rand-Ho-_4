using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwon : MonoBehaviour
{
    public int index = 0;
    public GameObject[] Player;
    public new GameObject gameObject;
    Sample sample = new Sample();
    public Vector2 PlayerObj;
    void Start()
    {
        PlayerObj = transform.position;
        gameObject =Instantiate(Player[index]);
    }

    void Update()
    {
        PlayerObj = sample.GetSetProperty;
        Debug.Log($"{sample.GetSetProperty}");
        //キーが押されたときにオブジェクトの種類を変える
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            Destroy(gameObject);
            ++index;
            if(index == Player.Length) { index = 0; }
            gameObject = Instantiate(Player[index],PlayerObj,Quaternion.identity);
        }

    }
}
