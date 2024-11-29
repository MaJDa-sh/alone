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

    public class Dialogue
    {
        public string name;
        public string dialogue;

        public Dialogue(string name, string dialogue)
        {
            this.name = name;
            this.dialogue = dialogue;
        }
    }

    private Dialogue[] dialogues = new Dialogue[]
    {
        new Dialogue("Instructor", "It's halloween and you "),
        new Dialogue("Instructor", "ohno"),
        new Dialogue("Instructor", "What are you up to?"),
        new Dialogue("Instructor", "Just exploring the world."),
    };


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
            Resize(1620, 1062, 0, 0);
            ToRoom.isZoomed = false;
            isZooming = -1;
        }

        if (!ToRoom.isZoomed && monitorClicked)
        {
            isZooming = 1;
        }
        
        if (isZooming == -1)
        {
            Resize(rectTransform.rect.width-90, rectTransform.rect.height-59, rectTransform.anchoredPosition.x - 3.5f, rectTransform.anchoredPosition.y + 4.75f);
            if(rectTransform.rect.height == 354)
            {
                isZooming = 0;
            }
        } 
        
        if (isZooming == 1)
        {
            Resize(rectTransform.rect.width+90, rectTransform.rect.height+59, rectTransform.anchoredPosition.x + 3.5f, rectTransform.anchoredPosition.y - 4.75f);
            if(rectTransform.rect.height == 1062)
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

    private void Resize(float newWidth, float newHeight, float xOffset, float yOffset)
    {
        rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        rectTransform.anchoredPosition = new Vector2(xOffset, yOffset);
    }
}
