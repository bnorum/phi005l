using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.EventSystems;

public class onClick : MonoBehaviour, IPointerDownHandler
{


    public bool isClicked = false;

    private void Start()
    {
        AddPhysics2DRaycaster();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        UnityEngine.Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
        StartCoroutine(preventClickSpam());
    }

    private void AddPhysics2DRaycaster()
    {
        Physics2DRaycaster physicsRaycaster = FindObjectOfType<Physics2DRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<Physics2DRaycaster>();
        }
    }

    private IEnumerator preventClickSpam()
    {
        isClicked = true;
        if (this.gameObject.name == "Button1" || this.gameObject.name == "Button2") transform.Rotate(0,0,180f);
        yield return new WaitForSeconds(0.1f);
        
        if (this.gameObject.name == "Button1" || this.gameObject.name == "Button2") transform.Rotate(0,0,180f);
        isClicked = false;
    }
   
}
