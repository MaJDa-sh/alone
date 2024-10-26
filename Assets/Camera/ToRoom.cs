using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRoom : MonoBehaviour
{
    public static bool isZoomed { get; set; }

    [SerializeField] private Camera cam;


    private void Start()
    {
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToRoom.isZoomed = true;
            SceneManager.LoadScene("Room");
        }
    }
}
