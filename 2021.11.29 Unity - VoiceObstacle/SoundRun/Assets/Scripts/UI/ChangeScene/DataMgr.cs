using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character
{
    Red, Blue, Green, Yellow, Purple, fcffa6, c1ffd7, b5deff, cab8ff, ff7878
}
public class DataMgr : MonoBehaviour
{
    public static DataMgr instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }

    public Character currentCharacter;
}
