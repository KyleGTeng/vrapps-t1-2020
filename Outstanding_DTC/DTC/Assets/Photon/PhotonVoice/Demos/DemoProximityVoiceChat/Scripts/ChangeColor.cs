﻿using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(PhotonView))]

public class ChangeColor : MonoBehaviour
{
    private PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        Color random = Random.ColorHSV();
        photonView.RPC("ChangeColour", RpcTarget.All, new Vector3(random.r, random.g, random.b));
    }

    [PunRPC]
    private void ChangeColour(Vector3 randomColor)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", new Color(randomColor.x, randomColor.y, randomColor.z));
    }
}
