using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate;
    public GameObject bulletToSpawn;
    public Transform gunBarrel;
    public float recoilForce;
    public Rigidbody2D rb;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && timer >= fireRate)
        {
            
            Instantiate(bulletToSpawn, gunBarrel.position, gunBarrel.rotation);
            timer = 0;
        }
    }



    void Recoil()
    {
        Vector3 force = -gunBarrel.transform.right * recoilForce;
        rb.AddForce(force);
    }
}
