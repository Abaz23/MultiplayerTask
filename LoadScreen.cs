using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadScreen : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image LoadBar;
    public TMP_Text BarTxt;
    public int SceneID;

    private void Start()
    {
        StartCoroutine(LoadSceneCor());
    }


    IEnumerator LoadSceneCor()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(SceneID);
        while (!asyncOperation.isDone)
        {
            float progress = asyncOperation.progress / 0.9f;
            LoadBar.fillAmount = progress;
            BarTxt.text = "Loading Complete   " + string.Format("{0:0}%", progress * 100f);
            yield return 0;
        }
    }
}
