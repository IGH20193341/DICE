using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPageClick : MonoBehaviour
{
    public void DecoChar()
    {
        SceneManager.LoadScene("CustomCharacter");
    }
    public void ChangePW()
    {
        SceneManager.LoadScene("SoundRun");
    }
    public void CheckRecord()
    {
        SceneManager.LoadScene("SoundRun");
    }
}
