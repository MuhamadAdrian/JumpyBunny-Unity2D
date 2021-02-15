﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Vector3.zero;
        position.z = -10;
        position.x = player.position.x;
        position.y = player.position.y;

        this.transform.position = position;
    }
}
