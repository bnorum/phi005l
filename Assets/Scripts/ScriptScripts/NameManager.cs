using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameManager : MonoBehaviour
{

    public TMP_InputField nameInput;

    public void SetName() {
        characterDeets.pName = nameInput.text;
    }
}
