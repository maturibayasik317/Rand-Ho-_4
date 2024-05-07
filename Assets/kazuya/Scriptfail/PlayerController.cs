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
        //���E�̈ړ�����
        MoveUpdeate();//���̂̍��E�ړ��̏���
        jumpUpdeate();//�W�����v�̏���
        sceneTitle();//�V�[���̐؂�ւ�
    }
    private void MoveUpdeate()
    {

        // X�����ړ�����
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {// �E�����̈ړ�����
         // X�����ړ����x���v���X�ɐݒ�
         xSpeed = + 6.0f;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {// �������̈ړ�����
         // X�����ړ����x���}�C�i�X�ɐݒ�
         xSpeed = -6.0f;
        }
        else
        {// ���͂Ȃ�
         // X�����̈ړ����~
            xSpeed = 0.0f;
        }
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
                float jumpPower = 10.0f;
                // �W�����v�͂�K�p
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
            }
        }
    }
    private void FixedUpdate()
    {
        // �ړ����x�x�N�g�������ݒl����擾
        Vector2 velocity = rigidbody2D.velocity;
        // X�����̑��x����͂��猈��
        velocity.x = xSpeed;

        // �v�Z�����ړ����x�x�N�g����Rigidbody2D�ɔ��f
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
