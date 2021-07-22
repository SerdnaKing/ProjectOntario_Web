using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandbagControls : MonoBehaviour
{
    public GameObject lakeSideSandbags;
    public Toggle lakeSideSandbagsToggle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToggleLakesideSandbags(!lakeSideSandbags.activeSelf);
            lakeSideSandbagsToggle.isOn = lakeSideSandbags.activeSelf;
        }
    }

    /// <summary>
    /// Will enable/disable the lakeside sandbag parent and every sandbag too.
    /// We may allow for user to disable some lakeside sandbags so this toggle can be used to re-enable them.
    /// 
    /// If this is seen as a bug by users, we can remove the child gameobject enabliling/disabling.
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
}
