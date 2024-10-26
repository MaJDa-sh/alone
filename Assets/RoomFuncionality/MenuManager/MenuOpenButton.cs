using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpenButton : MonoBehaviour
{
    public Button menuOpen;
    public bool windowCheck = false;
    [SerializeField] public GameObject menuWindow;

    void Start()
    {
        menuOpen.onClick.AddListener(WindowActivity);       
    }  

    public void WindowActivity()
    {
        if (windowCheck == false)
        {
            Debug.Log("window open");
            menuWindow.gameObject.SetActive(true);
            windowCheck = true;
        }
        else if (windowCheck == true)
        {
            Debug.Log("window close");
            menuWindow.gameObject.SetActive(false);
            windowCheck = false;
        }
    }
}
