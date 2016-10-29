using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BoardMechanics : MonoBehaviour
{
    /* ToD still:
     * Create a way for the rocks to spawn and move
     * Create a way for the characters to move correctly
     * 
     * 
     */
    public PlayerMechanics[,] Player { set; get; }
    private PlayerMechanics Selected;
    public List<GameObject> Choices; // melee , fire, kin
    private const float tileSize = 1.0f; // spawning purposes 
    private const float tileCenter = 0.5f; // spawning purposes

    private int selectionX = -1; // blank for now
    private int selectionY = -1; // blank for now

    
    
  	// Use this for initialization
	void Start ()
    {
        
       SpawnCharacter(0,4,0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateSelection();
        DrawBoard();
        if(Input.GetMouseButtonDown(0))
        {
            //if (selectionX >= 0 && selectionY >= 0 )// on board
           // {
                if(Selected == null) // justs to see if something is seleced
                {
                    //select 
                    SelectPlayer(selectionX, selectionY);
                }
                else
                {
                    // move
                    MovePlayer(selectionX, selectionY);
                //}
            }
        }
	}

    private void SelectPlayer(int x, int y) // need a check later to see if the character is yours
    {
        if (Player[x, y] == null)
            return;
        Selected = Player[x, y];
    }
    private void MovePlayer(int x , int y) // allowed move needs impletmenting bool fucntion in Player mechabniccs
    {
        Player[Selected.CurrentX, Selected.CurrentY] = null;
        Selected.transform.position = GetCenter(x, y);
        Player[x, y] = Selected;
        Selected = null;
    }

    private void SpawnCharacter(int index, int x , int y)
    {
        GameObject toon = Instantiate(Choices[index], GetCenter(x,y) , Quaternion.identity) as GameObject;
        toon.transform.SetParent(transform);
        Player = new PlayerMechanics[8, 8]; // no clue googled the error and this came up as a null reference...
        Player[x, y] = toon.GetComponent<PlayerMechanics>();
        Player[x, y].setPosition(x, y);
    }
    
    private Vector3 GetCenter(int x , int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (tileSize * x + tileCenter);
        origin.z += (tileSize * y + tileCenter);
        return origin;
    }

    private void DrawBoard()// draws the board under the mesh render 
    {
        Vector3 width = Vector3.right * 8;
        Vector3 height = Vector3.forward * 8;
        for ( int i = 0; i  <= 8; i++ )
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + width); 
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + height);
            }
        }
    }

    private void UpdateSelection() // allows the highlight of the board sqaures
    {
        if (!Camera.main)
            return;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 20.0f, LayerMask.GetMask("Plane")))
        {
            Debug.Log(hit.point);
            selectionX = (int)hit.point.x; // cast the float to int the int is now the square number.
            selectionY = (int)hit.point.z;
        }
        else
        {
            selectionX = -1;
            selectionX = -1;
        }

    } 
}
