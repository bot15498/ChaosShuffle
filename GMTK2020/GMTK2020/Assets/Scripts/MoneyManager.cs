using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MoneyManager : MonoBehaviour
{
    public Text moneyText;
    public float dollaAmount;
    public float currentMoney;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + currentMoney.ToString();
    }


    public void addMoney()
    {
        currentMoney += dollaAmount;
    }


    public void minusMoney(float moneyToMinus)
    {
        currentMoney -= moneyToMinus;
    }
}
