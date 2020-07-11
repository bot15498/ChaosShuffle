using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int currentNumberofenemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentNumberofenemies <= 0)
        {
            //Ya Win
        }
    }

    public void addEnemy()
    {
        currentNumberofenemies += 1;
    }


    public void minusEnemy()
    {
        currentNumberofenemies -= 1;
    }
}
