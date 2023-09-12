using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    
    [SerializeField] private int money = 0;
    public int Money
    {
        get => money;
        set => money = value;
    }
    
    public delegate void MoneyChangedEventHandler(int newMoney);
    public event MoneyChangedEventHandler MoneyChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadMoney();
    }

    public void AddMoney(int amount)
    {
        money += amount;
        SaveMoney();
    }

    public void SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            SaveMoney(); 
        }
    }

    private void SaveMoney()
    {
        SaveManager.GetInstance().SaveData(DataType.Money, money);
        PlayerPrefs.Save();
    }

    private void LoadMoney()
    {
        if (PlayerPrefs.HasKey(DataType.Money.ToString()))
        {
            money = SaveManager.GetInstance().LoadData(DataType.Money);
        }
    }
}