using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

/*

Add to the Ui a Panel. This is the "Hand" anchor it to the bottom or where ever you want the hand to be anchored.
The Card itself should be an image and attack this script to the Card.
The Card should also have a "Lay Out Element Script" on it as well
Set Prefered withd and height to the width and height of the card that you want it to be
Flexiable set to 0 on both width and height.

    The Hand will have a Horizontal Layout group attached to it. add the component.
    uncheck the force and add some type of spacing and anchor it to the middle.

Add a canvas group to the cards
*/

public class CardMechanics : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform ParentReturn = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        ParentReturn = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         this.transform.SetParent(ParentReturn) ;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    
}
