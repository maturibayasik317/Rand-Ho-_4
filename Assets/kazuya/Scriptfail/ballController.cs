using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //ジャンプするときにボールの重力を1に変更する
        transform.Rotate(new Vector3(0, 0, 90));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.gravityScale = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //加速を追加する
        //物体にぶつかった時重力を10に戻す
        rigidbody2D.gravityScale = 10;
    }
}
