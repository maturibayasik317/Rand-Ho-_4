using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.Alive)
        {
            //ÉLÅ[ÇâüÇ∑Ç≤Ç∆Ç…45ÅãâÒì]Ç∑ÇÈ
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.RightShift))
            {
                transform.Rotate(new Vector3(0, 0, 45));
            }

        }
        
    }
}
