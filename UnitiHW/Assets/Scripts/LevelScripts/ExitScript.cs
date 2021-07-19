using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour
{
    [SerializeField] private GameObject _sucessUI;
    [SerializeField] private string _sceneToLoad;

    float time = 0f;    //Таймер

    void Update()
    {
        if (time > 0f)
        {
            time -= Time.deltaTime;

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() != null)
        {
            _sucessUI.SetActive(true);

            SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Single);

        }
    }
}
