using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable _grabInteractable;
    [SerializeField] private int _levelIndex;
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;

    private void Awake()
    {
        SetUpXRInteractions();
        GetComponent<Renderer>().material.color = SetColor();
    }

    private void SetUpXRInteractions()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();

        _grabInteractable.selectEntered.AddListener(
            (SelectEnterEventArgs args) => { SceneManager.LoadScene(_levelIndex); }
            );
    }

    private Color SetColor()
    {
        Color result = SceneManager.GetActiveScene().buildIndex == _levelIndex ? _activeColor : _inactiveColor;
        return result;
    }

}
