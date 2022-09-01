using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// handles dragging nodes in game view and highlighting selected node
public class DragManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject selectedObject;
    public GameObject halo;
    Vector3 offset;

    public float length = 41.0f;

    //UI
    public Canvas canvasNode;
    public Canvas messageOverview;
    public TextMeshProUGUI textIp;
    public GameObject messagePrefab;

    //DATA
    public Dictionary<messageContent, SortedSet<int>> messageTable =
    new Dictionary<messageContent, SortedSet<int>>(new MessageCompare());

    private int cachedSize = -1;
    private nodeProperty cachedProperty = null;


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        
        if(Input.GetMouseButton(0))
        {
             Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
             if(targetObject && selectedObject != targetObject.transform.gameObject)
             {
                selectedObject = targetObject.transform.gameObject;
                loadNodeUi(selectedObject);
                messageOverview.enabled = true;
                if(spriteRenderer != null)
                {
                    spriteRenderer.enabled = false;
                    
                }


                offset = selectedObject.transform.position -mousePosition;
             }


            if (selectedObject) // moves selected object and enables node outline/"halo"
            {
                selectedObject.transform.position = mousePosition + offset;
                halo = selectedObject.transform.GetChild(3).gameObject;
                spriteRenderer = halo.GetComponent<SpriteRenderer>();
                spriteRenderer.enabled = true;
            }
   
        }
        else if (Input.GetMouseButton(1) && selectedObject) // disables node outline/"halo"
        {
            spriteRenderer.enabled = false;
            halo = null;
            spriteRenderer = null;
            selectedObject = null;
            messageOverview.enabled = false;
            cachedProperty = null;
            cachedSize = -1;
            deloadMessagesInUi();
        }

		if (cachedProperty)
		{
            loadMessagesInUi(cachedProperty);
		}
    }



    // UI to show Node information
    public void loadNodeUi(GameObject selectedGameObject)
    {
        cachedProperty = selectedGameObject.GetComponent<nodeProperty>();
        loadMessagesInUi(cachedProperty);
   
    }

    public void loadMessagesInUi(nodeProperty nodeInformation)
    {
        messageTable = nodeInformation.messageTable;

		if (cachedSize == messageTable.Count) return;


        cachedSize = messageTable.Count;
        deloadMessagesInUi();

        int index = 0;

        foreach(KeyValuePair<messageContent, SortedSet<int>> kvp in messageTable)//TODO: Offset einbauen, damit alles untereinadner erscheint.
        {   
            GameObject prefab = Instantiate(messagePrefab, messageOverview.transform);

            prefab.transform.Translate(Vector3.down * length*index);
            index++;


            Text[] content = prefab.GetComponentsInChildren<Text>();

            content[0].text = kvp.Key.content.ToString();
            content[1].text = kvp.Key.riskLvl.ToString();
        }    
    }

    public void deloadMessagesInUi()
    {
        GameObject[] panels = GameObject.FindGameObjectsWithTag("MessagePanel");

        foreach(GameObject panel in panels)
        {
            Destroy(panel);
        }
    }
}
