using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

/*
Attach to both the hand and the play card UI panels

*/

public class DropCard : MonoBehaviour , IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On Drop");
        if ( this.transform.tag == "Play Card" )
        {
            Debug.Log("TEST");
            if( this.transform.childCount != 0)
            {
                this.transform.DetachChildren();
            } 
        }

       CardMechanics cm = eventData.pointerDrag.GetComponent<CardMechanics>();
       if( cm  != null )
        {
            cm.ParentReturn = this.transform;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }
     public void OnPointerExit(PointerEventData eventData)
    {

    }
}
