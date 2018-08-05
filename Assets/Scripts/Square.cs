using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {

    private HapticSquare hapticSquare;

    private string currentHapticType;

    public GameObject click;
    public GameObject bumpy;
    public GameObject ribbed;

    // Use this for initialization
    void Start () {
        hapticSquare = GetComponent<HapticSquare>();
        //currentHapticType = hapticSquare.HapticType.CLICK;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnChangeHapticsSelected()
    {
        Debug.Log("change texture is clicked");
        //if (currentHapticType.Equals(WheelHaptics.HapticType.CLICK))
        //{
        //    currentHapticType = WheelHaptics.HapticType.BUMPY;
        //    wheelHaptics.UpdateHaptics(WheelHaptics.HapticType.BUMPY);
        //    bumpy.SetActive(true);
        //    click.SetActive(false);
        //    ribbed.SetActive(false);
        //    //changeHapticsText.text = WheelHaptics.HapticType.BUMPY;
        //}
        //else if (currentHapticType.Equals(WheelHaptics.HapticType.BUMPY))
        //{
        //    currentHapticType = WheelHaptics.HapticType.RIBBED;
        //    wheelHaptics.UpdateHaptics(WheelHaptics.HapticType.RIBBED);
        //    bumpy.SetActive(false);
        //    click.SetActive(false);
        //    ribbed.SetActive(true);
        //    //changeHapticsText.text = WheelHaptics.HapticType.RIBBED;
        //}
        //else if (currentHapticType.Equals(WheelHaptics.HapticType.RIBBED))
        //{
        //    currentHapticType = WheelHaptics.HapticType.CLICK;
        //    wheelHaptics.UpdateHaptics(WheelHaptics.HapticType.CLICK);
        //    bumpy.SetActive(false);
        //    click.SetActive(true);
        //    ribbed.SetActive(false);
        //    //changeHapticsText.text = WheelHaptics.HapticType.CLICK;
        //}
    }
}
