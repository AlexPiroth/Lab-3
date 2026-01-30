using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookstore : MonoBehaviour
{
    [SerializeField] int coverPrice;
    [SerializeField] int copies;

    // Start is called before the first frame update
    void Start()
    {
        double cost = CalcCost();
        double profit = CalcProfit(cost);
        Debug.Log("The cost is " + cost.ToString("C") + " and the profit is " + profit.ToString("C") + ".");
    }

    double CalcCost()
    {
        if (copies == 0) // This really shouldn't ever happen but just in case 
            return 0.0;
        double unitPrice = coverPrice * 0.6;
        double shipping = 3 + ((copies - 1) * 0.75);
        return (copies * unitPrice) + shipping;
    }

    double CalcProfit(double cost)
    {
        double income = coverPrice * copies;
        return (income - cost);
    }
}
