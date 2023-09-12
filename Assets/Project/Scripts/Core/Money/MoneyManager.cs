using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    
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
        if (Instance == null)
        {
            Instance = this;
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
        MoneyChanged?.Invoke(money);
        SaveMoney();
    }

    public void SpendMoney(int amount)
    {
        if (money >= amount)
        {
            money -= amount;
            MoneyChanged?.Invoke(money);
            SaveMoney(); 
        }
    }

    private void SaveMoney()
    {
        SaveManager.GetInstance().SaveData(GameDataType.Money, money);
        PlayerPrefs.Save();
    }

    private void LoadMoney()
    {
        if (PlayerPrefs.HasKey(GameDataType.Money.ToString()))
        {
            money = SaveManager.GetInstance().LoadData(GameDataType.Money);
        }
    }
}