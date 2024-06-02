using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Controls;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEditor.Experimental.GraphView;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    [SerializeField] public float dfSpeed;
    [SerializeField]public float xSpeed;//�v���C���[�̑��x
    [SerializeField] public float jumpPower;//�v���C���[�̃W�����v�̍���
    [SerializeField]private float initialJumpPower;
    [SerializeField]public int JumpCount = 1;//�W�����v�ł����
    [SerializeField] public float PlayerObject;
    public bool prri = false;//�v���C���[���~�܂��Ă��邩���m�F���Ă���
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite newSprite;    // �C���X�y�N�^�[����X�v���C�g���󂯎���Ă���
    
    public int GravitySensor { get; private set; }
    private GameObject characterChg;
    Spawn spawn;

    void Start()
    {
        characterChg = GameObject.Find("CharacterChg");
        spawn = characterChg.GetComponent<Spawn>();
        rigidbody2D =  GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
      new Vector2(transform.position.x,transform.position.y);
    }

    void Update()
    {

        if (spawn.Alive)//�v���C���[���������Ă��鎞
        {       //���E�̈ړ�����
            jumpUpdeate();//�W�����v�̏���
            if(transform.position.y <= -10)
            {
                spawn.Alive = false;
            }
        }
        else
        {
            // �X�v���C�g�������ւ���
            spriteRenderer.sprite = newSprite;
        }
        sceneTitle();//�V�[���̐؂�ւ�
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
                jumpPower = xSpeed * 2;
                rigidbody2D.gravityScale = 2;
                // �W�����v�͂�K�p
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
            }
        }
    }
    private void FixedUpdate()
    {
        if (spawn.Alive)
        {
            xSpeed = dfSpeed;
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                prri = true;
                // �E�����̈ړ�����
                rigidbody2D.velocity = new Vector2(xSpeed, rigidbody2D.velocity.y);
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                prri = true;
                //�������̈ړ�����
                rigidbody2D.velocity = new Vector2(-xSpeed, rigidbody2D.velocity.y);
            }
            else
            {
                // ���͂Ȃ�
                // // X�����̈ړ����~
                rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
                prri = false;
            }
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
        if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("sloperLeft")||collision.gameObject.CompareTag("sloperight"))
        {
            JumpCount = 0;
        }
        rigidbody2D.gravityScale = 10;
        if (collision.gameObject.CompareTag("Dead"))
        {
            spawn.Alive = false;
        }
        if (collision.gameObject.CompareTag("slope"))
        {
            spawn.CHG = false;
        }
        else
        {
            spawn.CHG = true;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("midlie"))//�X�̃^�O��ύX����
        {
            //���Ԓn�_�̃I�u�W�F�N�g�ɂӂꂽ�Ƃ��ɍ��W�ۑ����I���ɂ���
            spawn.CheckPlayer = true;
        }
        
    }


}
