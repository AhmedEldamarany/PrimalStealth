using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUi : MonoBehaviour
{
    public void BackToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}