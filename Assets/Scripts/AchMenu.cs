using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AchMenu : MonoBehaviour
{
    public int money;
    [SerializeField] Button firstAch;
    [SerializeField] bool isFirstAch;

    [SerializeField] Button secondAch;
    [SerializeField] bool isSecondAch;

    [SerializeField] Button thirdAch;
    [SerializeField] bool isThirdAch;

    [SerializeField] Button fourthAch;
    [SerializeField] bool isFourthAch;

    [SerializeField] Button fifthAch;
    [SerializeField] bool isFfifthAch;

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        isFirstAch = PlayerPrefs.GetInt("isFirstAch") == 1 ? true : false;
        isSecondAch = PlayerPrefs.GetInt("isSecondAch") == 1 ? true : false;
        isThirdAch = PlayerPrefs.GetInt("isThirdAch") == 1 ? true : false;
        isFourthAch = PlayerPrefs.GetInt("isFourthAch") == 1 ? true : false;
        isFfifthAch = PlayerPrefs.GetInt("isFfifthAch") == 1 ? true : false;
        if (money >= 100 && !isFirstAch && PlayerPrefs.GetInt("isFirstAchPressed") == 0)
        {
            firstAch.interactable = true;
        }
        else
        {
            firstAch.interactable = false;
            StartCoroutine(IdleFarm());
        }
        if (money >= 1000 && !isSecondAch && PlayerPrefs.GetInt("isSecondAchPressed") == 0)
        {
            secondAch.interactable = true;
        }
        else
        {
            secondAch.interactable = false;
            StartCoroutine(IdleFarm());
        }
        if (money >= 10000 && !isThirdAch && PlayerPrefs.GetInt("isThirdAchPressed") == 0)
        {
            thirdAch.interactable = true;
        }
        else
        {
            thirdAch.interactable = false;
            StartCoroutine(IdleFarm());
        }
        if (money >= 100000 && !isFourthAch && PlayerPrefs.GetInt("isFourthAchPressed") == 0)
        {
            thirdAch.interactable = true;
        }
        else
        {
            thirdAch.interactable = false;
            StartCoroutine(IdleFarm());
        }
        if (money >= 1000000 && !isFourthAch && PlayerPrefs.GetInt("isFfifthAchPressed") == 0)
        {
            thirdAch.interactable = true;
        }
        else
        {
            thirdAch.interactable = false;
            StartCoroutine(IdleFarm());
        }
    }

    public void GetFirst(int n)
    {
        int money = PlayerPrefs.GetInt("money");
        money += n;
        PlayerPrefs.SetInt("money", money);
        if (n == 100){
            isFirstAch = true;
            PlayerPrefs.SetInt("isFirstAch", 1);
            PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 1);
            firstAch.interactable = false;
            PlayerPrefs.SetInt("isFirstAchPressed", 1);
        }
        if (n == 1000)
        {
            isSecondAch = true;
            PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 10);
            secondAch.interactable = false;
            PlayerPrefs.SetInt("isSecondAchPressed", 1);
        }
        if (n == 10000)
        {
            isThirdAch = true;
            PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 100);
            thirdAch.interactable = false;
            PlayerPrefs.SetInt("isThirdAchPressed", 1);
        }
        if (n == 100000)
        {
            isThirdAch = true;
            PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 1000);
            thirdAch.interactable = false;
            PlayerPrefs.SetInt("isFourthAchPressed", 1);
        }
        if (n == 1000000)
        {
            isThirdAch = true;
            PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 10000);
            thirdAch.interactable = false;
            PlayerPrefs.SetInt("isFfifthAchPressed", 1);
        }
        PlayerPrefs.Save();
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money += PlayerPrefs.GetInt("CoinPerSecValue");
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
