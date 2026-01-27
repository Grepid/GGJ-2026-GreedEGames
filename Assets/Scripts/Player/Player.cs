using UnityEngine;

public class Player : Singleton<Player>
{
    public bool IsControlling;
    [Tooltip("The percent of the width of the screen that the mouse must pass to start panning camera")]
    public float cameraPanThreshold = 0.5f;
    public float cameraPanSpeed = 5; //Degrees per second
    public float maxPan;
    float currentPan;
    private PauseUI pauseUI;
    Camera cam;

    protected override void Awake()
    {
        base.Awake();
        cam = Camera.main;  
        currentPan = cam.transform.eulerAngles.y;
    }

    private void Update()
    {
        RunInputs();
        if (!IsControlling) return;
    }

    private void RunInputs()
    {
        //Will run regardless of paused or not
        if(Input.GetKeyDown(KeyCode.Escape)) TogglePause();

        if (!IsControlling) return;
        //Anything under here will NOT run if paused
        MoveCamera();
    }

    bool CursorInMoveZone
    {
        get
        {
            float mouseX = Mathf.Abs(Input.mousePosition.x-(Screen.width/2));
            float screenWidthFromCenter = (Screen.width/2);
            return mouseX > (screenWidthFromCenter*cameraPanThreshold);
        }
    }
    bool CursorSide
    {
        get
        {
            return Input.mousePosition.x > Screen.width/2;
        }
    }



    private void MoveCamera()
    {
        if (!CursorInMoveZone) return;
        float rotation = CursorSide ? cameraPanSpeed * Time.deltaTime : cameraPanSpeed * Time.deltaTime * -1;
        currentPan += rotation;
        cam.transform.localEulerAngles = new Vector3(0, currentPan, 0);
        EnforcePanLimit();
    }

    private void EnforcePanLimit()
    {
        if (Mathf.Abs(currentPan) > maxPan)
        {
            float diff = Mathf.Abs(currentPan) - maxPan;
            if (currentPan > 0) currentPan -= diff;
            else currentPan += diff;
        }
        cam.transform.localEulerAngles = new Vector3(0, currentPan, 0);
    }

    private void TogglePause()
    {
        if(pauseUI != null)
        {
            pauseUI.CloseSelf();
            return;
        }
        pauseUI = (PauseUI)UIManager.CreateElement("PauseUI");
    }
}
