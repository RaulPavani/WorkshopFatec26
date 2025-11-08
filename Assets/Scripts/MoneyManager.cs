using System;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int money = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddMoney(int value)
    {
        money += value;
    }

  
}
