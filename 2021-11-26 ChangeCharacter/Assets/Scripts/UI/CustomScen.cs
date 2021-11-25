using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomScen : MonoBehaviour
{
    public void SceneChange()
    {
        SceneManager.LoadScene("CustomCharacter");
    }
}
