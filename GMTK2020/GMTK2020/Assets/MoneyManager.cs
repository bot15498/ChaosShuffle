using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public float currentMoney;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addMoney(float moneyToAdd)
    {
        currentMoney += moneyToAdd;
    }


    public void minusMoney(float moneyToMinus)
    {
        currentMoney -= moneyToMinus;
    }
}
