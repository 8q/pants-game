using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SoundTrackButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public void OnPointerEnter( PointerEventData eventData )
	{
		this.transform.localScale = new Vector3(1.15f, 1.15f, 1.0f);
	}

	public void OnPointerExit( PointerEventData eventData )
	{
		this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	}
}