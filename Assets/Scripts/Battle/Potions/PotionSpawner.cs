using CodeBrewery.Glime.UI.Manager;
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
        public MainUIManager mainUIManager;

        public void OnPointerDown(PointerEventData eventData)
        {
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Potion potion = mainUIManager.PotionShelf.CurrentPotion;
            if (potion == null) return;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
              mousePos.z = 7;
            GameObject colider = Instantiate(PotionCollider, mousePos, Quaternion.identity, transform);
            colider.GetComponent<PotionColider>().potion = potion;
        }

    }
}
