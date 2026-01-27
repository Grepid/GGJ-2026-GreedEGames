using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneStarter : MonoBehaviour
{
    //Runs on start in GameplayPeristentScene to allow singletons to run Awake
    private void Start()
    {
        var op = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        LoadingScreenUI.s_CurrentLoadingScreen.loadOperations.Add(op);
    }
}
