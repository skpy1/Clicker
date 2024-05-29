using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    [SerializeField] Button button;

    public void ToGame()
    {
        SceneManager.LoadScene(1);
    }
}
