using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public float roomsCleared;
    public GameObject shop;
    public GameObject[] Rooms;
    public GameObject entranceDoor;
    public GameObject exitdoor;
    public Vector3 offset;
    public int shopinterval;
    [SerializeField]
    float shoptimer;
    // Start is called before the first frame update
    void Start()
    {
        shopinterval = 3;
        shoptimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createRoom(GameObject entrancedoor)
    {
        if (shoptimer < shopinterval)
        {
            Instantiate(Rooms[Random.Range(0, Rooms.Length)], entranceDoor.transform.position + offset, gameObject.transform.rotation);
            roomsCleared += 1;
            shoptimer += 1;
        }else

        if (shoptimer >= shopinterval) {

            Instantiate(shop, entranceDoor.transform.position + offset, gameObject.transform.rotation);
            shopinterval = Random.Range(3, 5);
            shoptimer = 0;
        }

        
    }

    public void setEntranceDoor(GameObject doorToSet)
    {
        entranceDoor = doorToSet;
    }

    public void setExitDoor(GameObject exitdoorToSet)
    {
        exitdoor = exitdoorToSet;
    }
}
