using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDCursor : MonoBehaviour
{

    public Canvas parentCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 movePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentCanvas.transform as RectTransform,
            Input.mousePosition, parentCanvas.worldCamera,
            out movePos);


        this.transform.position = parentCanvas.transform.TransformPoint(movePos);
    }
}
