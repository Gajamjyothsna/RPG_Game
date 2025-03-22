using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    #region Private Variables
    [SerializeField] private PlayerTrigger playerTrigger;
    [SerializeField] private Animator playerCarAnimator;
    [SerializeField] private PlayerCarInputController playerInputController;

    [SerializeField] private List<GameObject> weaponsList;
    #endregion

    private void Start()
    {
        playerTrigger.onPlayerCarTrigger += OnPlayerCarTrigger;
        playerTrigger.onPlayerEntersCarArea += PlayerEnteredCarArea;
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

    private void PlayerEnteredCarArea(bool isPlayerEnteredCarArea)
    {
        //Deactivate and activate the weapons
        foreach (var weapon in weaponsList)
        {
            weapon.SetActive(isPlayerEnteredCarArea);
        }
    }    

    public void CloseCarDoor() => playerCarAnimator.SetTrigger("carClose");
    public void OpenCarDoor()=> playerCarAnimator.SetTrigger("carOpen");
}
