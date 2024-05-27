using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data.SqlTypes;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int money;
    public int totalMoney;
    public Text moneyText;
   
    private void Start()
    {
        moneyText.text = "0";
        //PlayerPrefs.DeleteAll();
        money = PlayerPrefs.GetInt("money");
        totalMoney = PlayerPrefs.GetInt("totalMoney");
    }

    public void ButtonClick()
    {
        money++;
        totalMoney++;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("totalMoney", totalMoney);
    }

    public void ToAchievements()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        moneyText.text = money.ToString();
    }
}
