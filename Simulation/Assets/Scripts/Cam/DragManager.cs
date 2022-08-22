using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DragManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject  selectedObject;
    public GameObject halo;
    Vector3 offset;
    public Canvas canvasNode;
    public TextMeshProUGUI textIp;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        
        if(Input.GetMouseButton(0))
        {
             Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
             if(targetObject)
             {
                selectedObject = targetObject.transform.gameObject;
                loadNodeUi(selectedObject);
                canvasNode.enabled = true;
                if(spriteRenderer != null)
                {
                    spriteRenderer.enabled = false;
                    
                }


                offset = selectedObject.transform.position -mousePosition;
             }


            if (selectedObject)
            {
                selectedObject.transform.position = mousePosition + offset;
                halo = selectedObject.transform.GetChild(1).gameObject;
                spriteRenderer = halo.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = true;
            }
   
        }
        else if (Input.GetMouseButton(1) && selectedObject)
        {
            Debug.Log("Derefence Halo");
            spriteRenderer.enabled = false;
            halo = null;
            spriteRenderer = null;
            selectedObject = null;
            canvasNode.enabled = false;
        }
    }




    public void loadNodeUi(GameObject selectedGameObject)
    {
        int ip = selectedGameObject.GetComponent<nodeProperty>().ip;
        textIp.text = ip.ToString();
    }
}
