using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class CommunicationTest : MonoBehaviour
{
    public TextMeshProUGUI textField;

    [DllImport("__Internal")]
    private static extern void Test(string userName);

    public void UpdateTextField(string text)
    {
        textField.text = text;

        #if UNITY_WEBGL == true && UNITY_EDITOR == false
                Test ("Player1");
        #endif
    }
}
