using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighScore : MonoBehaviour
{
    Text textscore;
    RoomManager Rm;
    // Start is called before the first frame update
    void Start()
    {
        Rm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RoomManager>();
        textscore = GetComponent<Text>();
        textscore.text = Rm.roomsCleared.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
