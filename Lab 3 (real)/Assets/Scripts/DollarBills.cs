using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollarBills : MonoBehaviour
{
    [SerializeField] private int inputDollars;
    private string output;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(inputDollars);
        PrintResults();
    }

    void PrintResults()
    {
        output = "You will recieve ";
        if (inputDollars == 0)
            output += "no bills.";
        int currentValue = inputDollars;
        int[] billValues = { 100, 50, 20, 10, 5, 1 };
        foreach (int value in  billValues)
        {
            currentValue = CalcBillAmount(currentValue, value);
        }
        Debug.Log(output);
    }

    int CalcBillAmount(int currentValue, int billValue)
    {
        int numBills = currentValue / billValue; // Calculate the number of bills using integer division

        if (numBills == 0) // If there are no bills of the specified type, print nothing and return the same current value
            return currentValue;
        
        int newCurrentValue = currentValue - (numBills * billValue); // Calculate current value after removing the current bills

        string plural;  // Print "bill" if there is only one bill, else print "bills"
        if (numBills != 1)
            plural = "bills";
        else
            plural = "bill";


        if (newCurrentValue == 0) // If new current value is 0, meaning this is the last part of the output string, print the end of the string.
        {
            output += ("and " + numBills + " $" + billValue + " " + plural + ".");
            return 0;
        }

        output += (numBills + " $" + billValue + " " + plural + ", "); // Otherwise, add a segment to the output string and return the new current value.
        return newCurrentValue;
    }
}
