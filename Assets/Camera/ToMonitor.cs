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
        if(ToRoom.isZoomed) cam.orthographicSize = 2;

        if (!ToRoom.isZoomed && monitorClicked)
        {
            Resize(2010f, 1130f, 0f);
            zoom = 2f;
            zoom = Mathf.Clamp(zoom, 2, 5);
            StartCoroutine(SceneDelay());
        } else if (ToRoom.isZoomed)
        {
            zoom = 5f;
            ToRoom.isZoomed = false;
        }
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        
    }

    private IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("Computer");
    }

    public void MonitorOpen()
    {
        monitorClicked = true;
    }

    private void Resize(float newWidth, float newHeight, float yOffset)
    {
        // Zmiana rozmiaru
        rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        Debug.Log("Nowy rozmiar: szerokoœæ = " + newWidth + ", wysokoœæ = " + newHeight);

        // Przesuniêcie obiektu w osi Y
        rectTransform.anchoredPosition = new Vector2(0, yOffset);
        Debug.Log("Nowa pozycja: " + rectTransform.anchoredPosition);
    }
}
