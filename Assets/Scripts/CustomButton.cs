using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    /// <summary>
    /// Flag to check if mouse has already left the button
    /// </summary>
    private bool mouseOverButton = false;

    /// <summary>
    /// The sprite renderer that is controlled.
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Base sprite
    /// </summary>
    private Sprite normalSprite;

    /// <summary>
    /// Hover sprite
    /// </summary>
    [SerializeField]
    private Sprite hoverSprite;

    /// <summary>
    /// Down sprite
    /// </summary>
    [SerializeField]
    private Sprite downSprite;

    /// <summary>
    /// An event which is triggered on click release.
    /// </summary>
    [Header("Events")]
    [Space]
    public UnityEvent onClickEvent;


    public void Start()
    {
        BoxCollider2D boxCollider2D = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalSprite = spriteRenderer.sprite;

        if (hoverSprite == null)
        {
            hoverSprite = normalSprite;
        }

        if (downSprite == null)
        {
            downSprite = hoverSprite;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOverButton = true;
        spriteRenderer.sprite = hoverSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        spriteRenderer.sprite = downSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (mouseOverButton)
        {
            // Only invoke when the mouse is still hovering over the button
            spriteRenderer.sprite = hoverSprite;
            onClickEvent.Invoke();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOverButton = false;
        spriteRenderer.sprite = normalSprite;
    }

}
