using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarInputController : MonoBehaviour
{
    [SerializeField] private GameObject ToastMessage;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Transform playerPositionInCar;

    

    private GameObject refPlayer;

    private bool isToastMessageActive = false;
    public void DisplayToastMessage(bool enableToastMessage)
    {
        if(enableToastMessage && !isToastMessageActive)
        {
            ToastMessage.SetActive(true);
            isToastMessageActive=true;
            Invoke(nameof(DisableToastMessage), 1.5f);
        }
    }

    private void DisableToastMessage()
    {
        ToastMessage.SetActive(false);
        isToastMessageActive = false;
    }

    private void Update()
    {
        if (isToastMessageActive && Input.GetKeyDown(KeyCode.U))
        {
            refPlayer = player;
        }
        else refPlayer = null;
        if (refPlayer != null) OpenCarDoor();
    }

    private void OpenCarDoor()
    {
        playerAnimator.SetLayerWeight(6, 1);
        StartCoroutine(nameof(CallOpenCarDoorCoroutine));
    }

    IEnumerator CallOpenCarDoorCoroutine()
    {
        yield return new WaitForSeconds(1f);
        playerAnimator.Play("Entering Car");
        yield return new WaitForSeconds(.5f);
        CallOpenCarDoor();
        yield return new WaitForSeconds(1f);
        PlayerCarController.Instance.CloseCarDoor();
    }

    public void CallOpenCarDoor()
    {
        Debug.Log("CallOpenCarDoor");
        PlayerCarController.Instance.OpenCarDoor();
        player.transform.position = playerPositionInCar.position;
    }
}
