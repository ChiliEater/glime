using CodeBrewery.Glime.Battle;
using CodeBrewery.Glime.Battle.Potions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CodeBrewery.Glime.Battle.Potions
{

    [RequireComponent(typeof(Collider2D))]
    public class PotionColider : MonoBehaviour
    {
        private static readonly float POTION_EFFECT_DURATION = 3;
        public Potion potion { get; set; }
        private float spawnedAt;

        void Start()
        {
            spawnedAt = Time.timeSinceLevelLoad;
        }

        void Update()
        {
            if (spawnedAt + POTION_EFFECT_DURATION > Time.timeSinceLevelLoad)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {

            }
        }
    }
}
