using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;

public class TeacherTracking : MonoBehaviour
{

    public bool retrieveLocation (out float latitude, out float longitude, out float altitude)
    {
        latitude = 0.0f;
        longitude = 0.0f;
        altitude = 0.0f;

        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            return false;
        }
        if (Input.location.status != LocationServiceStatus.Running)
        {
            Debug.Log("Starting location service");
            if (Input.location.status == LocationServiceStatus.Stopped)
            {
                Input.location.Start();
            }
            return false;
        }
        else
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            altitude = Input.location.lastData.altitude;
            return true;
        }
        
    }
    
    public void Start()
    {



        if (GetComponent<PhotonView>().IsMine == true || PhotonNetwork.IsConnected == false)
        {
            
            Debug.Log("----------------------Debug Error: " + GetComponent<TextMesh>().text);
            Debug.Log("Debug Error: " + GameObject.Find("Canvas/Name/Text").GetComponent<Text>().text);
            GetComponent<TextMesh>().text = GameObject.Find("Canvas/Name/Text").GetComponent<Text>().text;
           
        }

            //PhotonView.RPC("showNickName", RpcTarget.All, PhotonManager.getName(this.gameObject));
    }

    private void Update()
    {
        
        //GameObject.Find("StudentName").transform.position = transform.position;
        
        transform.position = new Vector3(Input.location.lastData.latitude*5, Input.location.lastData.altitude, Input.location.lastData.longitude*5);
        Debug.Log("Transform Position From TeacherTracking.cs: " + transform.position);
    }

    //public void nickName ()
    //{
    //    GameObject t = GameObject.Find("Canvas/LoginPage/Name/Text");
    //    if (t != null)
    //    {
    //        GetComponent<PhotonView>().Owner.NickName = t.GetComponent<Text>().text;
    //        //PhotonView.RPC("showNickName", RpcTarget.All, t);
    //    }
    //}

    //void showNickName (string name)
    //{
    //    transform.Find("StudentName").gameObject.GetComponent<TextMesh> ().text = name;
    //}
}
