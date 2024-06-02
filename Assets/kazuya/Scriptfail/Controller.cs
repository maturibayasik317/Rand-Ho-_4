using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Controller : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    [SerializeField] public float dfSpeed;
    [SerializeField] public float xSpeed;//プレイヤーの速度
    public ButtonControl left { get; private set; }
    private GameObject characterChg;
    Spawn spawn;
    PlayerController playerController;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (spawn.Alive)
        {
            xSpeed = dfSpeed;
            if (Input.GetButton("CHorizontal"))
            {
                playerController.prri = true;
                rigidbody2D.velocity = new Vector2(xSpeed, rigidbody2D.velocity.y);
            }
        }
    }
}
