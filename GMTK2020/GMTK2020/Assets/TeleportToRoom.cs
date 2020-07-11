﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToRoom : MonoBehaviour
{

    public Transform teleportDestination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = teleportDestination.position;
        }
    }
}
