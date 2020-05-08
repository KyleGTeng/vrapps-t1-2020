using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    //public GameObject DisplayName;
    public GameObject avatarPrefab;
    //public string username;
    //public string appid;

    //public GameObject Username;
    //public GameObject AppID;
    //public GameObject LoginPage;
    public Canvas placeHolder;
    //public GameObject roomPrefab;
   // public Canvas roomCanvas;

   // List<GameObject> displayName = new List<GameObject>();

    public override void OnConnectedToMaster()
    {
        Debug.Log(" ------ Phothon Network Successful Connected. ------ ");

        RoomOptions roomopt = new RoomOptions();
        PhotonNetwork.JoinOrCreateRoom("Week3Room", roomopt, new TypedLobby("Week3Lobby", LobbyType.Default));
        base.OnConnectedToMaster();
    }

    public override void OnJoinedRoom()
    {
        //Debug.Log("Player: " + PhotonNetwork.CurrentRoom.PlayerCount + " welcome join the room");
        //Debug.Log("Player: " + PhotonNetwork.CurrentRoom.PlayerCount + " welcome join the room");

        //username = Username.GetComponent<Text>().text;
        //appid = AppID.GetComponent<Text>().text;

       // LoginPage.SetActive(false);
        placeHolder.enabled = false;
        PhotonNetwork.Instantiate(avatarPrefab.name, new Vector3(), Quaternion.identity, 0);
       // DisplayName.GetComponent<TextMesh>().text = username;

        //Debug.Log("Username is : " + username);

        base.OnJoinedRoom();
    }

    public void StoreName()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("  ------ Start Connecting ------ ");

    }

   

    //public static string getName(GameObject o)
    //{
    //    if (o.GetComponent<PhotonView>() != null)
    //    {
    //        if ((o.GetComponent<PhotonView>().Owner.NickName != null) && !(o.GetComponent<PhotonView>().Owner.NickName.Equals("")))
    //        {
    //            return o.GetComponent<PhotonView>().Owner.NickName;
    //        }
    //        else
    //        {
    //            return o.GetComponent<PhotonView>().Owner.UserId;
    //        }
    //    }
    //    else
    //    {
    //        return "X" + PhotonNetwork.AuthValues.UserId;
    //    }
    //}

    //GameObject getRoomObject (string name)
    //{
    //    foreach (GameObject g in displayRooms)
    //    {
    //        DisplayRoom dr = g.GetComponent<DisplayRoom>();
    //        if (dr.getName ().Equals (name))
    //        { return g; }
    //    }
    //    GameObject room = Instantiate(roomPrefab);
    //    room.transform.SetParent(roomCanvas.transform);
    //    room.GetComponent<DisplayRoom>().setName(name);
    //    room.GetComponent<LocalRoomBehaviour>().setManager(this);
    //    displayRooms.Add(room);
    //    return room;
    //}
}
