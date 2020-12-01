using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoaders : MonoBehaviour
{
    public GameObject Load;
    public Image loadingImage;
    // Start is called before the first frame update

    private void Awake()
    {
        if(FileBasedPrefs.HasKey("inGameSceneChange"))
            Debug.Log("++++ froLoading+++++++");
    }
    void Start()
    {

        StartCoroutine(StartLoading());

    }

    IEnumerator StartLoading()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        if (FileBasedPrefs.HasKey("_restarted_"))
        {
            FileBasedPrefs.DeleteAll();
            FileBasedPrefs.DeleteKey("_restarted_");
        }
        LoadLevel();
    }
    public void LoadLevel()
    {

        Load.SetActive(true);
        if (FileBasedPrefs.HasKey("CurrentScene"))
        StartCoroutine(LoadingScreen(FileBasedPrefs.GetInt("CurrentScene")));
        else
            StartCoroutine(LoadingScreen(1));

    }

    IEnumerator LoadingScreen(int num)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(num);
        while (!operation.isDone)
        {
            float progress = operation.progress;
            Debug.Log(progress);
            loadingImage.fillAmount = progress;

            yield return null;
        }
    }

   
}
