using System.Collections;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToMonitor : MonoBehaviour
{
    private float zoom;
    private float velocity = 0f;
    private float smoothTime = 0.25f;
    bool monitorClicked = false;
    int isZooming = 0;

    public Button monitorClick;

    private RectTransform rectTransform;
    [SerializeField] private Camera cam;


    private void Start()
    {
        monitorClick.onClick.AddListener(MonitorOpen);
        zoom = cam.orthographicSize;
        rectTransform = GetComponent<RectTransform>();

        float width = rectTransform.rect.width;
        float height = rectTransform.rect.height;        
    }


    private void Update() 
    {
        if(ToRoom.isZoomed) 
        {
            Resize(3840, 2160, 0);
            ToRoom.isZoomed = false;
            isZooming = -1;
        }

        if (!ToRoom.isZoomed && monitorClicked)
        {
            isZooming = 1;
        }
        
        if (isZooming == -1)
        {
            Resize(rectTransform.rect.width-32, rectTransform.rect.height-18, 0f);
            if(rectTransform.rect.height==1080)
            {
                isZooming = 0;
            }
        } 
        
        if (isZooming == 1)
        {
            Resize(rectTransform.rect.width+32, rectTransform.rect.height+18, 0f);
            if(rectTransform.rect.height == 2160)
            {
                isZooming = 0;
                SceneManager.LoadScene("Computer");
            }
        }
    }

    public void MonitorOpen()
    {
        monitorClicked = true;
    }

    private void Resize(float newWidth, float newHeight, float yOffset)
    {
        rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        rectTransform.anchoredPosition = new Vector2(90, -90);
    }
}
