using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void SceneChange1()
    {
        SceneManager.LoadScene("SoundRun");
    }

    public void SceneChange2()
    {
        SceneManager.LoadScene("MyPage");
    }

    public void SceneChange3()
    {
        SceneManager.LoadScene("Option");
    }
}
