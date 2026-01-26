using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PersistentToMenu : MonoBehaviour
{
    [SerializeField] Image progressBar;
    AsyncOperation mainMenuLoadOperation;
    [SerializeField]Transform loadingScreen;

    //Will run after Singelton Awakes
    private async void Start()
    {
        string menuSceneName = "MainMenu";
        var op = SceneManager.LoadSceneAsync(menuSceneName,LoadSceneMode.Additive);
        op.allowSceneActivation = true;
        mainMenuLoadOperation = op;
        await op;


        //Hide Loading Screen, will never be seen again, doesn't need to be on the UI Manager
        loadingScreen.gameObject.SetActive(false);
        Destroy(this);
    }
    private void Update()
    {
        if (progressBar == null) return;
        if (mainMenuLoadOperation == null) return;
        progressBar.fillAmount = mainMenuLoadOperation.progress;
    }
}
