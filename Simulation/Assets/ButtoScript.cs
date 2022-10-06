using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtoScript : MonoBehaviour
{
    public messageContent content;
    public DragManager dragManager;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
        dragManager = Camera.main.GetComponent<DragManager>();
    }



    void OnClick()
    {
        Debug.Log("clicked"+content.content);
        dragManager.loadMessage(content);
        
    }
}
