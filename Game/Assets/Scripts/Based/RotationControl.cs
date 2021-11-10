using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationControl : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public Transform Player;
    public float mouse_x = 10;


    private void ChangeRotation(PointerEventData eventData)
    {
        var MouseInput = new Vector2(eventData.delta.x, eventData.delta.y);
        Player.transform.rotation *= Quaternion.Euler(0, MouseInput.x * mouse_x * Time.deltaTime, 0);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ChangeRotation(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        ChangeRotation(eventData);
    }
}
