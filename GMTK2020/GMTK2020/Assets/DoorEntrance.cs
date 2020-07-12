using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEntrance : MonoBehaviour
{
    public Transform teleportDestination;
    RoomManager Rm;
    EnemyManager Em;
    bool SpawnedRoom;
    // Start is called before the first frame update
    void Start()
    {
        Rm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RoomManager>();
        Em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>();
        SpawnedRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Em.currentNumberofenemies <= 0)
            {
                if (SpawnedRoom == false)
                {
                    Rm.setEntranceDoor(gameObject.transform.GetChild(0).gameObject);
                    Rm.createRoom(gameObject);
                    
                    teleportDestination = Rm.exitdoor.transform;

                    SpawnedRoom = true;
                }
                collision.gameObject.transform.position = teleportDestination.position;
            }
        }
    }
}
