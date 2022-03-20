using CodeBrewery.Glime.Battle.Potions;
using CodeBrewery.Glime.UI.Manager;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBrewery.Glime.UI.Element
{
    [RequireComponent(typeof(Tab))]
    public class BattlePotionSlot : UIBehaviour
    {
        private Tab tab;
        public Image Image;
        public Sprite EmptyPotionSprite;
        public Sprite FullPotionSprite;

        void Start()
        {
            tab = GetComponent<Tab>();
            Image.sprite = EmptyPotionSprite;
            PotionShelf.OnPotionSetEvent += PotionSetHandler;
        }

        private void PotionSetHandler(int index, Potion potion)
        {
            if(index == tab.TabIndex)
            {
                if(potion == Potion.EMPTY_POTION)
                {
                    ShowEmptyBottle();
                } else
                {
                    ShowFullPotion();
                }
            }
        }

        private void Update()
        {
        }

        public void ShowEmptyBottle()
        {
            Image.sprite = EmptyPotionSprite;
        }

        public void ShowFullPotion()
        {
            Image.sprite = FullPotionSprite;
        }

    }
}