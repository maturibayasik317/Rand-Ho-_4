using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ballController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    PlayerController playerController;
    Spawn spawn;
    private GameObject characterChg;
    private bool Sloperight = false;
    private bool SlopeLeft = false;
    private bool ballslope = false;
    

    void Start()
    {
        characterChg = GameObject.Find("CharacterChg");
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        spawn = characterChg.GetComponent<Spawn>();
        
    }

    void Update()
    {
        if (spawn.Alive)
        {
            //�W�����v����Ƃ��Ƀ{�[���̏d�͂�1�ɕύX����
            //transform.Rotate(new Vector3(0, 0, -90));
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(new Vector3(0, 0, -1));
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(new Vector3(0, 0, 1));
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (spawn.Alive)
        {
            //�E������̍��]����
            if (collision.gameObject.CompareTag("sloperight"))
            {
                Sloperight = true;
            }
            //������̍��]����
            else if (collision.gameObject.CompareTag("sloperLeft"))
            {
                SlopeLeft = true;
            }

            else
            {
                Sloperight = false;
                SlopeLeft = false;
            }
        }
        
    }
    private void FixedUpdate()
    {
        if (spawn.Alive)
        {
            //�{�[������ɂ��鎞�ɑ��x��ύX���āA�ړ�������B
            if (Sloperight == true)
            {
                playerController.xSpeed = 10;
                if (playerController.prri == false)
                {
                    rigidbody2D.velocity = new Vector2(playerController.xSpeed, rigidbody2D.velocity.y);
                    if(playerController.JumpCount == 1)
                    {
                        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                    }
                }

            }
            else if (SlopeLeft == true)
            {
                playerController.xSpeed = 10;
                if (playerController.prri == false)
                {
                    rigidbody2D.velocity = new Vector2(-playerController.xSpeed, rigidbody2D.velocity.y);
                    if (playerController.JumpCount == 1)
                    {
                        rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                    }
                }

            }
            else
            {//�I�u�W�F�N�g�������Ă���Ƃ��͑��x��6�ɖ߂�
                playerController.xSpeed = playerController.dfSpeed;
            }
        }
    }
}
