using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForwardSpeed;


    private void Update()
    {
        ForwardMovement();
    }


    private void ForwardMovement()
    {
        transform.Translate(Vector3.forward * moveForwardSpeed * Time.deltaTime);
    }
}
