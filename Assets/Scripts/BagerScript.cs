using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagerScript : MonoBehaviour
{
    public int bagerAmount;
    public float bagerUpgradeCost;
    public float bagerMoneyAdd;
    public Text bagerAmountText;
    public Text bagerUpgradeCostText;
    public Text bagerMoneyPerS;
    public static bool bagerIsLocked;
    public float bagerMoneyAddTotal;

    void Start()
    {
        defaultBager();
    }

    public void buyBager()
    {
        if (bagerIsLocked == false)
        {
            LogicScript.playerMoney -= bagerUpgradeCost;
            bagerMoneyAddTotal += bagerMoneyAdd;            
            LogicScript.moneyIncomePerSec += bagerMoneyAdd;
            bagerUpgradeCost = (float)(bagerUpgradeCost * 1.50)  ;
            bagerAmount += 1;
        }
    }
    void Update()
    {
        int bagerUpgradeCostInt = Mathf.FloorToInt(bagerUpgradeCost);
        int bagerMoneyAddTotalInt = Mathf.FloorToInt(bagerMoneyAddTotal);

        bagerAmountText.text = "x" + bagerAmount.ToString();
        bagerUpgradeCostText.text = bagerUpgradeCostInt.ToString();
        bagerMoneyPerS.text = bagerMoneyAddTotalInt.ToString() + "/s";
        
        if (LogicScript.playerMoney >= bagerUpgradeCost)
        {
            bagerIsLocked = false;
        }
        else
        {
            bagerIsLocked = true;            
        }
    }
    public void defaultBager()
    {
        bagerAmount = 0;
        bagerUpgradeCost = 100;
        bagerMoneyAdd = 3;
        bagerIsLocked = true;
        bagerMoneyAddTotal = 0;
    }
}
