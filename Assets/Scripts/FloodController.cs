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
        /*  if (Input.GetKeyDown(KeyCode.I))
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
      }*/

        this.transform.position = new Vector3(this.transform.position.x, UISlider.value - 10.28f, this.transform.position.z);
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


