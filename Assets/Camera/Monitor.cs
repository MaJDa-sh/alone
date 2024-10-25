using System.Collections;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monitor : MonoBehaviour
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

        if (Input.GetMouseButtonDown(0))
        {
            zoom = 2f;
            StartCoroutine(SceneDelay());
        }

        zoom = Mathf.Clamp(zoom, 2, 5);
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
    }

    private IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Computer");
    }
}
