using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{
    #region Singeleton Instance 
    private static UIController instance;

    public static UIController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<UIController>();
            }
            return instance;
        }
    }
    #endregion

    public void SwitchToRacing()
    {

    }
}
