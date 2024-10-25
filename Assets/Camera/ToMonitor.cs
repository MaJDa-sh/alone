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

    
    [SerializeField] private Camera cam;


    private void Start()
    {
        monitorClick.onClick.AddListener(MonitorOpen);
        zoom = cam.orthographicSize;
    }


    private void Update()
    {
        if(ToRoom.isZoomed) cam.orthographicSize = 2;

        if (Input.GetMouseButtonDown(0) && !ToRoom.isZoomed && monitorClicked)
        {
            zoom = 2f;
            StartCoroutine(SceneDelay());
        } else if (ToRoom.isZoomed)
        {
            Debug.Log("zoomed");
            zoom = 5f;
            ToRoom.isZoomed = false;
        }

        zoom = Mathf.Clamp(zoom, 2, 5);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        Debug.Log(cam.orthographicSize);
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
}
