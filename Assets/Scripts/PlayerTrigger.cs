using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public event Action<bool> onPlayerCarTrigger;
    public event Action<bool> onPlayerEntersCarArea;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("FrontDoorTrigger"))
        {
            Debug.Log("Player collider");
            onPlayerCarTrigger?.Invoke(true);
        }
        else if(other.gameObject.CompareTag("CarArea"))
        {
            onPlayerEntersCarArea?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FrontDoorTrigger"))
        {
            onPlayerCarTrigger?.Invoke(false);
        }
        else if (other.gameObject.CompareTag("CarArea"))
        {
            onPlayerEntersCarArea?.Invoke(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CarArea"))
        {
            onPlayerEntersCarArea?.Invoke(false);
        }
    }
}
