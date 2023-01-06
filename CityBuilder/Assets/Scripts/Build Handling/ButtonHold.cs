using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Color onHoldColor = Color.white;
    public UnityEvent onHold;

    private Image myImage;

    private Color defaultColor;
    private bool isHold = false;

    private void Awake()
    {
        myImage = GetComponent<Image>();
        defaultColor = myImage.color;
    }

    private void Update()
    {
        if (isHold) onHold.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHold = true;
        myImage.color = onHoldColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHold = false;
        myImage.color = defaultColor;
    }
}
