using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBrewery.Glime.Battle.Potions
{
    [RequireComponent(typeof(Collider2D))]
    public class PotionSpawner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        public GameObject PotionCollider;
        private void Update()
        {
            /*if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("test");
                Vector2 mousePos = Input.mousePosition;
                Instantiate(PotionCollider, mousePos, Quaternion.identity);
            }*/
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Debug.Log("test up");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("test down");
        }
    }
}
