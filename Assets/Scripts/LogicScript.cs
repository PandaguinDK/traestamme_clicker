using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogicScript : MonoBehaviour
{
    //Det her er vores variabler som vi kommer til at bruge gennem
    public static float playerMoney;
    public Text playerMoneyText;
    public Text playerMoneyPerSecText;
    public static float moneyIncome;
    public static float moneyIncomePerSec;
    public static float moneyIncomeMultiplier;

    void Start()
    {
        InvokeRepeating("moneyPerSec", 0f, 1f);
        defaultLogic();
    }
    //Dette er vores funktion, som sker når du trykker på vores træstamme, hvilket ændre i vores værdiere som vi addere og tager fra i andre scripts
    public void addMoney()
    {
        playerMoney += moneyIncome * moneyIncomeMultiplier;
    }

    void moneyPerSec()
    {
        playerMoney += moneyIncomePerSec * moneyIncomeMultiplier;
    }

    public void Update()
        {
            int playerMoneyInt = Mathf.FloorToInt(playerMoney);
            int playerMoneyPerSecInt = Mathf.FloorToInt(moneyIncomePerSec * moneyIncomeMultiplier);

            playerMoneyText.text = playerMoneyInt.ToString() + " Traestammer";
            playerMoneyPerSecText.text = playerMoneyPerSecInt.ToString() + " Traestammer / s";
        }   
    public void defaultLogic()
    {
        playerMoney = 0;
        moneyIncome = 1;
        moneyIncomePerSec = 0;
        moneyIncomeMultiplier = 1;
    }

    [ContextMenu("Hemmlig knap")]
    public void tooMuchMoney()
    {
        playerMoney += 100000;
    }

}


