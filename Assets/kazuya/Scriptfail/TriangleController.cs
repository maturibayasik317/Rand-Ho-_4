using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    PlayerController playerController;
    Spawn spawn;
    private GameObject characterChg;
    private GameObject wallcht;
    Wallcht wch;
    void Start()
    {
        characterChg = GameObject.Find("CharacterChg");
        playerController = GetComponent<PlayerController>();
        spawn = characterChg.GetComponent<Spawn>();
        wallcht = GameObject.Find("Wallcht");
        wch = wallcht.GetComponent<Wallcht>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn.Alive)
        {
            //ÉLÅ[ÇâüÇ∑Ç≤Ç∆Ç…45ÅãâÒì]Ç∑ÇÈ
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.RightShift))
            {
                transform.Rotate(new Vector3(0, 0, 45));
            }

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dead"))
        {
            if (GameObject.Find("Rock(Clone)"))
            {
                if (spawn.index == 1 && wch.selection == 1)
                {
                    spawn.Alive = true;
                }
                else
                {
                    spawn.Alive = false;
                }
            }
            else
            {
                spawn.Alive = false;
            }
        }
    }
}
