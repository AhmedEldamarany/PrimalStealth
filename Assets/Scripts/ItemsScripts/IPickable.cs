using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IPickable : MonoBehaviour
{
    [SerializeField] private StarterAssetsInputs _input;
    private bool isPicked = false;

    private GameObject player;
    private Transform playerMouth;
    private Text togglePickUpBtnTxt;
    
    private void Start()
    {
        player = GameReferences.Instance.GetPlayerRef();
        playerMouth = GameReferences.Instance.GetPlayerMouth().transform;
        togglePickUpBtnTxt = UIManager.Instance.PickUpToggleBtnTxt;
    }
    private void Update()
    {
        if (_input.pickUp)
        {
            isPicked = !isPicked;
            if (isPicked)
            {
                PickUp();
            }
            else
            {
                Drop();
            }
        }
    }
    private void PickUp()
    {
        togglePickUpBtnTxt.text = "PickUp";
        this.transform.parent = playerMouth;
        transform.localPosition = Vector3.zero;
    }
    private void Drop()
    {
        togglePickUpBtnTxt.text = "Drop";
        Vector3 playerPos = player.transform.position;
        playerPos.z += 5f;
        playerPos.y -= .5f;
        this.transform.SetParent(null);
        this.transform.localPosition = playerPos;
    }
}
