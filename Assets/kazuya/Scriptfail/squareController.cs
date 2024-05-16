using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class squareController : MonoBehaviour
{
    private int index = 0;
    [SerializeField] public GameObject[] Player;
    public GameObject childObject;
    [SerializeField] GameObject Square;
    private Vector2 player;
    Spawn spawn;
    void Start()
    {
        spawn = GetComponent<Spawn>();
    }

    void Update()
    {
        childObject = spawn.gameObject;
        Square = childObject;
        if (Input.GetKeyDown(KeyCode.Q))
        {
            player = Square.transform.position;
            Destroy(Square);
            ++index;
            if(index == Player.Length) { index = 0; }
            childObject = Instantiate(Player[index], player, Quaternion.identity);
        }
    }
}
