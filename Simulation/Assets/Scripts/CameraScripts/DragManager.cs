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
    public GameObject panel;
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

        // if left button is held down
        if(Input.GetMouseButton(0))
        {
            // only continue if cursor is on draggable object
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
			{
                // changed target
                if (selectedObject != targetObject.transform.gameObject)
                {
                    // resets UI state
                    deselectNode();

                    // change selected object to what the cursor is hovering over
                    selectedObject = targetObject.transform.gameObject;

                    // sets cache of Node
                    cachedProperty = selectedObject.GetComponent<nodeProperty>();

                    // loads all messages of Node
                    loadMessagesInUi(cachedProperty);

                    // enable halo
                    halo = selectedObject.transform.GetChild(3).gameObject;
                    spriteRenderer = halo.GetComponent<SpriteRenderer>();
                    spriteRenderer.enabled = true;

                    // calculate offset between cursor and Node
                    offset = selectedObject.transform.position - mousePosition;
                }

                // moves selected object
                if (selectedObject && selectedObject == targetObject.transform.gameObject)
                {
                    selectedObject.transform.position = mousePosition + offset;
                }
			}
			
        }
        else if (Input.GetMouseButton(1)) // disables node outline/"halo"
        {
            deselectNode();
        }

        // updates message for each frame
		if (cachedProperty)
		{
            loadMessagesInUi(cachedProperty);
		}
    }

    // resets UI
    private void deselectNode()
	{
        // deselect Halo of last selected Node
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
            spriteRenderer = null;
        }
        halo = null;

        // resets selection state
        selectedObject = null;
        cachedProperty = null;
        cachedSize = -1;

        // hide message panels
        deloadMessagesInUi();
        deloadMessage();
    }

    // shows content of one message (called by "ButtoScript.cs")
    public void loadMessage(messageContent message)
    {
        canvasNode.enabled = true;

        Text[] content = panel.GetComponentsInChildren<Text>();
        content[0].text = message.content.ToString();
        content[1].text = message.id.ToString();
        content[2].text = message.riskLvl.ToString();
        content[3].text = message.region.ToString();
        content[4].text = message.validUntil.ToString();
        content[5].text = message.validAfter.ToString();
        content[6].text = message.version.ToString();
        content[7].text = message.typ.ToString();
        deloadMessagesInUi();
    }

    // hides content of one message
    public void deloadMessage()
    {
        canvasNode.enabled = false;
    }

    // actually loads list of messages of one Node
    public void loadMessagesInUi(nodeProperty nodeInformation)
    {
        // get list of messages
        messageTable = nodeInformation.messageTable;

        // do nothing if size has not changed
		if (cachedSize == messageTable.Count) return;

        // save new size
        cachedSize = messageTable.Count;

        // reset UI to hide old messages/different nodes
        deloadMessagesInUi();

        // display messages
        int index = 0;
        foreach(KeyValuePair<messageContent, SortedSet<int>> kvp in messageTable)
        {
            // create panel for one message
            GameObject prefab = Instantiate(messagePrefab, messageOverview.transform);
            ButtoScript script = prefab.GetComponentInChildren<ButtoScript>();

            // move panel down to create a list
            prefab.transform.Translate(Vector3.down * length*index);
            index++;

            // fill panel with content of message
            Text[] content = prefab.GetComponentsInChildren<Text>();
            script.content = kvp.Key;
            content[0].text = kvp.Key.content.ToString();
            content[1].text = kvp.Key.riskLvl.ToString();
        }

        // shows container panel for messages
        messageOverview.enabled = true;
    }

    // hides list of messages of one Node
    public void deloadMessagesInUi()
    {
        // destroy all message panels
        GameObject[] panels = GameObject.FindGameObjectsWithTag("MessagePanel");
        if (panels.Length != 0){
            foreach (GameObject panel in panels)
            {
                Destroy(panel);
            }
        }

        // hides message container
        messageOverview.enabled = false;

    }
}
