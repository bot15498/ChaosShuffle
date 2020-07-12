using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectOnHIt : MonoBehaviour
{
    public GameObject money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Instantiate(money, transform.position, transform.rotation * Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
    }
}
