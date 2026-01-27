using UnityEngine;

public class PauseUI : UIElement
{
    private void OnEnable()
    {
        Player.Instance.IsControlling = false;
    }

    private void OnDisable()
    {
        Player.Instance.IsControlling = true;
    }


    protected override void CloseUI()
    {
        
    }

    public void QuitToMainMenu()
    {
        if (GameplayManager.Instance == null) return;
        GameplayManager.Instance.QuitToMainMenu();
        CloseSelf();
    }
}
