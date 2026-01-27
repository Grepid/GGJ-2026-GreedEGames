using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : Singleton<GameplayManager>
{
    #region Lifetime Control
    public async static void StartSession()
    {
        //Load into the game scene
        var loadMenu = (LoadingScreenUI)UIManager.CreateElement("LoadingScreenUI");


        var op = SceneManager.LoadSceneAsync("GameplayPersistentScene", LoadSceneMode.Additive);
        loadMenu.loadOperations.Add(op);

        await GameSceneController.AwaitGameSceneReady();
        //Then Unload MainMenu
        await SceneManager.UnloadSceneAsync("MainMenu");
        loadMenu.CloseSelf();
    }

    public async void QuitToMainMenu()
    {
        var loadMenu = (LoadingScreenUI)UIManager.CreateElement("LoadingScreenUI");

        var op1 = SceneManager.UnloadSceneAsync("Game");
        var op2 = SceneManager.UnloadSceneAsync("GameplayPersistentScene");
        var op3 = SceneManager.LoadSceneAsync("MainMenu",LoadSceneMode.Additive);

        loadMenu.loadOperations.Add(op1);
        loadMenu.loadOperations.Add(op2);
        loadMenu.loadOperations.Add(op3);

        await loadMenu.AwaitLoadingComplete();

        loadMenu.CloseSelf();
    }
    #endregion



}
