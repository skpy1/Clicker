using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchMenu : MonoBehaviour
{
    public int totalMoney;
    [SerializeField] Button firstAch;
    [SerializeField] bool isFirstAch;
    void Start()
    {
        totalMoney = PlayerPrefs.GetInt("totalMoney");
        isFirstAch = PlayerPrefs.GetInt("isFirstAch") == 1 ? true : false;
        if (totalMoney >= 100 && !isFirstAch)
        {
            firstAch.interactable = true;
        }
        else
        {
            firstAch.interactable = false;
        }
    }

    public void GetFirst()
    {
        int money = PlayerPrefs.GetInt("money");
        money += 100;
        PlayerPrefs.SetInt("money", money);
        int totalMoney = PlayerPrefs.GetInt("totalMoney");
        totalMoney += 100;
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        isFirstAch = true;
        PlayerPrefs.SetInt("isFirstAch", isFirstAch ? 1 : 0);
        firstAch.interactable = false;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        
    }
}
