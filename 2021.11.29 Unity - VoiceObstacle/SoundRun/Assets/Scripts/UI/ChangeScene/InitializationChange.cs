using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializationChange : MonoBehaviour
{
    public GameObject main;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;
    public GameObject gameObject4;
    public GameObject gameObject5;
    public GameObject gameObject6;
    public GameObject gameObject7;
    public GameObject gameObject8;
    public GameObject gameObject9;
    public GameObject gameObject10;

    public void Change_Image()
    {
        main.SetActive(true);
        gameObject1.SetActive(false);
        gameObject2.SetActive(false);
        gameObject3.SetActive(false);
        gameObject4.SetActive(false);
        gameObject5.SetActive(false);
        gameObject6.SetActive(false);
        gameObject7.SetActive(false);
        gameObject8.SetActive(false);
        gameObject9.SetActive(false);
        gameObject10.SetActive(false);
    }
}
