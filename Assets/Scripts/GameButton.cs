using System.Collections;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{
    public Button button;
    public GameObject window;

    void Start()
    {
        button.onClick.AddListener(MonitorOpen);
    }

    void Update()
    {
        window.SetActive(GameManager.Instance.windowOpen);
    }

    public void MonitorOpen()
    {
        GameManager.Instance.windowOpen = true;
        
    }
}
