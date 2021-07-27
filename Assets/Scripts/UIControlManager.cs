using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlManager : MonoBehaviour
{
    private Slider waterSlider;

    private float rateIncrementation = 0.002f;
    private float rateAcceleration = 1.01f;
    private float rateMaximum = 0.1f;

    private float riseRate = 0;
    private float sinkRate = 0;
    void Start()
    {
        // Prevents cursor going off screen when looking around
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // TODO: turn GUI into prefab and attach slider manually to this script instead of searching
        GameObject sliderObj = GameObject.Find("Slider");
        if(sliderObj) waterSlider = sliderObj.GetComponent<Slider>();
    }

    /// <summary>
    /// Allows raising/lowering waterlevel with O and K keys.
    /// The rates accelerates the longer you hold the key.
    /// </summary>
    void FixedUpdate()
    {
        if (waterSlider)
        {
            // raises waterlevel
            if (Input.GetKey(KeyCode.O))
            {
                if (riseRate == 0) riseRate = rateIncrementation;
                riseRate = Mathf.Min(Mathf.Pow(riseRate + 1, rateAcceleration) - 1, rateMaximum);
                waterSlider.value += riseRate;
            }
            else
            {
                //reset rate
                riseRate = 0;
            }

            // lowers waterlevel
            if (Input.GetKey(KeyCode.K))
            {
                if (sinkRate == 0) sinkRate = rateIncrementation;
                sinkRate = Mathf.Min(Mathf.Pow(sinkRate + 1, rateAcceleration) - 1, rateMaximum);
                waterSlider.value -= sinkRate;
            }
            else
            {
                //reset rate
                sinkRate = 0;
            }
        }
    }
}
