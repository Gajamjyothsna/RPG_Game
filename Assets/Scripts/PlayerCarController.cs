using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private PlayerTrigger playerTrigger;
    [SerializeField] private Animator playerCarAnimator;
    [SerializeField] private PlayerInputController playerInputController;
    #endregion

    private void Start()
    {
        playerTrigger.onPlayerCarTrigger += OnPlayerCarTrigger;
    }

    private void OnPlayerCarTrigger(bool isEnterTriggered)
    {
        playerInputController.DisplayToastMessage(isEnterTriggered);
    }

    private void CloseCarDoor() => playerCarAnimator.SetTrigger("carClose");
    private void OpenCarDoor()=> playerCarAnimator.SetTrigger("carOpen");
}
