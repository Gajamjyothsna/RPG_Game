using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarInputController : MonoBehaviour
{
    [SerializeField] private GameObject ToastMessage;
    [SerializeField] private GameObject player;

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
        if (isToastMessageActive && Input.GetKeyDown(KeyCode.Space))
        {
            refPlayer = player;
        }
        else refPlayer = null;
        if (refPlayer != null) PlayerCarController.Instance.OpenCarDoor();
    }
}
