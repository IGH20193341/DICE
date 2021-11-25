using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public GameObject main;
    public GameObject gameObjectT;
    public GameObject gameObjectF1;
    public GameObject gameObjectF2;
    public GameObject gameObjectF3;
    public GameObject gameObjectF4;
    public GameObject gameObjectF5;
    public GameObject gameObjectF6;
    public GameObject gameObjectF7;
    public GameObject gameObjectF8;
    public GameObject gameObjectF9;
    

    public void Change_Image()
    {
        main.SetActive(false);
        gameObjectT.SetActive(true);
        gameObjectF1.SetActive(false);
        gameObjectF2.SetActive(false);
        gameObjectF3.SetActive(false);
        gameObjectF4.SetActive(false);
        gameObjectF5.SetActive(false);
        gameObjectF6.SetActive(false);
        gameObjectF7.SetActive(false);
        gameObjectF8.SetActive(false);
        gameObjectF9.SetActive(false);
    }
}
