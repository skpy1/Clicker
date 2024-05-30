using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    private static Music instance;
    [SerializeField] public AudioSource audioSource;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
    public void Sound()
    {
        if (PlayerPrefs.GetInt("Sounds") == 0)
        {
            PlayerPrefs.SetInt("Sounds", 1);
            Debug.Log(PlayerPrefs.GetInt("Sounds"));
        }
        else
        {
            PlayerPrefs.SetInt("Sounds", 0);
            Debug.Log(PlayerPrefs.GetInt("Sounds"));
        }
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "AdScene")
        {
            audioSource.enabled = false;
        }
        if (PlayerPrefs.GetInt("Sounds") == 0)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }
}
