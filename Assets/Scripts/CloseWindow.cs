using System.Collections;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CloseWindow : MonoBehaviour
{
    public Button closeButton;
    void Start()
    {
        closeButton.onClick.AddListener(MonitorClose);
    }
    public void MonitorClose()
    {
        GameManager.Instance.windowOpen = false;

    }
}
