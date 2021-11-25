using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Character character;

    private void OnMouseUpAsButton()
    {
        DataMgr.instance.currentCharacter = character;
    }
}
