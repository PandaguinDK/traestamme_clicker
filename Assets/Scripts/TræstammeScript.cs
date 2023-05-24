using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TræstammeScript : MonoBehaviour
{
    public int træstammeAmount;
    public float træstammeUpgradeCost;
    public float træstammeMoneyAdd;
    public Text træstammeAmountText;
    public Text træstammeMoneyAddText;
    public Text træstammeUpgradeCostText;
    public static bool træstammeIsLocked;
    public float træstammeMoneyAddTotal;

    void Start()
    {
        defaultTræstamme();
    }

    public void buyTræstammer()
    {
        if (træstammeIsLocked == false)
        {
            LogicScript.playerMoney -= træstammeUpgradeCost;
            træstammeMoneyAddTotal += træstammeMoneyAdd;
            LogicScript.moneyIncome += træstammeMoneyAdd;
            træstammeUpgradeCost = (float)(træstammeUpgradeCost * 1.50)  ;
            træstammeAmount = træstammeAmount + 1;
        }
    }
    void Update()
    {
        int træstammeUpgradeCostInt = Mathf.FloorToInt(træstammeUpgradeCost);
        int træstammeMoneyAddInt = Mathf.FloorToInt(træstammeMoneyAddTotal);

        træstammeAmountText.text = "x" + træstammeAmount.ToString();
        træstammeUpgradeCostText.text = træstammeUpgradeCostInt.ToString();
        træstammeMoneyAddText.text = træstammeMoneyAddInt.ToString();
        
        if (LogicScript.playerMoney >= træstammeUpgradeCost)
        {
            
            træstammeIsLocked = false;
        }
        else
        {
            træstammeIsLocked = true;            
        }
    }
    public void defaultTræstamme()
    {
        træstammeAmount = 0;
        træstammeUpgradeCost = 10;
        træstammeMoneyAdd = 1;
        træstammeIsLocked = true;
        træstammeMoneyAddTotal = 1;
    }
}
