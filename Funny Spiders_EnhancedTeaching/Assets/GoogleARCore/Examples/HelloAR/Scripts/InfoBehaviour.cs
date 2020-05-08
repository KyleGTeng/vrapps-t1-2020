﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InfoBehaviour : MonoBehaviour
{
    private const float SPEED = 6f;
    [SerializeField]
    Transform SectionInfo;

    Vector3 desiredScale = Vector3.zero;

    private void Update()
    {
        SectionInfo.localScale = Vector3.Lerp(SectionInfo.localScale, desiredScale, Time.deltaTime * SPEED);
    }

    public void OpenInfo()
    {
        desiredScale = Vector3.one;
    }

    public void CloseInfo()
    {
        desiredScale = Vector3.zero;
    }
}
