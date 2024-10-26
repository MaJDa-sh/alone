using System.Collections;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMonitor : MonoBehaviour
{
    private float zoom;
    private float velocity = 0f;
    private float smoothTime = 0.25f;
    

    [SerializeField] private Camera cam;


    private void Start()
    {
        zoom = cam.orthographicSize;
    }


    private void Update()
    {
        if(ToRoom.isZoomed) cam.orthographicSize = 2;

        if (Input.GetMouseButtonDown(0) && !ToRoom.isZoomed)
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
    }

    private IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene("Computer");
    }
}
