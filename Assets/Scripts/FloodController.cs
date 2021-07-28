using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloodController : MonoBehaviour
{
    public Slider UISlider;
    public GameObject PondWaterMask;
    public GameObject LakeWaterMask;
    public GameObject PondSandbags;
    public GameObject LakeSandbags;

    private readonly float rateIncrementation = 0.002f;
    private readonly float rateAcceleration = 1.01f;
    private readonly float rateMaximum = 0.1f;

    private float riseRate = 0;
    private float sinkRate = 0;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, UISlider.value - 10.28f, transform.position.z);

        if (transform.position.y >= -8.5 && LakeSandbags.activeSelf == true)
        {
            LakeWaterMask.SetActive(false);
        }
        else if(LakeSandbags.activeSelf == false)
        {
            LakeWaterMask.SetActive(false);
        }
        else
        {
            LakeWaterMask.SetActive(true);
        }


        if (transform.position.y >= -9 && PondSandbags.activeSelf == true)
        {
            PondWaterMask.SetActive(false);
        }
        else if(PondSandbags.activeSelf == false)
        {
            PondWaterMask.SetActive(false);
        }
        else
        {
            PondWaterMask.SetActive(true);
        }
    }

    /// <summary>
    /// Allows raising/lowering waterlevel with O and K keys.
    /// The rates accelerates the longer you hold the key.
    /// </summary>
    void FixedUpdate()
    {
        if (UISlider)
        {
            // raises waterlevel
            if (Input.GetKey(KeyCode.O))
            {
                if (riseRate == 0) riseRate = rateIncrementation;
                riseRate = Mathf.Min(Mathf.Pow(riseRate + 1, rateAcceleration) - 1, rateMaximum);
                UISlider.value += riseRate;
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
                UISlider.value -= sinkRate;
            }
            else
            {
                //reset rate
                sinkRate = 0;
            }
        }
    }

    void OnGUI()
    {

        GUI.color = Color.white;
        GUI.skin.box.fontSize = 14;
        GUI.skin.box.wordWrap = false;

        //note:  must use (int) or else the float digits flicker

        GUI.Box(new Rect(300, 10, 240, 22), "Approximate Water Level: " + Mathf.Round((245 + (UISlider.value * 3.28f)) * 100.0f)*0.01f + " ft");
    }

}


