using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AppManager : MonoBehaviour
{
    public ARSession ARSession;
    public ARPlaneManager ARPlaneManager;
    public SurfaceShaderSwitchManager surfaceShaderSwitchManager;
    private MenuManager MenuManager;

    // Start is called before the first frame update
    void Awake()
    {
        MenuManager = this.GetComponent<MenuManager>();
        ARSession.enabled = false;
        OnARSessionChanged(new ARSessionStateChangedEventArgs(ARSession.state));
        ARSession.stateChanged += OnARSessionChanged;
    }

    private void OnARSessionChanged(ARSessionStateChangedEventArgs args)
    {
        switch (args.state)
        {
            case ARSessionState.None:
                MenuManager.SetHomeCanvasMessageText("No state.");
                break;
            case ARSessionState.Unsupported:
                MenuManager.SetHomeCanvasMessageText("Device not supported for AR experience.");
                break;
            case ARSessionState.CheckingAvailability:
                MenuManager.SetHomeCanvasMessageText("Checking if the device is supported.");
                break;
            case ARSessionState.NeedsInstall:
                MenuManager.SetHomeCanvasMessageText("Updated needed.");
                break;
            case ARSessionState.Installing:
                MenuManager.SetHomeCanvasMessageText("Installing update ...");
                break;
            case ARSessionState.Ready:
                MenuManager.SetHomeCanvasMessageText("Device ready to launch the AR experience !");
                MenuManager.SetHomeCanvasStartButtonState(true);
                ARSession.enabled = true;
                break;
            case ARSessionState.SessionInitializing:
                MenuManager.SetHomeCanvasMessageText("Initializing session ...");
                break;
            case ARSessionState.SessionTracking:
                MenuManager.SetHomeCanvasMessageText("Session ready !");
                MenuManager.SetHomeCanvasStartButtonState(true);
                ARSession.enabled = true;
                break;
            default:
                break;
        }
    }

    public void StartARExperience()
    {
        surfaceShaderSwitchManager.RefreshMaterialsDropdown();
    }

}
