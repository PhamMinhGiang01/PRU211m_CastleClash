using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class AnimatedButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Serializable]
    public class ButtonClickedEvent : UnityEvent { }

    public bool interactable = true;

    [SerializeField]
    private ButtonClickedEvent m_OnClick = new ButtonClickedEvent();
    [SerializeField]
    private bool isPopupOpen;
    [SerializeField]
    private Transform st;

    private bool isClicked;
    public bool isBtn;

    public ButtonClickedEvent onClick
    {
        get { return m_OnClick; }
        set { m_OnClick = value; }
    }


    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left || !interactable)
            return;

        if (st  != null)
        {
            st.localScale *= 0.9f;
        }
        isClicked = true;
    }

    private void OnClickAction()
    {
        m_OnClick.Invoke();
    }

    private void Press()
    {
        if (!IsActive())
            return;
        OnClickAction();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!interactable)
        {
            return;
        }
        if (isClicked)
        {
            Press();
        }

        if (st != null && isClicked)
        {
            st.localScale /= 0.9f;
        }
        isClicked = false;
    }
}



