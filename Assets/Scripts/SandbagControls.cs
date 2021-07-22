using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandbagControls : MonoBehaviour
{
    public GameObject lakeSideSandbags;
    public Toggle lakeSideSandbagsToggle;

    public GameObject pondSideSandbags;
    public Toggle pondSideSandbagsToggle;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && lakeSideSandbags)
        {
            ToggleLakesideSandbags(!lakeSideSandbags.activeSelf);
            if(lakeSideSandbagsToggle) lakeSideSandbagsToggle.isOn = lakeSideSandbags.activeSelf;
        }

        if (Input.GetKeyDown(KeyCode.P) && pondSideSandbags)
        {
            TogglePondsideSandbags(!pondSideSandbags.activeSelf);
            if (pondSideSandbagsToggle) pondSideSandbagsToggle.isOn = pondSideSandbags.activeSelf;
        }
    }

    /// <summary>
    /// Will enable/disable the lakeside sandbag parent and every sandbag too.
    /// We may allow for user to disable some lakeside sandbags so this toggle can be used to re-enable them.
    /// 
    /// If this is seen as a bug by users, we can remove the child gameobject enabling/disabling.
    /// </summary>
    /// <param name="selected">Toggle's state</param>
    public void ToggleLakesideSandbags(bool selected)
    {
        lakeSideSandbags.SetActive(selected);
        for (int i = 0; i < lakeSideSandbags.transform.childCount; i++)
        {
            lakeSideSandbags.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Will enable/disable the pondside sandbag parent and every sandbag too.
    /// We may allow for user to disable some pondside sandbags so this toggle can be used to re-enable them.
    /// 
    /// If this is seen as a bug by users, we can remove the child gameobject enabling/disabling.
    /// </summary>
    /// <param name="selected">Toggle's state</param>
    public void TogglePondsideSandbags(bool selected)
    {
        pondSideSandbags.SetActive(selected);
        for (int i = 0; i < pondSideSandbags.transform.childCount; i++)
        {
            pondSideSandbags.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
