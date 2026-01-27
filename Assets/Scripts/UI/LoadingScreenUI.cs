using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LoadingScreenUI : UIElement
{
    public static LoadingScreenUI s_CurrentLoadingScreen;
    public List<AsyncOperation> loadOperations = new();
    [SerializeField]Image loadingFill;

    protected override void Awake()
    {
        base.Awake();
        s_CurrentLoadingScreen = this;
    }

    protected override void CloseUI()
    {
        
    }
    private bool LoadingComplete
    {
        get
        {
            bool result = true;
            foreach(var op in loadOperations)
            {
                result &= op.isDone;
            }
            return result;
        }
    }

    public async Task AwaitLoadingComplete()
    {
        int waitTimeMiliseconds = Mathf.RoundToInt(1 * (0.2f) * 1000); //1* is there for visual clarity knowing this is compounding from 1 second, brackets are the desired time in seconds, then *1000 to convert to mili
        while (true)
        {
            if (LoadingComplete)
            {
                break;
            }
            await Task.Delay(waitTimeMiliseconds);
        }
    }

    private void Update()
    {
        if (loadOperations.Count <=0) return;
        if (loadingFill == null) return;
        float progress = 0;
        foreach(var op in loadOperations)
        {
            progress += op.progress;
        }
        loadingFill.fillAmount = progress;
    }
}
