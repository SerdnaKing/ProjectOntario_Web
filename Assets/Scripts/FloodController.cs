using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloodController : MonoBehaviour
{

    public Slider UISlider;


    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.I))
            {
            if (UISlider.value != 2)
            {
                UISlider.value += 1;
                this.transform.Translate(Vector3.up * 1);
            }
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
            if(UISlider.value != 0)
            {
                UISlider.value -= 1;
                this.transform.Translate(Vector3.down * 1);
            }
        }
        }
    }

