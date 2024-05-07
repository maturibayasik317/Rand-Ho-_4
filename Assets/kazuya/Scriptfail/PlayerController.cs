using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float xSpeed;
    private int JumpCount;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //左右の移動処理
        MoveUpdeate();//物体の左右移動の処理
        jumpUpdeate();//ジャンプの処理
        sceneTitle();//シーンの切り替え
    }
    private void MoveUpdeate()
    {

        // X方向移動入力
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {// 右方向の移動入力
         // X方向移動速度をプラスに設定
         xSpeed = + 6.0f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
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
    void jumpUpdeate()
    {
        //2段ジャンプ禁止 //タグを作ってジャンプを禁止にする
        // ジャンプ操作
        if (JumpCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.RightShift))
            {// ジャンプ開始
                ++JumpCount;
                // ジャンプ力を計算
                float jumpPower = 10.0f;
                // ジャンプ力を適用
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
            }
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
    private void sceneTitle()
    {
        
        if (Input.GetKeyDown(KeyCode.P)||Input.GetKeyDown(KeyCode.RightShift))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("slope"))
        {
            JumpCount = 0;
        }
        
    }

}
