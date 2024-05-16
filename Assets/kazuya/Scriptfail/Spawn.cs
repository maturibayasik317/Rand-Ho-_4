using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int index = 0;
    public GameObject[] Player;
    public new GameObject gameObject;
    [SerializeField] GameObject PlayerObj;
    private Vector2 player;
    squareController squareController;
    void Start()
    {
        gameObject = Instantiate(Player[index]);
        squareController = GetComponent<squareController>();
    }

    void Update()
    {
        gameObject = squareController.childObject;
        PlayerObj = gameObject;
        Debug.Log($"{PlayerObj.transform.position}");
        //Debug.Log($"{sample.GetSetProperty}");
        //キーが押されたときにオブジェクトの種類を変える
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            player = PlayerObj.transform.position;
            Destroy(gameObject);
            ++index;
            if(index == Player.Length) { index = 0; }
            gameObject = Instantiate(Player[index],player,Quaternion.identity);
        }

    }
}
