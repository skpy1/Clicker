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
    [SerializeField] bool isFifthAch;

    public Sprite spriteImage;
    public Image imgObj;
    public Image imgObj2;
    public Image imgObj3;
    public Image imgObj4;
    public Image imgObj5;

    [SerializeField] public bool imgObjIsShow;
    [SerializeField] public bool imgObj2IsShow;
    [SerializeField] public bool imgObj3IsShow;
    [SerializeField] public bool imgObj4IsShow;
    [SerializeField] public bool imgObj5IsShow;



    void Start()
    {
        money = PlayerPrefs.GetInt("money");
        isFirstAch = PlayerPrefs.GetInt("isFirstAch") == 1 ? true : false;
        isSecondAch = PlayerPrefs.GetInt("isSecondAch") == 1 ? true : false;
        isThirdAch = PlayerPrefs.GetInt("isThirdAch") == 1 ? true : false;
        isFourthAch = PlayerPrefs.GetInt("isFourthAch") == 1 ? true : false;
        isFifthAch = PlayerPrefs.GetInt("isFifthAch") == 1 ? true : false;

        imgObjIsShow = PlayerPrefs.GetInt("imgObjIsShow") == 1 ? true : false;
        imgObj2IsShow = PlayerPrefs.GetInt("imgObj2IsShow") == 1 ? true : false;
        imgObj3IsShow = PlayerPrefs.GetInt("imgObj3IsShow") == 1 ? true : false;
        imgObj4IsShow = PlayerPrefs.GetInt("imgObj4IsShow") == 1 ? true : false;
        imgObj5IsShow = PlayerPrefs.GetInt("imgObj5IsShow") == 1 ? true : false;

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
            fourthAch.interactable = true;
        }
        else
        {
            fourthAch.interactable = false;
            StartCoroutine(IdleFarm());
        }
        if (money >= 1000000 && !isFourthAch && PlayerPrefs.GetInt("isFifthAchPressed") == 0)
        {
            fifthAch.interactable = true;
        }
        else
        {
            fifthAch.interactable = false;
            StartCoroutine(IdleFarm());
        }
    }

    public void GetFirst(int n)
    {
        int money = PlayerPrefs.GetInt("money");
        money += n;
        PlayerPrefs.SetInt("money", money);
        if (n == 100)
        {
            isFirstAch = true;
            PlayerPrefs.SetInt("isFirstAch", 1);
            PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 1);
            firstAch.interactable = false;
            PlayerPrefs.SetInt("isFirstAchPressed", 1);
            PlayerPrefs.SetInt("imgObjIsShow", 1);
        }
        if (n == 1000)
        {
            isSecondAch = true;
            PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 10);
            secondAch.interactable = false;
            PlayerPrefs.SetInt("isSecondAchPressed", 1);
            PlayerPrefs.SetInt("imgObj2IsShow", 1);
        }
        if (n == 10000)
        {
            isThirdAch = true;
            PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 100);
            thirdAch.interactable = false;
            PlayerPrefs.SetInt("isThirdAchPressed", 1);
            PlayerPrefs.SetInt("imgObj3IsShow", 1);
        }
        if (n == 100000)
        {
            isFourthAch = true;
            PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 1000);
            fourthAch.interactable = false;
            PlayerPrefs.SetInt("isFourthAchPressed", 1);
            PlayerPrefs.SetInt("imgObj4IsShow", 1);
        }
        if (n == 1000000)
        {
            isFifthAch = true;
            PlayerPrefs.SetInt("CoinPerSecValue", PlayerPrefs.GetInt("CoinPerSecValue") + 10000);
            fifthAch.interactable = false;
            PlayerPrefs.SetInt("isFifthAchPressed", 1);
            PlayerPrefs.SetInt("imgObj5IsShow", 1);
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

    void Update()
    {
        if (PlayerPrefs.GetInt("imgObjIsShow") == 1)
        {
            imgObj.sprite = spriteImage;
        }
        if (PlayerPrefs.GetInt("imgObj2IsShow") == 1)
        {
            imgObj2.sprite = spriteImage;
        }
        if (PlayerPrefs.GetInt("imgObj3IsShow") == 1)
        {
            imgObj3.sprite = spriteImage;
        }
        if (PlayerPrefs.GetInt("imgObj4IsShow") == 1)
        {
            imgObj4.sprite = spriteImage;
        }
        if (PlayerPrefs.GetInt("imgObj5IsShow") == 1)
        {
            imgObj5.sprite = spriteImage;
        }
    }
}
