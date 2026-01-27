using UnityEngine;

public class MainMenu : UIElement
{
    protected override void CloseUI()
    {
        
    }

    public void StartGame()
    {
        GameplayManager.StartSession();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
