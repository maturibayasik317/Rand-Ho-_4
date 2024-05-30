using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    PlayerController playerController;
    Spawn spawn;
    private GameObject characterChg;
    void Start()
    {
        characterChg = GameObject.Find("CharacterChg");
        playerController = GetComponent<PlayerController>();
        spawn = characterChg.GetComponent<Spawn>();
        
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
}
