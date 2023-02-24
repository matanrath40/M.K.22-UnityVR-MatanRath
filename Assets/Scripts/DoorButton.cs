using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


[RequireComponent(typeof(XRGrabInteractable), typeof(Renderer))]

public class DoorButton : MonoBehaviour
{
    XRBaseInteractable m_Interactable;
    Renderer m_Renderer;
    Animator m_Animator;
    public DoorScript m_Door;

    static Color s_HoveredColor = new Color(0.929f, 0.094f, 0.278f);
    static Color s_SelectedColor = new Color(0.019f, 0.733f, 0.827f);

    private void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
    }


    protected void OnEnable()
    {
        m_Interactable = GetComponent<XRBaseInteractable>();
        m_Renderer = GetComponent<Renderer>();

        m_Interactable.firstHoverEntered.AddListener(OnFirstHoverEntered);
        m_Interactable.lastHoverExited.AddListener(OnLastHoverExited);
        m_Interactable.firstSelectEntered.AddListener(OnFirstSelectEntered);
        m_Interactable.lastSelectExited.AddListener(OnLastSelectExited);

        UpdateColor();
    }

    protected void OnDisable()
    {
        m_Interactable.firstHoverEntered.RemoveListener(OnFirstHoverEntered);
        m_Interactable.lastHoverExited.RemoveListener(OnLastHoverExited);
        m_Interactable.firstSelectEntered.RemoveListener(OnFirstSelectEntered);
        m_Interactable.lastSelectExited.RemoveListener(OnLastSelectExited);
    }

    protected virtual void OnFirstHoverEntered(HoverEnterEventArgs args) => UpdateColor();

    protected virtual void OnLastHoverExited(HoverExitEventArgs args) => UpdateColor();

    protected virtual void OnFirstSelectEntered(SelectEnterEventArgs args) => OpenDoor();

    protected virtual void OnLastSelectExited(SelectExitEventArgs args) => UpdateColor();

    protected void OpenDoor()
    {
        Debug.Log("OPEN DOOORRRR");
        m_Door.OpenDoor();
        UpdateColor();
        m_Animator.SetTrigger("MakePressed");

    }
    protected void UpdateColor()
    {
        var color = m_Interactable.isSelected
            ? s_SelectedColor
            : m_Interactable.isHovered
                ? s_HoveredColor
                : Color.white;
        m_Renderer.material.color = color;
    }
}
