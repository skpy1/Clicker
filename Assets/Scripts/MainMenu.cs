using System;
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
    public Text moneyText;
    public Text CoinPerClick;
    public Text CoinPerSec;
    public GameObject effect;
    public GameObject button;
    [SerializeField] public AudioSource audioSource;


    private void Start()
    {
        if (PlayerPrefs.GetInt("CoinPerClickValue") == 0)
        {
            PlayerPrefs.SetInt("CoinPerClickValue", 1);
        }
        //PlayerPrefs.DeleteAll();
        audioSource = GetComponent<AudioSource>();
        money = PlayerPrefs.GetInt("money");

        bool isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
        StartCoroutine(IdleFarm());
        //OfflineTime();
    }

    public void ButtonClick()
    {
        money += PlayerPrefs.GetInt("CoinPerClickValue");
        PlayerPrefs.SetInt("money", money);
        Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
        button.GetComponent<RectTransform>().localScale = new Vector3(0.95f, 0.95f, 0f);
        if(PlayerPrefs.GetInt("Sounds") == 0)
        {
            audioSource.Play();
        }
    }

    public void OnClickUp()
    {
        button.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money += PlayerPrefs.GetInt("CoinPerSecValue");
        PlayerPrefs.SetInt("money", money);
        StartCoroutine(IdleFarm());
    }

    private void OfflineTime()
    {
        TimeSpan ts;
        if (PlayerPrefs.HasKey("LastSession"))
        {
            ts = DateTime.Now - DateTime.Parse(PlayerPrefs.GetString("LastSession"));
            money += (int)ts.TotalSeconds;
        }
    }

#if UNITY_ANDROID && !UNITY_EDITOR

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
        }
    }
#else
    private void OnApplicationQuit()
    {
            PlayerPrefs.SetString("LastSession", DateTime.Now.ToString());
    }
#endif

    public void ToAchievements()
    {
        SceneManager.LoadScene(1);
    }

    public void ToShop()
    {
        SceneManager.LoadScene(2);
    }

    public void Sound()
    {
        if (PlayerPrefs.GetInt("Sounds") == 0)
        {
            PlayerPrefs.SetInt("Sounds", 1);
        }
        else 
        {
            PlayerPrefs.SetInt("Sounds", 0);
        }
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("Sounds") == 0)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
        CoinPerClick.text = PlayerPrefs.GetInt("CoinPerClickValue").ToString();
        CoinPerSec.text = PlayerPrefs.GetInt("CoinPerSecValue").ToString();
        moneyText.text = money.ToString();
    }
}
