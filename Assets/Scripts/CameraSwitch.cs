/* Noah Richards
 * 7/13/2021 - 7/16/2021
 * CameraSwitch.cs - Camera Switching Code for Project Ontario
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public List<GameObject> camList = new List<GameObject>();

    /// <summary>
    /// Switches to the Camera in camList with the name given.
    /// </summary>
    /// <param name="camName">The Camera's name.</param>
    private void SwitchCamera(string camName)
    {
        foreach (GameObject cam in camList)
        {
            // Enable the current camera if its name matches the one given
            if (cam.name == camName)
            {
                cam.SetActive(true);
            }
            // Otherwise, disable it
            else
            {
                cam.SetActive(false);
            }
        }
    }

    private void SwitchCamera(int camIndex)
    {
        if (camIndex >= 0 && camIndex < camList.Count)
        {
            foreach (GameObject cam in camList)
            {
                if (cam != camList[camIndex])
                {
                    cam.SetActive(false);
                }
            }
            camList[camIndex].SetActive(true);
        }
        else
        {
            Debug.Log("ERROR: Index " + camIndex + " not found in camList!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Make sure only the player is enabled on startup
        SwitchCamera(0);
    }

    // Update is called once per frame
    void Update()
    {
        // Allow the player to switch between different cameras with the number keys
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SwitchCamera(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCamera("camShoreline");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCamera("camStreetview");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchCamera("camNeighborhood");
        }
    }
}
