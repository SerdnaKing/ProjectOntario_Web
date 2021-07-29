/* Noah Richards
 * 7/13/2021 - 7/29/2021
 * CameraSwitch.cs - Camera Switching Code for Project Lake Ontario
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public List<GameObject> camList = new List<GameObject>();
    public Crest.OceanRenderer lakeRenderer = null;

    /// <summary>
    /// Switches to the Camera in camList with the name given.
    /// </summary>
    /// <param name="camName">The Camera's name.</param>
    private void SwitchCamera(string camName)
    {
        bool foundCam = false;

        foreach (GameObject cam in camList)
        {
            // Enable the current camera if its name matches the one given
            if (cam.name == camName)
            {
                cam.SetActive(true);
                foundCam = true;
            }
            // Otherwise, disable it
            else
            {
                cam.SetActive(false);
            }
        }

        if (!foundCam)
            Debug.Log("ERROR: Camera with name " + camName + " not found in camList!");
    }

    /// <summary>
    /// Switches to the Camera in camList at the index given.
    /// </summary>
    /// <param name="camIndex">The Camera's index.</param>
    private void SwitchCamera(int camIndex)
    {
        if (camIndex >= 0 && camIndex < camList.Count)
        {
            /*
            foreach (GameObject cam in camList)
            {
                if (cam != camList[camIndex])
                {
                    cam.SetActive(false);
                }
            }
            camList[camIndex].SetActive(true);
            */
            // Go through each GameObject in camList
            for (int i = 0; i < camList.Count; i++)
            {
                // If camIndex doesn't match the current index, disable the current GameObject
                if (i != camIndex)
                {
                    camList[i].SetActive(false);
                    continue;
                }

                // Otherwise, enable it!
                camList[i].SetActive(true);

                if (lakeRenderer != null)
                {
                    lakeRenderer.ViewCamera = camList[i].GetComponent<Camera>();
                }
                else
                {
                    Debug.Log("ERROR: Component lakeRenderer can not be assigned!");
                }
            }
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

        // Prevents cursor going off screen when looking around
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
            SwitchCamera(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCamera(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchCamera(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchCamera(4);
        }
    }

    public Camera GetActiveCamera()
    {
        for (int i = 0; i < camList.Count; i++)
        {
            if (camList[i].activeSelf)
            {
                Camera camera = camList[i].GetComponent<Camera>();
                if (!camera)
                {
                    camera = camList[i].GetComponentInChildren<Camera>();
                }
                return camera;
            }
        }

        return null;
    }
}
