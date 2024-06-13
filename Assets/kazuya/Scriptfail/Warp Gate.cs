using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpGate : MonoBehaviour
{
    [SceneField] public GameObject WarpObj;
    [SceneField] public GameObject WarpObj2;
    PlayerController playercontroller;
    public bool WarpTrigger = false;
    private int count = 0;
    [SerializeField] GameObject PlayerObj;
    private Vector2 player;
    Spawn spawn;

    void Start()
    {
        playercontroller = GetComponent<PlayerController>();
        spawn = GetComponent<Spawn>();
    }

    void Update()
    {
        if (WarpTrigger)
        {
            count++;
            if (count == 10)
            {
                WarpTrigger = false;
                count = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(count == 0)
            {
                collision.gameObject.transform.position = WarpObj.transform.position;
                WarpTrigger = true;
            }
        }
    }
}
