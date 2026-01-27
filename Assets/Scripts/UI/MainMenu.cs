using AudioSystem;
using UnityEngine;

public class MainMenu : UIElement
{
    protected override void CloseUI()
    {
        
    }

    public void StartGame()
    {
        GameplayManager.StartSession();
        AudioManager.Play("TestSound1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
