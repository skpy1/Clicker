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
    public int totalMoney;
    public Text moneyText;
    public GameObject effect;
    public GameObject button;
    public AudioSource audioSource;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        audioSource = GetComponent<AudioSource>();
        money = PlayerPrefs.GetInt("money");
        totalMoney = PlayerPrefs.GetInt("totalMoney");
        Debug.Log(money);

        bool isFirst = PlayerPrefs.GetInt("isFirst") == 1 ? true : false;
        StartCoroutine(IdleFarm());
        //OfflineTime();
    }

    public void ButtonClick()
    {
        money += 10;
        totalMoney += 10;
        PlayerPrefs.SetInt("money", money);
        PlayerPrefs.SetInt("totalMoney", totalMoney);
        Instantiate(effect, button.GetComponent<RectTransform>().position.normalized, Quaternion.identity);
        button.GetComponent<RectTransform>().localScale = new Vector3(0.95f, 0.95f, 0f);
        audioSource.Play();
    }

    public void OnClickUp()
    {
        button.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 0f);
    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(1);
        money++;
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

    void Update()
    {
        moneyText.text = money.ToString();
    }
}
