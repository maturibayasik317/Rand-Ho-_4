using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ballController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    PlayerController playerController;
    public bool Slope/*right*/ = false;
    public bool SlopeLeft = false;
    public bool ballslope = false;
    

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        //ジャンプするときにボールの重力を1に変更する
        //transform.Rotate(new Vector3(0, 0, -90));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.gravityScale = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //自動で坂を下る
        if (collision.gameObject.CompareTag("slope")&&playerController.prri ==true)
        {
            ballslope = true;
        }
        else
        {
            ballslope = false;        
        }
        //物体にぶつかった時重力を10に戻す
        rigidbody2D.gravityScale = 10;
    }
    private void FixedUpdate()
    {
        //ボールが坂にある時に速度を変更して、移動させる。
        if(ballslope == true)
        {
            playerController.xSpeed = 10;
            rigidbody2D.velocity = new Vector2(playerController.xSpeed, rigidbody2D.velocity.y);
        }
        else
        {
            playerController.xSpeed = 6;
        }
    }
}
