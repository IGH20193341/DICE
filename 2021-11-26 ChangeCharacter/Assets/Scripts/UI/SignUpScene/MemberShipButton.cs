using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemberShipButton : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("LoginScene");

    }
}
