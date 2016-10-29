using UnityEngine;
using System.Collections;

public abstract class  PlayerMechanics : MonoBehaviour
{
    /* TODO
     this is a base class for the 3 ( maybe rock ) classes 
     using this get the the peices onto the board
     
     then we will need to make different classes for each character 
     */

    public int CurrentX{ set;get;}
    public int CurrentY { set; get; }
    public void setPosition (int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }
        
}
