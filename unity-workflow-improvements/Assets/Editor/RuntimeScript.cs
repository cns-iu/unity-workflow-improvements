#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
#endif

using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

public class RuntimeScript : MonoBehaviour
#if UNITY_EDITOR
    , IPreprocessBuildWithReport
    , IPostprocessBuildWithReport
#endif
{
#if UNITY_EDITOR
    public int callbackOrder { get { return 0; } }
    public void OnPreprocessBuild(BuildReport report)
    {
        Debug.Log("Disabling objects before building...");
        SetComponentState(true);
    }

    public void OnPostprocessBuild(BuildReport report)
    {
        Debug.Log("Enabling objects after building...");
        SetComponentState(true);
    }

    //use this to turn off the XRDeviceSimulator
    void SetComponentState(bool newState)
    {
        List<XRDeviceSimulator> simulators = GameObject.FindObjectsOfType<XRDeviceSimulator>().ToList();
        simulators.ForEach(s => { s.enabled = newState; });
    }

    //use this to turn off entire game objects. Note that FindGameObjectsWithTag will not find inactive game objects
    void SetObjectState(bool newState)
    {
        GameObject[] objectsToDisable = GameObject.FindGameObjectsWithTag("EditorOnly");

        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(newState);
        }
    }
#endif
}
