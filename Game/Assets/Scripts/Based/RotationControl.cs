using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotationControl : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    public Transform Player, Camera;
    public float mouse_x = 10, mouse_y = 10, max_angle = 20, min_angle = -20;

    private float angle = 0;

    private void ChangeRotation(PointerEventData eventData)
    {
        var MouseInput = new Vector2(eventData.delta.x, eventData.delta.y);
        Player.transform.rotation *= Quaternion.Euler(0, MouseInput.x * mouse_x * Time.deltaTime, 0);

        angle = Mathf.Clamp(angle - MouseInput.y * mouse_y * Time.deltaTime, -max_angle, -min_angle);
        Camera.localRotation = Quaternion.Euler(angle, 0, 0);
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
