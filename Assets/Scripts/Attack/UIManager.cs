using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Text wolfHealthText;
    public Text PickUpToggleBtnTxt;
    private void Awake()
    {
        base.RegisterSingleton();
    }
}
