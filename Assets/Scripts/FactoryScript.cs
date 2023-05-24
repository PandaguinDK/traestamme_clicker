using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryScript : MonoBehaviour
{
    public int factoryAmount;
    public float factoryUpgradeCost;
    public float factoryMoneyAdd;
    public Text factoryAmountText;
    public Text factoryUpgradeCostText;
    public Text factoryPerS;
    public static bool factoryIsLocked;
    public float factoryMoneyAddTotal;

    void Start()
    {
        defaultFactory();
    }

    public void buyFactory()
    {
        if (factoryIsLocked == false)
        {
            LogicScript.playerMoney -= factoryUpgradeCost;
            factoryMoneyAddTotal += factoryMoneyAdd;
            LogicScript.moneyIncomePerSec += factoryMoneyAddTotal;
            factoryUpgradeCost = (float)(factoryUpgradeCost * 1.50)  ;
            factoryAmount += 1;
        }
    }
    void Update()
    {
        int factoryUpgradeCostInt = Mathf.FloorToInt(factoryUpgradeCost);
        int factoryMoneyAddTotalInt = Mathf.FloorToInt(factoryMoneyAddTotal); 

        factoryAmountText.text = "x" + factoryAmount.ToString();
        factoryUpgradeCostText.text = factoryUpgradeCostInt.ToString();
        factoryPerS.text = factoryMoneyAddTotalInt.ToString() + "/s";
        
        if (LogicScript.playerMoney >= factoryUpgradeCost)
        {
            factoryIsLocked = false;
        }
        else
        {
            factoryIsLocked = true;            
        }
    }
    public void defaultFactory()
    {
        factoryAmount = 0;
        factoryUpgradeCost = 1000;
        factoryMoneyAdd = 10;
        factoryIsLocked = true;
        factoryMoneyAddTotal = 0;
    }
}
