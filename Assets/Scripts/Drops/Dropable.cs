using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropable : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    public void DropMe()
    {
        rb.useGravity = true;
        rb.AddTorque(new Vector3(.4f,1,.3f) * 40f);
    }
}
