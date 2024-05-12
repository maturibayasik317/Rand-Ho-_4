using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ballController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    PlayerController playerController;
    public bool Sloperight = false;
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
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -5));
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 5));
        }
        else
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.gravityScale = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //右下がりの坂を転がる
        if (collision.gameObject.CompareTag("sloperight"))
        {
            Sloperight = true;
        }
        //左下りの坂を転がる
        else if(collision.gameObject.CompareTag("sloperLeft"))
        {
            SlopeLeft = true;
        }
        else
        {
            Sloperight = false;
            SlopeLeft = false;
        }
    }
    private void FixedUpdate()
    {
        //ボールが坂にある時に速度を変更して、移動させる。
        if (Sloperight == true)
        {
            playerController.xSpeed = 10;
            if (playerController.prri == false)
            {
                rigidbody2D.velocity = new Vector2(playerController.xSpeed, rigidbody2D.velocity.y);
                //--playerController.xSpeed;
                //if (playerController.xSpeed == 0)
                //{
                //    playerController.xSpeed = 0;
                //}
            }

        }
        else if (SlopeLeft == true)
        {
            playerController.xSpeed = 10;
            if ( playerController.prri == false)
            {
                //--playerController.xSpeed;
                //if (playerController.xSpeed == 0)
                //{
                //    playerController.xSpeed = 0;
                //}
                rigidbody2D.velocity = new Vector2(-playerController.xSpeed, rigidbody2D.velocity.y);
            }
            
        }
        else
        {//オブジェクトが動いているときは速度を6に戻す
            playerController.xSpeed = 6;
        }
    }
}
