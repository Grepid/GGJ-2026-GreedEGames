using UnityEngine;

public class GenericElement : UIElement
{
    protected override void CloseUI()
    {
        
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
