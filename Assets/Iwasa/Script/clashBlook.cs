using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clashBlook : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player2")
        {
            Destroy(gameObject);
        }
    }
}
