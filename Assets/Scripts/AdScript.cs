using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AdScript : MonoBehaviour
{
    public GameObject button;
    void Start()
    {
        button.SetActive(false);
        StartCoroutine(IdleFarm());
    }

    public void CloseAd()
    {
        SceneManager.LoadScene(3);

    }

    IEnumerator IdleFarm()
    {
        yield return new WaitForSeconds(7);
        button.SetActive(true);
    }
}
