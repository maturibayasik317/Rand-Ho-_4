using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public int index = 0;//生成される順番
    private float DeatTime;
    public GameObject[] Player;//プレイヤーのインスタンス
    public new GameObject gameObject;//新しく生成されるプレイたーオブジェクト
    [SerializeField] GameObject PlayerObj;//動いているプレイヤーオブジェクト
    private  Vector2 player;//現在のプレイヤー座標
    public Vector2 dfPlayer = new Vector2();//デフォルトの生成位置
    public bool Alive = true;//生存判定
    SquareController squareController;
    public static Vector2 CheckPoint = new Vector2();//プレイヤーのチェックポイントの座標
    public bool CheckPlayer = false;//プレイヤーのセーブを判定
    public bool CHG = true;

    void Start()
    {
        //中間座標が設定されていればその座標で生成
        if(CheckPoint != Vector2.zero)
        {
            gameObject = Instantiate(Player[0], CheckPoint, Quaternion.identity);
        }
        else//それ以外なら初期位置で生成
        {
            gameObject = Instantiate(Player[0], dfPlayer, Quaternion.identity);
        }
        
        squareController = GetComponent<SquareController>();
    }

    void Update()
    {
        
            gameObject = squareController.childObject;
            PlayerObj = gameObject;
        if (Alive)
        {
            if (CHG)
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
                //プレイヤーがチェックポイントをふれたときその座標を記録する
                if (CheckPlayer == true)
                {
                    CheckPoint = PlayerObj.transform.position;
                    CheckPlayer = false;
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    SceneManager.LoadScene("sss", LoadSceneMode.Single);
                }
            }
        }
        else
        {
            //プレイヤーが死亡判定になったときに一定時間待って、
            ++DeatTime;
            if (DeatTime == 200.0f)
            {//プレイヤーを消してゲームオーバーシーンへ
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
        
    }
}
