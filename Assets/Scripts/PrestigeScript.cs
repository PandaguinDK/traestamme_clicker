using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrestigeScript : MonoBehaviour
{
    public int prestigeAmount;
    public float prestigeUpgradeCost;
    public float prestigeMultiplierAdd;
    public Text prestigeAmountText;
    public Text prestigeUpgradeCostText;
    public static bool prestigeIsLocked;
    // bool force = false;
    // public GameObject prestigeConfirmationBox;

    void Start()
    {
        prestigeAmount = 0;
        prestigeUpgradeCost = 10000;
        prestigeMultiplierAdd = (float)0.50;
        prestigeIsLocked = true;
    }

    [ContextMenu("Prestige")]
    public void buyPrestige()
    {
        if (prestigeIsLocked == false)
        {
            // prestigeConfirmation();
    
            prestigeUpgradeCost = (float)(prestigeUpgradeCost * 2)  ;
            prestigeAmount = prestigeAmount + 1;
            gameObject.GetComponent<LogicScript>().defaultLogic();
            gameObject.GetComponent<TræstammeScript>().defaultTræstamme();
            gameObject.GetComponent<BagerScript>().defaultBager();
            gameObject.GetComponent<FactoryScript>().defaultFactory();
            LogicScript.moneyIncomeMultiplier += prestigeMultiplierAdd;
            prestigeMultiplierAdd += (float)0.50;

        }
    }

    // Ville lave en confirmation pop-up når man trykker prestige, som også fortæller om hvad det gør, men vi havde ikke tid til at lave det.

    // void prestigeConfirmation()
    // {
    //     instantiatedPrestigeConfirmationBox = Instantiate(prestigeConfirmationBox, canvas.transform, force);
    // }
    

    void Update()
    {
        int prestigeUpgradeCostInt = Mathf.FloorToInt(prestigeUpgradeCost);

        prestigeAmountText.text = "x" + prestigeAmount.ToString();
        prestigeUpgradeCostText.text = prestigeUpgradeCostInt.ToString();
        
        if (LogicScript.playerMoney >= prestigeUpgradeCost)
        {
            prestigeIsLocked = false;
        }
        else
        {
            prestigeIsLocked = true;            
        }
    }
}
