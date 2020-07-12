using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    public bool isSpinning = false;
    public float spinSpeed = 0.8f;
    public float trackingSpeed;
    private Transform player;
    private float currAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSpinning)
        {
            Vector3 vectorToTarget = player.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * trackingSpeed);
        }
        else
        {
            float anglePerSecond = 360f / spinSpeed;
            currAngle += anglePerSecond * Time.deltaTime;
            currAngle = currAngle % 360f;
            transform.rotation = Quaternion.AngleAxis(currAngle, Vector3.forward);
        }
    }
}
