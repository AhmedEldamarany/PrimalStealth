using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReferences : Singleton<GameReferences>
{
    [Tooltip("Game References")]
    [Header("Player Ref")]
    [SerializeField] private GameObject player;
    [Header("Player mouth position Ref")]
    [SerializeField] private Transform playerMouth;
    [SerializeField] private List<GameObject> food = new List<GameObject>();
    [SerializeField] private List<GameObject> water = new List<GameObject>();

    private void Awake()
    {
        base.RegisterSingleton();
    }
    public GameObject GetPlayerRef()
    {
        return player;
    }
    public Transform GetPlayerMouth()
    {
        return playerMouth;
    }
    public List<GameObject> GetFoodList()
    {
        return food;
    }
    public List<GameObject> GetWaterPosList()
    {
        return water;
    }

}
