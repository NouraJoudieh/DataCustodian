using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {
	public void OnPointerEnter(PointerEventData eventData) {
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null) {
            int index = 0;
            if (d.tag.Contains("Sel"))
            {
                
                index = 0;
            }
            else if (d.tag.Contains("From"))
            {
               
                index = 1;
            }
            else if (d.tag.Contains("Where"))
            {

                index = 2;
            }
            d.placeholderParent = transform.GetChild(index).transform;
		}
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		if(eventData.pointerDrag == null)
			return;

		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
		if(d != null && d.placeholderParent==this.transform) {
			d.placeholderParent = d.parentToReturnTo;
		}
	}
	
	public void OnDrop(PointerEventData eventData) {
        string query = "";
		Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        
        for (int i = 0; i < transform.childCount; i++)
        {
            for(int j = 0; j < transform.GetChild(i).childCount; j++)
            {
                query += transform.GetChild(i).GetChild(j).tag.Split('-')[0];
            }
        }
        
		if(d != null) {
            int index = 0;
            if (d.tag.Contains("Sel")) index = 0; //to put in row1
            else if (d.tag.Contains("From")) index = 1; //to put in row2
            else if (d.tag.Contains("Where")) index = 2; //to put in row3
			d.parentToReturnTo = this.transform.GetChild(index).transform; 
		}
    
	}
}
