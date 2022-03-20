using CodeBrewery.Glime.Battle.Potions;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace CodeBrewery.Glime.UI.Model
{
    public class PotionShelf
    {
        private int currentPotion = 0;
        private List<Potion> potions = new List<Potion>();
        public IReadOnlyList<Potion> Potions => potions;

        public delegate void PotionSwitchHandler(Potion potion);
        public event PotionSwitchHandler OnPotionSwitchEvent;
        public delegate void PotionSetHandler(int index, Potion potion);
        public event PotionSetHandler OnPotionSetEvent;

        private Potion CurrentPotion {
            get
            {
                if (currentPotion < 0 || currentPotion >= potions.Count) return null;
                return potions[currentPotion];
            }
        }

        public PotionShelf(int numberOfPotions)
        {
            for(int i = 0;i < numberOfPotions; i++)
            {
                potions.Add(Potion.EMPTY_POTION);
            }
        }


        public void SetPotion(int index, Potion potion)
        {
            if(index < 0 || index >= potions.Count)
            {
                throw new IndexOutOfRangeException($"The potion index {index} is out of bounds (number of potions: {potions.Count})");
            }
            potions[index] = potion;
            OnPotionSetEvent.Invoke(index, potion);
        }

        public void SetCurrentPotion(int index)
        {
            if(index < 0 || index >= potions.Count)
            {
                throw new IndexOutOfRangeException($"The potion index {index} is out of bounds (number of potions: {potions.Count})");
            }
            currentPotion = index;
            OnPotionSwitchEvent.Invoke(CurrentPotion);
        }
    }
}