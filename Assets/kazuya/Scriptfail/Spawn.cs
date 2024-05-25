using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int index = 0;
    private float DeatTime = 0.0f;
    public GameObject[] Player;
    public new GameObject gameObject;
    [SerializeField] GameObject PlayerObj;
    private Vector2 player;
    public bool Alive = true;
    SquareController squareController;

    void Start()
    {
        gameObject = Instantiate(Player[index]);
        squareController = GetComponent<SquareController>();
    }

    void Update()
    {
        
            gameObject = squareController.childObject;
            PlayerObj = gameObject;
       if(Alive )
        {
            //キーが押されたときにオブジェクトの種類を変える
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                player = PlayerObj.transform.position;
                Destroy(gameObject);
                ++index;
                if (index == Player.Length) { index = 0; }
                gameObject = Instantiate(Player[index], player, Quaternion.identity);
            }
        }
        else
        {
            ++DeatTime;
            if(DeatTime == 100.0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
