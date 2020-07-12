using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    public bool isSpinning = false;
    public float spinSpeed = 0.8f;
    private float currAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpinning)
        {
            float anglePerSecond = 360f / spinSpeed;
            currAngle += anglePerSecond * Time.deltaTime;
            currAngle = currAngle % 360f;
            transform.rotation = Quaternion.AngleAxis(currAngle, Vector3.forward);
        }
        else
        {
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
