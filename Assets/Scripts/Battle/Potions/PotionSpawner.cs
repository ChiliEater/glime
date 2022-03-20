using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBrewery.Glime.Battle.Potions
{
    [RequireComponent(typeof(Collider2D))]
    public class PotionSpawner : MonoBehaviour , IPointerDownHandler, IPointerUpHandler
    {
        public GameObject PotionCollider;

        public void OnPointerUp(PointerEventData eventData)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
              mousePos.z = 7;
            Instantiate(PotionCollider, mousePos, Quaternion.identity, transform);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("test down");
        }
    }
}
