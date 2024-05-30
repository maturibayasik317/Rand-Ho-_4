using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMove : MonoBehaviour
{
    [SerializeField] private float windx = 0f;
    [SerializeField] private float windy = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody otherRigidbody = gameObject.GetComponent<Rigidbody>();

        if(otherRigidbody != null)
        {
            otherRigidbody.AddForce(windx, windy, 0, ForceMode.Acceleration);
        }
    }
}
