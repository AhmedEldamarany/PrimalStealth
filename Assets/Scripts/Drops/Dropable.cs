using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropable : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public void DropMe()
    {
        rb.useGravity = true;
    }
}
