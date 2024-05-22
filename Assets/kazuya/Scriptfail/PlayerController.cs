using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Controls;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    [SerializeField]public float xSpeed = 6;//プレイヤーの速度
    [SerializeField] public float jumpPower;//プレイヤーのジャンプの高さ
    [SerializeField]public int JumpCount = 1;//ジャンプできる回数
    [SerializeField] public float PlayerObject;
    public bool prri = false;//プレイヤーが止まっているかを確認している
    Sample sample = new Sample();
   // public bool Alive = true;
    public ButtonControl left { get; private set; }
    public int GravitySensor { get; private set; }
    private GameObject characterChg;
    Spawn spawn;

    void Start()
    {
        characterChg = GameObject.Find("CharacterChg");
        spawn = characterChg.GetComponent<Spawn>();
        rigidbody2D =  GetComponent<Rigidbody2D>();
      new Vector2(transform.position.x,transform.position.y);
    }

    void Update()
    {

        if (spawn.Alive)//プレイヤーが生存している時
        {       //左右の移動処理
            jumpUpdeate();//ジャンプの処理
            sample.GetSetProperty = transform.position;
        }
        sceneTitle();//シーンの切り替え
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
                jumpPower = xSpeed * 2;
                rigidbody2D.gravityScale = 2;
                // ジャンプ力を適用
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
            }
        }
    }
    private void FixedUpdate()
    {
        if (spawn.Alive)
        {
            xSpeed = 6;
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                prri = true;
                // 右方向の移動入力
                rigidbody2D.velocity = new Vector2(xSpeed, rigidbody2D.velocity.y);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                prri = true;
                //左方向の移動入力
                rigidbody2D.velocity = new Vector2(-xSpeed, rigidbody2D.velocity.y);
            }
            else
            {
                // 入力なし
                // // X方向の移動を停止
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                prri = false;
            }
        }
    }
    private void sceneTitle()
    {
        //押されたときにシーンを移動する
        if (Input.GetKeyDown(KeyCode.P)&&Input.GetKey(KeyCode.RightShift))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ジャンプの制御
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("sloperLeft")||collision.gameObject.CompareTag("sloperight"))
        {
            JumpCount = 0;
        }
        rigidbody2D.gravityScale = 10;
        if (collision.gameObject.CompareTag("Dead"))
        {
            spawn.Alive = false;
        }

    }


}
