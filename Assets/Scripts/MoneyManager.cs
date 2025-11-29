using System;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int money = 0;
    
    public TextMeshProUGUI moneyText;
    
    public void AddMoney(int value)
    {
        money += value;
        moneyText.text = money.ToString();
    }

    private void Awake()
    {
        instance = this;
    }
}
