using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string ButtonText;
    public SelectCharacterController controller;
    void Awake() {
        controller = GameObject.Find("SelectCharacterController").GetComponent<SelectCharacterController>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        controller.SelectCharacter(ButtonText);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        controller.SelectCharacter("");
    }
}