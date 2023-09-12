using UnityEngine;

public class CurrencyConverter : MonoBehaviour
{
    public static CurrencyConverter Instance;
    
    public static CurrencyConverter GetInstance()
    {
        if (Instance is null)
        {
            Instance = new CurrencyConverter();
        }
        return Instance;
    }
    
    
    public string ConvertMoney(int amount)
    {
        string convertedMoney = "";

        if (amount >= 1000000)
        {
            double millions = (double)amount / 1000000.0;
            convertedMoney = millions.ToString("0.#") + "m";
        }
        else if (amount >= 1000)
        {
            double thousands = (double)amount / 1000.0;
            convertedMoney = thousands.ToString("0.#") + "k";
        }
        else
        {
            convertedMoney = amount.ToString();
        }

        return convertedMoney;
    }
}