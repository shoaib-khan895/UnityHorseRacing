using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CameraSwitchTrigger : MonoBehaviour
{
    public Camera Cam1; // Reference to the main camera
    public Camera Cam2; // Reference to the alternate camera
    public Camera Cam3; 
    public Camera Cam6;
    public string zoneTag; // Tag to identify this trigger zone
  
    public float SlowDownTo = 0.05f;
    public float SlowDownTime = 4f;

    void OnTriggerExit(Collider other)
    {
        Debug.Log(zoneTag);
        if (zoneTag == "1")
        {
            Cam1.gameObject.SetActive(true);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam6.gameObject.SetActive(false);
        }
        else if (zoneTag == "2")
        {
            Cam1.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(true);
            Cam3.gameObject.SetActive(false);

            Cam6.gameObject.SetActive(false);
        }
        else if (zoneTag == "3")
        {
            Cam1.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(true);
            Cam6.gameObject.SetActive(false);
        }
        // else if (zoneTag == "4")
        // {
        //     Cam1.gameObject.SetActive(false);
        //     Cam2.gameObject.SetActive(false);
        //     Cam3.gameObject.SetActive(false);
        //     Cam4.gameObject.SetActive(true);
        //     Cam5.gameObject.SetActive(false);
        //     Cam6.gameObject.SetActive(false);
        // }
        else if (zoneTag == "5")
        {
            Cam1.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
            Cam6.gameObject.SetActive(true);

         Time.timeScale = SlowDownTo;

        }
    }
}