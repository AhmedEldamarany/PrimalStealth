using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDrop : MonoBehaviour
{
    [SerializeField] Dropable[] ItemsToDrop;
    [SerializeField] Transform DroppingPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DropItems();
        }
        DroppingPoint.Rotate(Vector3.up, 0.5f);
    }
    public void DropItems()
    {
        foreach (Dropable  item in ItemsToDrop)
        {

        item.DropMe();
        }

    }
}
