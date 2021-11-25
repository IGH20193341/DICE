using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject main;

    public void Change_Image()
    {
        main.SetActive(false);
        gameObject.SetActive(true);
    }
}
