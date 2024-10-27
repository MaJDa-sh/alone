using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtensionCord : MonoBehaviour
{
    public Button cord;
    public GameObject lamp;
    public GameObject cordCheck;
    public GameObject darkLayout;
    public GameObject monitor;

    public bool isClicked = false;


    private void Start()
    {
        cord.onClick.AddListener(CordFuncionality);
    }

    public void CordFuncionality()
    {
        if (!isClicked)
        {
            Debug.Log("powinno zgasn¹æ");
            lamp.gameObject.SetActive(false);
            cordCheck.gameObject.SetActive(false);
            darkLayout.gameObject.SetActive(true);
            monitor.gameObject.SetActive(false);
            isClicked = true;
        }
        else if (isClicked)
        {
            lamp.gameObject.SetActive(true);
            cordCheck.gameObject.SetActive(true);
            darkLayout.gameObject.SetActive(false);
            monitor.gameObject.SetActive(true);
            isClicked = false;
        }
    }
}
