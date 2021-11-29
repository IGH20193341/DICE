using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buy : MonoBehaviour
{
    public GameObject gameObjectLock;
    public GameObject gameObjectBuy;
//    public int characterNum;


    public void delete()
    {
        Destroy(gameObjectLock);
        gameObjectBuy.SetActive(false);
    }
}
