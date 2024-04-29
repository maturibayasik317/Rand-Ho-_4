using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float xSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //���E�̈ړ�����
        MoveUpdeate();
    }
    private void MoveUpdeate()
    {

        // X�����ړ�����
        if (Input.GetKey(KeyCode.D))
        {// �E�����̈ړ�����
         // X�����ړ����x���v���X�ɐݒ�
            xSpeed = + 6.0f;
        }
        else if (Input.GetKey(KeyCode.A))
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
    private void FixedUpdate()
    {
        // �ړ����x�x�N�g�������ݒl����擾
        Vector2 velocity = rigidbody2D.velocity;
        // X�����̑��x����͂��猈��
        velocity.x = xSpeed;

        // �v�Z�����ړ����x�x�N�g����Rigidbody2D�ɔ��f
        rigidbody2D.velocity = velocity;
    }

}
