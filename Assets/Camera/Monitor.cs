using System.Collections;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Monitor : MonoBehaviour
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
        
        if (monitorClicked)
        {
            zoom = 2f;
            StartCoroutine(SceneDelay());
        }

        zoom = Mathf.Clamp(zoom, 2, 5);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
    }

    private IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Computer");
    }

    public void MonitorOpen()
    {
        monitorClicked = true;
    }
}
