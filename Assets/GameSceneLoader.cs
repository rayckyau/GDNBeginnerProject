using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneLoader : MonoBehaviour
{
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    private int index = 0;
    private string previousScene = null;

    // Use this for initialization
    void Start()
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/AssetBundles/gamelevels");
        scenePaths = myLoadedAssetBundle.GetAllScenePaths();
    }
    
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "Change Scene"))
        {
            Debug.Log("Scene loading: " + scenePaths[index]);
            if (previousScene != null)
            {
                SceneManager.UnloadSceneAsync(previousScene);
            }
            SceneManager.LoadScene(scenePaths[index], LoadSceneMode.Additive);
            previousScene = scenePaths[index];
            index++;
            if (index == scenePaths.Length)
            {
                index = 0;
            }
        }
    }
}
