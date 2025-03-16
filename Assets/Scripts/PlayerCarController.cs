using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private PlayerTrigger playerTrigger;
    [SerializeField] private Animator playerCarAnimator;
    [SerializeField] private PlayerCarInputController playerInputController;
    #endregion

    private void Start()
    {
        playerTrigger.onPlayerCarTrigger += OnPlayerCarTrigger;
    }
    public static PlayerCarController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnPlayerCarTrigger(bool isEnterTriggered)
    {
        playerInputController.DisplayToastMessage(isEnterTriggered);
    }

    public void CloseCarDoor() => playerCarAnimator.SetTrigger("carClose");
    public void OpenCarDoor()=> playerCarAnimator.SetTrigger("carOpen");
}
