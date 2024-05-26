using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallcht : MonoBehaviour
{
    public GameObject Player;
    public new GameObject gameObject;
    public int trax;
    public int tray;
    Spawn spawn;
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player")[0];
        spawn = GetComponent<Spawn>();
    }

    void Update()
    {
        //Player = spawn.gameObject;
        Vector3 pv = Player.transform.position;
        Vector3 wp = transform.position;


        float p_vX = pv.x - wp.x;
        float p_vY = pv.y - wp.y;


        if(p_vX < trax && p_vY < tray)
        {
            Destroy(gameObject);
        }
    }
}
