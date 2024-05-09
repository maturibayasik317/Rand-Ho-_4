using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float xSpeed = 6;//�v���C���[�̑��x
    public float jumpPower;//�v���C���[�̃W�����v�̍���
    private int JumpCount;//
    public bool prri = false;//�v���C���[���~�܂��Ă��邩���m�F���Ă���

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //���E�̈ړ�����
        MoveUpdeate();//���̂̍��E�ړ��̏���
        jumpUpdeate();//�W�����v�̏���
        sceneTitle();//�V�[���̐؂�ւ�
    }
    private void MoveUpdeate()
    {

    }
    void jumpUpdeate()
    {
        //2�i�W�����v�֎~ //�^�O������ăW�����v���֎~�ɂ���
        // �W�����v����
        if (JumpCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.RightShift))
            {// �W�����v�J�n
                ++JumpCount;
                // �W�����v�͂��v�Z
                 jumpPower = xSpeed*2;
                // �W�����v�͂�K�p
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
            }
        }
    }
    private void FixedUpdate()
    {
        xSpeed = 6;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            prri = false;
            // �E�����̈ړ�����
            rigidbody2D.velocity = new Vector2(xSpeed, rigidbody2D.velocity.y);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            prri = false;
            //�������̈ړ�����
            rigidbody2D.velocity = new Vector2(-xSpeed, rigidbody2D.velocity.y);
        }
        else
        {
            // ���͂Ȃ�
            // // X�����̈ړ����~
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            prri = true;
        }
    }
    private void sceneTitle()
    {
        //�����ꂽ�Ƃ��ɃV�[�����ړ�����
        if (Input.GetKeyDown(KeyCode.P)&&Input.GetKey(KeyCode.RightShift))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�W�����v�̐���
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("slope"))
        {
            JumpCount = 0;
        }
        
    }

}
