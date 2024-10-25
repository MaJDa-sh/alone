using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SmoothScopeZoom : MonoBehaviour
{
    private float zoom;
    private float zoomMultiplier = 4f;
    private float minZoom = 2f;
    private float maxZoom = 8;
    private float velocity = 0f;
    private float smoothTime = 0.25f;
    private bool isScrolled = false;
    private bool flag = false;

    [SerializeField] private Camera cam;


    private void Start()
    {
        zoom = cam.orthographicSize;
    }

    private void LoaudScene()
    {
        SceneManager.LoadScene("Test");
    }

    private void Update()
    {


        

        if (Input.GetMouseButtonDown(0) && !isScrolled)
        {
            isScrolled = true;
            zoom = 5f;
            Debug.Log("zoom");
        }else if (Input.GetMouseButtonDown(0) && isScrolled)
        {
            isScrolled = false;
            zoom = 2f;
            Debug.Log("zoom__2");
            flag = true;
            
            
            
        }





        //Debug.Log(zoom);
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity , smoothTime);
        
        if  (!isScrolled && flag)
        {   
            
            LoaudScene();
        }
        
    }
    

}
