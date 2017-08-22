using UnityEngine;
using UnityEngine.EventSystems;

public class Item_Element : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public static GameObject tempDrag;
    public static GameObject go;
    public string itemName;
    public Item.ItemQualityModifiers grade;
    public Item_Slot.SlotType elementType;
    //Transform oldParent;
    Transform startParent;
    Vector3 startPosition;
    public Item item;
    UnityEngine.UI.Image img;

    public void Start()
    {
        tempDrag = GameObject.Find("TEMPDRAGOBJECT");
        img = GetComponent<UnityEngine.UI.Image>();
    }

    public void FixedUpdate()
    {
        // i
        // if the item is not null
        if (item != null)
        {
            if (img.sprite == null)
            {
                img.sprite = item.icon;
            }
            // if the itemname is null
            if (itemName == null)
            {
                itemName = item.itemName;
            }
            // if the grade does not equal the items grade
            if (grade != item.itemQuality)
            {
                grade = item.itemQuality;
            }
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        // if the left mouse button is clicked and held
        if (Input.GetMouseButton(0))
        {
            tempDrag.transform.position = Input.mousePosition;
            startPosition = transform.position;
            startParent = transform.parent;
            //oldParent = transform.parent;
            go = gameObject;
            go.transform.parent = tempDrag.transform;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            Debug.Log("Began Drag");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // if the player is still holding down the left mouse button
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Dragging");
            tempDrag.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // if the player releases the left mouse button
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Ended Drag");
            go = null;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            // if the parent is still the same
            if (transform.parent == tempDrag.transform)
            {
                transform.SetParent(startParent);
                transform.position = startPosition;
            }
            else
            {
                //startParent.GetComponent<Item_Slot>().NullifyItem();  
            }
        }
        //go.GetComponent<UnityEngine.UI.LayoutElement>().ignoreLayout = false;
    }

}
