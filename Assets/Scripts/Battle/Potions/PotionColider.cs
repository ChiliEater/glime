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
        private static readonly int BASE_DAMAGE = 2;
        private static readonly int DAMAGE_MODIFIER = 3;
        private static readonly int ADDED_SPEED = 3;

        private static readonly float POTION_EFFECT_DURATION = 3;
        public bool DisableDestroy = false;
        public Potion potion { get; set; }
        private float spawnedAt;

        void Start()
        {
            spawnedAt = Time.timeSinceLevelLoad;
        }

        void Update()
        {
            if (spawnedAt + POTION_EFFECT_DURATION < Time.timeSinceLevelLoad && !DisableDestroy)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                ApplyDamage(enemy, potion);
            }
        }

        private void ApplyDamage(Enemy enemy, Potion potion)
        {
            int damage = 0;
            int attack = 0;
            List<EnemyType> enemyTypes = enemy.Type;
            foreach(KeyValuePair<PotionType, int> keyValue in potion.PotionTypes)
            {
                PotionType potionType = keyValue.Key;
                int potionCount = keyValue.Value;
                if(potionType == PotionType.Fire)
                {
                    damage += GetIceFireDamageType(EnemyType.Ice, EnemyType.Hellish, enemyTypes)*potionCount;
                }
                else if(potionType == PotionType.Ice)
                {
                    damage += GetIceFireDamageType(EnemyType.Hellish, EnemyType.Ice, enemyTypes)*potionCount;
                } else if(potionType == PotionType.Healing)
                {
                    if (enemyTypes.Contains(EnemyType.Undead))
                    {
                        damage += BASE_DAMAGE*potionCount;
                    }
                    else
                    {
                        damage -= BASE_DAMAGE*potionCount;
                    }
                } else if(potionType == PotionType.Strength)
                {
                    if(enemyTypes.Contains(EnemyType.Undead))
                    {
                        attack += BASE_DAMAGE*potionCount;
                    }
                }
            }
            enemy.HitPoints -= damage;
            enemy.Attack = Mathf.Min(0, enemy.Attack - attack);
        }

        private int GetIceFireDamageType(EnemyType advantageType, EnemyType disadvantageType, List<EnemyType> enemyTypes)
        {

            int damage = BASE_DAMAGE;
            if(enemyTypes.Contains(advantageType) )
            {
                damage += DAMAGE_MODIFIER; 
            } else if(enemyTypes.Contains(disadvantageType))
            {
                damage -= DAMAGE_MODIFIER; 
            }
            return damage;
        }

    }
}
