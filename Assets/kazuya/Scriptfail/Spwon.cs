using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwon : MonoBehaviour
{
    public int index = 0;
    public GameObject[] Player;
    private int o_max = 0;
    void Start()
    {
    }

    private void Instantiate(GameObject gameObject, Vector2 vector2)
    {
    }

    void Update()
    {
        //キーが押されたときにオブジェクトの種類を変える
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            Destroy(gameObject);
            ++index;
            Instantiate(Player[index], new Vector2(transform.position.x, transform.position.y));
        }

    }
}
