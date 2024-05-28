using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchMenu : MonoBehaviour
{
    public int money;
    public int totalMoney;
    [SerializeField] Button firstAch;
    [SerializeField] bool isFirstAch;

    [SerializeField] Button secondAch;
    [SerializeField] bool isSecondAch;

    [SerializeField] Button thirdAch;
    [SerializeField] bool isThirdAch;

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        totalMoney = PlayerPrefs.GetInt("totalMoney");
        isFirstAch = PlayerPrefs.GetInt("isFirstAch") == 1 ? true : false;
        isSecondAch = PlayerPrefs.GetInt("isSecondAch") == 1 ? true : false;
        isThirdAch = PlayerPrefs.GetInt("isThirdAch") == 1 ? true : false;
        if (totalMoney >= 100 && !isFirstAch)
        {
            firstAch.interactable = true;
        }
        else
        {
            firstAch.interactable = false;
            StartCoroutine(IdleFarm());
        }
        if (totalMoney >= 1000 && !isSecondAch)
        {
            secondAch.interactable = true;
        }
        else
        {
            secondAch.interactable = false;
        }
        if (totalMoney >= 10000 && !isThirdAch)
        {
            thirdAch.interactable = true;
        }
        else
        {
            thirdAch.interactable = false;
        }
    }

    public void GetFirst(int n)
    {
        int money = PlayerPrefs.GetInt("money");
        money += n;
        Debug.Log(money);
        PlayerPrefs.SetInt("money", money);
        Debug.Log(PlayerPrefs.GetInt("money"));
        int totalMoney = PlayerPrefs.GetInt("totalMoney");
        totalMoney += n;
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        if (n == 100){
            isFirstAch = true;
            PlayerPrefs.SetInt("isFirstAch", 1);
            firstAch.interactable = false;
            PlayerPrefs.Save();
        }
        else if (n == 1000)
        {
            isSecondAch = true;
            PlayerPrefs.SetInt("isSecondAch", 1);
            secondAch.interactable = false;
            PlayerPrefs.Save();
        }
        else if (n == 10000)
        {
            isThirdAch = true;
            PlayerPrefs.SetInt("isThirdAch", 1);
            thirdAch.interactable = false;
            PlayerPrefs.Save();
        }
        PlayerPrefs.Save();
    }

    public void GetSecond()
    {
        int money = PlayerPrefs.GetInt("money");
        money += 1000;
        PlayerPrefs.SetInt("money", money);
        int totalMoney = PlayerPrefs.GetInt("totalMoney");
        totalMoney += 1000;
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        isSecondAch = true;
        PlayerPrefs.SetInt("isSecondAch", 1);
        secondAch.interactable = false;
        PlayerPrefs.Save();
    }

    public void GetThird()
    {
        int money = PlayerPrefs.GetInt("money");
        money += 10000;
        PlayerPrefs.SetInt("money", money);
        int totalMoney = PlayerPrefs.GetInt("totalMoney");
        totalMoney += 10000;
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        isThirdAch = true;
        PlayerPrefs.SetInt("isThirdAch", 1);
        thirdAch.interactable = false;
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money++;
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
