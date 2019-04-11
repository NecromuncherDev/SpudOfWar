using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour
{
    private string sceneName;

    private void Start()
    {
        sceneName = gameObject.GetComponentInChildren<Text>().text;
        if (sceneName == "Button") // Change to "not in scene list"
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        Debug.Log(sceneName);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
