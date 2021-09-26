using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        GameObject _Play = GameObject.Find("Play");
        _Play.GetComponent<Button>().onClick.AddListener(GetPlay);
    }

    private void GetPlay()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
