using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enumaration
public enum Lane
{
    leftLane,
    middleLane,
    rightLane
}


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForwardSpeed;
    [SerializeField] private float laneDistance;
    [SerializeField] private float laneSwitchSpeed;
    [SerializeField] private float swipeThreshold;
    [SerializeField] private Transform visualTransform;

    private Lane currentLane = Lane.middleLane;

    private void Update()
    {
        ForwardMovement();
    }

    //forward movement
    private void ForwardMovement()
    {
        transform.Translate(Vector3.forward * moveForwardSpeed * Time.deltaTime);
    }

    private void CheckSwipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 swipeDelta = touch.position - touch.rawPosition;

            if (swipeDelta.x > swipeThreshold && currentLane != Lane.rightLane)
            {
                currentLane += 1;
            }
            else if (swipeDelta.x < -swipeThreshold && currentLane != Lane.leftLane)
            {
                currentLane -= 1;
            }
        }
    }

    private void ChangeLane()
    {
        Vector3 targetPosition = Vector3.zero;

        switch (currentLane)
        {
            case Lane.leftLane:
                targetPosition = Vector3.left * laneDistance;
                break;
            case Lane.middleLane:
                break;
            case Lane.rightLane:
                targetPosition = Vector3.right * laneDistance;
                break;
        }

        visualTransform.localPosition = Vector3.Lerp(visualTransform.localPosition, targetPosition, Time.deltaTime * laneSwitchSpeed);
    }
}
