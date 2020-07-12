using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyOncontact : MonoBehaviour
{
    
    MoneyManager Mm;
    // Start is called before the first frame update
    void Start()
    {
        Mm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MoneyManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Mm.addMoney();
            
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Mm.addMoney();
            
            Destroy(gameObject);
        }
    }
}
