using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField] private GameObject pickup_Drop_Btn;
    [SerializeField] private GameObject attackBtn;

    [SerializeField] private StarterAssetsInputs _input;


    private const string ITEM_TAG = "ItemPickup";
    private bool isDroped;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ITEM_TAG))
        {
            ShowPickUpBtn();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(ITEM_TAG))
        {
            HidePickUpBtn();
        }
    }

    private void HidePickUpBtn()
    {
        attackBtn.SetActive(true);
        pickup_Drop_Btn.SetActive(false);
    }

    private void ShowPickUpBtn()
    {
        pickup_Drop_Btn.SetActive(true);
        attackBtn.SetActive(false);
    }
    
}
