using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int money;
    public Text moneyText;

    public void ButtonClick()
    {
        money++;
    }

    void Update()
    {
        moneyText.text = money.ToString();
    }
}
