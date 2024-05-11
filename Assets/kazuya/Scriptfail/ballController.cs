using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ballController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
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
        //�W�����v����Ƃ��Ƀ{�[���̏d�͂�1�ɕύX����
        //transform.Rotate(new Vector3(0, 0, -90));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.gravityScale = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�E������̍��]����
        if (collision.gameObject.CompareTag("sloperight")&&playerController.prri ==false)
        {
            Sloperight = true;
        }
        //������̍��]����
        else if(collision.gameObject.CompareTag("sloperLeft")&&playerController.prri == false)
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
        //�{�[������ɂ��鎞�ɑ��x��ύX���āA�ړ�������B
        if (Sloperight == true)
        {
            playerController.xSpeed = 10;
            if (Sloperight == false && playerController.prri == false)
            {
                --playerController.xSpeed;
                if (playerController.xSpeed == 0)
                {
                    playerController.xSpeed = 0;
                }
            }
            rigidbody2D.velocity = new Vector2(playerController.xSpeed, rigidbody2D.velocity.y);
        }
        else if (SlopeLeft == true)
        {
            playerController.xSpeed = 10;
            if (SlopeLeft == false && playerController.prri == false)
            {
                --playerController.xSpeed;
                if (playerController.xSpeed == 0)
                {
                    playerController.xSpeed = 0;
                }
                
            }
            rigidbody2D.velocity = new Vector2(-playerController.xSpeed, rigidbody2D.velocity.y);
        }
        else
        {//�I�u�W�F�N�g�������Ă���Ƃ��͑��x��6�ɖ߂�
            playerController.xSpeed = 6;
        }
    }
}
