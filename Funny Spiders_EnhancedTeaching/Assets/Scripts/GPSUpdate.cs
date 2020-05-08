using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSUpdate : MonoBehaviour
{
    public TeacherTracking locationService;

    public Text displayText;
    //public TextMesh displayMesh;

    void Update()
    {
        //TextMesh = "Lat: " + TeacherTracking.Instance.latitude.ToString() + ". Long: " + TeacherTracking.Instance.longitude.ToString();   
        float latitude;
        float longtitude;
        float altitude;
        if (locationService.retrieveLocation (out latitude, out longtitude, out altitude))
        {
            displayText.text = "Lat: " + latitude + "\n" + "Long: " + longtitude + "\n" + "Alt: " + altitude;
            //displayMesh.text = "Lat: " + latitude + "\n" + "Long: " + longtitude + "\n" + "Alt: " + altitude;
        }
        else
        {
            displayText.text = "No location";
           // displayMesh.text = "No location";
        }

        
    }

}
