﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("ScenesLoader")]
public class ScenesLoader : MonoBehaviour
{
    #region Singleton
    public static ScenesLoader Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }
    #endregion

    public void RestartLevel(float delay)
    {
        StartCoroutine(RestartLevelCoroutine(delay));
    }

    IEnumerator RestartLevelCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
