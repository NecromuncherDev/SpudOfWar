using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameObject menuCanvas;

    [SerializeField]
    private string canvasChildName;

    private void Start()
    {
        //menuCanvas = gameObject.GetComponentInChildren<Canvas>();

        // Get the Canvas object itself and not the component in child
        menuCanvas = transform.Find(canvasChildName).gameObject;
        Debug.Log(menuCanvas.transform.name + " : " + menuCanvas.activeInHierarchy + ", " + menuCanvas.activeSelf);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Menu"))
        {
            // Toggle on and off based on current state
            menuCanvas.SetActive(!menuCanvas.activeSelf);
            Time.timeScale = menuCanvas.activeSelf ? 0 : 1;
            Debug.Log(menuCanvas.transform.name + " : " + menuCanvas.activeInHierarchy + ", " + menuCanvas.activeSelf);
        }
    }
}
