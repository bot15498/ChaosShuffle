using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    RoomManager Rm;
    EnemyManager Em;
    public Transform teleportDestination;
    // Start is called before the first frame update
    void Awake()
    {
        Rm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RoomManager>();
        Rm.setExitDoor(gameObject.transform.GetChild(0).gameObject);
        teleportDestination = Rm.entranceDoor.transform;
        Em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>();

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Em.currentNumberofenemies <= 0)
        {
          
            collision.gameObject.transform.position = teleportDestination.position;

        }
    }
}
