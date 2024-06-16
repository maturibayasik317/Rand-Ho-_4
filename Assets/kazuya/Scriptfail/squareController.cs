using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SquareController : MonoBehaviour
{
    private int index = 0;
    [SerializeField] public GameObject[] Player;//生成元となるオブジェクト
    public GameObject childObject;// 入れ替え先となるオブジェクト
    [SerializeField] GameObject Square;//操作するオブジェクト
    private Vector2 player;//プレイヤーの座標を保存する
    Spawn spawn;
    private GameObject wallcht;
    Wallcht wch;
    void Start()
    {
        spawn = GetComponent<Spawn>();
        wallcht = GameObject.Find("Wallcht");
        wch = wallcht.GetComponent<Wallcht>();
    }

    void Update()
    {
        childObject = spawn.gameObject;//
        Square = childObject;
        //指定のキーが押されたとき
        if (Input.GetKeyDown(KeyCode.Q))
        {//四角の形であれば
            if (GameObject.Find("Player(Clone)") || GameObject.Find("Player1(Clone)"))
            {
                //プレイヤーの座標を保存
                player = Square.transform.position;
                Destroy(Square);//今あるオブジェクトを削除
                ++index;//カウントを追加
                if (index == Player.Length) { index = 0; }
                //新しいオブジェクトを前のオブジェクト座標に生成
                childObject = Instantiate(Player[index], player, Quaternion.identity);
            } 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            if (spawn.index == 0 && wch.selection == 0)
            {
                spawn.Alive = true;
            }
            else
            { 
                spawn.Alive = false;
            }
        }
        
    }
}
