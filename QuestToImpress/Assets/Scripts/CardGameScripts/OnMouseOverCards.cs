using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverCards : MonoBehaviour
{
    bool isHoveredOn = false;
    public bool isDeactivated = false;
    public CardGameManager cardGameManager;
    public GameObject selectedEdge;

    void OnMouseOver()
    {
        if (!isHoveredOn && !isDeactivated)
        {       
           isHoveredOn = true;
           cardGameManager.CrateMagnifiedCard(this.gameObject);
           selectedEdge.SetActive(true);
        }        
    }

    void OnMouseExit()
    {        
        isHoveredOn = false;
        selectedEdge.SetActive(false);
        cardGameManager.DestroyMagnifiedCard(this.gameObject);
    }
}
