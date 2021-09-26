using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [Header("Setting Putaran Utama")]
    [SerializeField] private float rotasi_SelTelur; 
    [SerializeField] private float rotasi_Sperma;

    [Header("Setting Rotasi Sperma")]
    [SerializeField] private float Rotasi_Sperma1;
    [SerializeField] private float Rotasi_Sperma2;
    [SerializeField] private float Rotasi_Sperma3;

    [Header("Game Object")]
    [SerializeField] private GameObject SelTelur;
    [SerializeField] private GameObject[] Sperma;
    [SerializeField] private GameObject[] TitikRotasi;

    [Header("Audio")]
    [SerializeField] private AudioSource audio;

    GameObject _Play,_Stop;
    private bool isRotate;

    private void Start()
    {
        SetBTN();
        isRotate = false;
    }
    // Update is called once per frame
    void Update()
    {
        Rotasi_Satu();
        Rotasi_Dua();
        Rotasi_Tiga();
        Rotasi_Sperma();
        Rotasi_SelTelur();

        if(isRotate == true)
        {
            _Play.GetComponent<Button>().interactable = false;
            _Stop.GetComponent<Button>().interactable = true;
        }
        else
        {
            _Play.GetComponent<Button>().interactable = true;
            _Stop.GetComponent<Button>().interactable = false;
        }
    }

    private void SetBTN()
    {
        _Play = GameObject.Find("PLAY");
        _Stop = GameObject.Find("STOP");
        GameObject _Back = GameObject.Find("BACK");

        _Play.GetComponent<Button>().onClick.AddListener(GetStartRotate);
        _Stop.GetComponent<Button>().onClick.AddListener(GetStopRotate);
        _Back.GetComponent<Button>().onClick.AddListener(GetBack);
    }

    private void GetStartRotate()
    {
        audio.Play();
        rotasi_SelTelur = -0.5f;
        rotasi_Sperma = 8;
        Rotasi_Sperma1 = -0.75f;
        Rotasi_Sperma2 = -0.6f;
        Rotasi_Sperma3 = -0.5f;
        isRotate = true;
    }

    private void GetStopRotate()
    {
        audio.Pause();
        rotasi_SelTelur = 0f;
        rotasi_Sperma = 0f;
        Rotasi_Sperma1 =  0f;
        Rotasi_Sperma2 = 0f;
        Rotasi_Sperma3 = 0f;
        isRotate = false;
    }

    private void GetBack()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Rotasi_Satu()
    {
        TitikRotasi[0].transform.Rotate(0, Rotasi_Sperma1, 0);
    }

    private void Rotasi_Dua()
    {
        TitikRotasi[1].transform.Rotate(0, Rotasi_Sperma2, 0);
    }

    private void Rotasi_Tiga()
    {
        TitikRotasi[2].transform.Rotate(0, Rotasi_Sperma3, 0);
    }

    private void Rotasi_SelTelur()
    {
        SelTelur.transform.Rotate(0, rotasi_SelTelur, 0);
    }

    private void Rotasi_Sperma()
    {
        for(int i = 0; i<Sperma.Length; i++)
            Sperma[i].transform.Rotate(0, 0, rotasi_Sperma);
    }
}
