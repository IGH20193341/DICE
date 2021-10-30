using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Windows.Speech;
using System.Linq;

// 참고링크 : https://docs.microsoft.com/en-us/windows/mixed-reality/develop/unity/voice-input-in-unity#enabling-the-capability-for-voice

public class UserSound : MonoBehaviour
{
    // PhraseRecognitionSystem.isSupported;
    KeywordRecognizer keywordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Start is called before the first frame update
    void Start()
    {
        //Create keywords for keyword recognizer
        keywords.Add("go", () =>
        {
            // action to be performed when this keyword is spoken
            
        });
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
        // Debug.Log("성공");
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        // if the keyword recognized is in our dictionary, call that Action.
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
            Debug.Log("perfect!!");
        }
    }

    void GoCalled()
    {
        // keywordAction.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        // keywordRecognizer.Start();
    }
}
