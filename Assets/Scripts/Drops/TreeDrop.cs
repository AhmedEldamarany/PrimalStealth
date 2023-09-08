using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDrop : MonoBehaviour
{
    [SerializeField] Dropable ItemToDrop;
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
    }
    public void DropItems()
    {
        ItemToDrop.DropMe();

    }
}
