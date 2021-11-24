using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class Gamemanager : MonoBehaviour
{
    [Header("LoginPanel")]
    public InputField IDInputField;
    public InputField PWInputField;
    [Header("CreatePanel")]
    public InputField New_IDInputField;
    public InputField New_PWInputField;
    public GameObject CreatePanelObj;
    // Start is called before the first frame update

    public string LoginUrl;
    public string CreateUrl;

    void Start()
    {
        LoginUrl = "http://localhost/swphp/login.php";
        CreateUrl = "http://localhost/swphp/create.php";
    }


    public void LoginBtn()
    {
        StartCoroutine(LoginCo());
    }
    
    IEnumerator LoginCo()
    {   
        Debug.Log(IDInputField.text);
        Debug.Log(PWInputField.text);

        WWWForm form = new WWWForm();
        form.AddField("Input_user", IDInputField.text);
        form.AddField("Input_pass", PWInputField.text);

        UnityWebRequest www = UnityWebRequest.Post(LoginUrl, form);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
        }
        // WWW wedRequest = new WWW(LoginUrl, form);
        // yield return wedRequest;
        

        // Debug.Log(wedRequest.text);
    }

    public void OpenCreateAccountBtn(){

        CreatePanelObj.SetActive(true);

    }

    public void CreateBtn()
    {
        StartCoroutine(CreateCo());
    }
    IEnumerator CreateCo()
    {   
        WWWForm form = new WWWForm();
        form.AddField("Input_user", New_IDInputField.text);
        form.AddField("Input_pass", New_PWInputField.text);

        UnityWebRequest www = UnityWebRequest.Post(CreateUrl, form);
        yield return www.SendWebRequest();
 
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
        }
        // WWW wedRequest = new WWW(LoginUrl, form);
        // yield return wedRequest;
        

        // Debug.Log(wedRequest.text);
    }
}
