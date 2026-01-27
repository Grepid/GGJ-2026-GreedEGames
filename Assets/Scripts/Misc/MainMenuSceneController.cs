using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{
    UIElement mainMenu;
    private void Awake()
    {
        mainMenu = UIManager.CreateElement("MainMenuUI");
    }
    private void OnDestroy()
    {
        mainMenu.CloseSelf();
    }
}
