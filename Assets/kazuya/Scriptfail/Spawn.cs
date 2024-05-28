using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public int index = 0;
    private float DeatTime = 0.0f;
    public GameObject[] Player;
    public new GameObject gameObject;
    [SerializeField] GameObject PlayerObj;
    public GameObject middleObj;
    private  Vector2 player;
    public Vector2 dfPlayer = new Vector2();
    public bool Alive = true;
    SquareController squareController;
    public static bool middle = false;

    void Start()
    {
        if(middle == false)
        {
            gameObject = Instantiate(Player[0], dfPlayer, Quaternion.identity);
        }
        else
        {
            gameObject = Instantiate(Player[0], dfPlayer, Quaternion.identity);
        }
        
        squareController = GetComponent<SquareController>();
    }

    void Update()
    {
        
            gameObject = squareController.childObject;
            PlayerObj = gameObject;
        if (Alive)
        {
            //キーが押されたときにオブジェクトの種類を変える
            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
            {
                player = PlayerObj.transform.position;
                Destroy(gameObject);
                ++index;
                if (index == Player.Length) { index = 0; }
                gameObject = Instantiate(Player[index], player, Quaternion.identity);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                player = dfPlayer;
                Destroy(gameObject);
                ++index;
                if (index == Player.Length) { index = 0; }
                gameObject = Instantiate(Player[index], player, Quaternion.identity);
            }
        }
        else
        {
            ++DeatTime;
            if (DeatTime == 200.0f)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("slope"))
        {
            middle = true;
            Debug.Log("true");
            dfPlayer = middleObj.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("slope"))
        {
            middle = true;
            Debug.Log("true");
            dfPlayer = middleObj.transform.position;
        }
    }
}
