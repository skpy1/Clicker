using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data.SqlTypes;
using Unity.VisualScripting;

public class ShopMenu : MonoBehaviour
{
    public int money;
    [SerializeField] Button CoinPerClick;
    [SerializeField] Button CoinPerAfk;

    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        StartCoroutine(IdleFarm());
    }

    public void byCoinPerClick()
    {
        if (PlayerPrefs.GetInt("CoinPerClickValue") == 0)
        {
            PlayerPrefs.SetInt("CoinPerClickValue", 1);
        }

        PlayerPrefs.SetInt("CoinPerClickValue", PlayerPrefs.GetInt("CoinPerClickValue") + 1);
    }

    public void byCoinPerSec()
    {
        PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 1);
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
