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
        //�W�����v����Ƃ��Ƀ{�[���̏d�͂�1�ɕύX����
        transform.Rotate(new Vector3(0, 0, 90));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.gravityScale = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //������ǉ�����
        //���̂ɂԂ��������d�͂�10�ɖ߂�
        rigidbody2D.gravityScale = 10;
    }
}
