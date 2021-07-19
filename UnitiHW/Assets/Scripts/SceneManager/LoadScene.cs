using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField]private Button _loadButton;
    [SerializeField] private int _sceneIndex;

    void Start()
    {
        _loadButton.onClick.AddListener(LoadSceneLol);
    }
    private void LoadSceneLol()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
}
