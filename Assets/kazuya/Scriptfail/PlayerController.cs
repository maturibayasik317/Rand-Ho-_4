using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //D�L�[���������Ƃ��ɉE�Ɉړ�
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 pos = transform.position;
            pos.x += 0.1f;
            transform.position = pos;
        }//A�L�[���������Ƃ��ɍ��Ɉړ�
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 pos = transform.position;
            pos.x -= 0.1f;
            transform.position = pos;
        }
    }
}
