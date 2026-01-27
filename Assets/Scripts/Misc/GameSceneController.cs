using System.Threading.Tasks;
using UnityEngine;

public class GameSceneController : MonoBehaviour
{
    static bool GameSceneReady;
    [SerializeField] Transform cameraPosition;
    private void Awake()
    {
        AlignMainCamera();

        GameSceneReady = true;
    }

    private void AlignMainCamera()
    {
        Camera.main.transform.SetPositionAndRotation(cameraPosition.position, cameraPosition.rotation);
    }

    public static async Task AwaitGameSceneReady()
    {
        int waitTimeMiliseconds = Mathf.RoundToInt(1 * (0.2f) * 1000); //1* is there for visual clarity knowing this is compounding from 1 second, brackets are the desired time in seconds, then *1000 to convert to mili
        while (true)
        {
            if (GameSceneReady)
            {
                break;
            }
            await Task.Delay(waitTimeMiliseconds);
        }
        GameSceneReady = false;
    }
}
