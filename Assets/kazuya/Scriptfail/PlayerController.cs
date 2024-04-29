using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float xSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //左右の移動処理
        MoveUpdeate();
    }
    private void MoveUpdeate()
    {

        // X方向移動入力
        if (Input.GetKey(KeyCode.D))
        {// 右方向の移動入力
         // X方向移動速度をプラスに設定
            xSpeed = + 6.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {// 左方向の移動入力
         // X方向移動速度をマイナスに設定
            xSpeed = -6.0f;
        }
        else
        {// 入力なし
         // X方向の移動を停止
            xSpeed = 0.0f;
        }
    }
    private void FixedUpdate()
    {
        // 移動速度ベクトルを現在値から取得
        Vector2 velocity = rigidbody2D.velocity;
        // X方向の速度を入力から決定
        velocity.x = xSpeed;

        // 計算した移動速度ベクトルをRigidbody2Dに反映
        rigidbody2D.velocity = velocity;
    }

}
