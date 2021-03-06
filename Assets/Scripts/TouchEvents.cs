﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchEvents : MonoBehaviour {

    bool bunnyIsTapped;
    GameObject touchedBunny;
    Vector3 touchPosWorld;
    Vector3 offset;

    private HapticSquare haptic1;
    private HapticSquare haptic3;
    private HapticSquare haptic5;

    // Use this for initialization
    void Start()
    {
        Debug.Log("executing touchevents script");
        bunnyIsTapped = false;
        haptic1 = GameObject.Find("SquareHaptic1").GetComponent<HapticSquare>();
        haptic1.DeactivateHaptic();

        haptic3 = GameObject.Find("SquareHaptic3").GetComponent<HapticSquare>();
        haptic3.DeactivateHaptic();

        haptic5 = GameObject.Find("SquareHaptic5").GetComponent<HapticSquare>();
        haptic5.DeactivateHaptic();
    }

    // Update is called once per frame
    void Update()
    {

        // TAP BUNNY // OR // TAP BUTTON //

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //transform the touch position into world space from screen space and store it.
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector2 touchPosWorld2D = new Vector2(touchPosWorld.x, touchPosWorld.y);

            //raycast with this information. If we have hit something we can process it.
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPosWorld2D, Camera.main.transform.forward);

            if (hitInformation.collider != null)
            {

                //We should have hit something with a 2D Physics collider!
                //touchedBunny should be the object someone touched.
                //if (hitInformation.transform.gameObject.tag == "Bunny")
                // Capsule collider is the top collider which is for touch events
                //if (hitInformation.collider.tag == "Bunny" && hitInformation.collider is CapsuleCollider2D)
                if (hitInformation.collider.tag.StartsWith("Bunny"))
                {
                    Debug.Log(hitInformation.collider.name);
                    touchedBunny = hitInformation.transform.gameObject;
                    Debug.Log(touchedBunny.name);
                    bunnyIsTapped = true;
                    offset = touchPosWorld - touchedBunny.transform.position;
                    //Debug.Log("Touched " + touchedBunny.name);


                    //Activate the haptics view
                    switch (touchedBunny.tag)
                    {
                        case "Bunny1":
                            haptic1.ActivateHaptic();
                            break;
                        case "Bunny3":
                            haptic3.ActivateHaptic();
                            break;
                        case "Bunny5":
                            haptic5.ActivateHaptic();
                            break;
                    }
                }

                else if (hitInformation.collider.tag == "Button")
                {
                    touchedBunny = hitInformation.transform.gameObject;
                    touchedBunny.GetComponent<Button>().Next();

                }
            }
        }

        // MOVE BUNNY //

        if (Input.touchCount > 0 && bunnyIsTapped && Input.GetTouch(0).phase == TouchPhase.Moved)
        {

            // Get movement of the finger since last frame
            touchPosWorld = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector3 newBunnyPosition = touchPosWorld - offset;
            touchedBunny.transform.position = new Vector3(newBunnyPosition.x, newBunnyPosition.y, newBunnyPosition.z);
            //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            //float speed = 0.1f;

            // Move object across XY plane
            //touchedBunny.transform.Translate(touchDeltaPosition.x * speed, touchDeltaPosition.y * speed, 0);

        }

        // END MOVE BUNNY & DETECT IF SAT ON A SEAT//
        if (Input.touchCount > 0 && bunnyIsTapped && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            //Deactivate the haptics view
            switch (touchedBunny.tag)
            {
                case "Bunny1":
                    haptic1.DeactivateHaptic();
                    break;
                case "Bunny3":
                    haptic3.DeactivateHaptic();
                    break;
                case "Bunny5":
                    haptic5.DeactivateHaptic();
                    break;
            }

            bunnyIsTapped = false; //end the touch

            //if (GlobalVariables.collidedSeat != null)
            touchedBunny.GetComponent<BunnyPlayer>().TouchUp();
        }
    }
}
