
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CodeBrewery.Glime.UI.Manager {

    public class UIBehaviour : MonoBehaviour
    {
        private MainUIManager backingMainUIManager;
        protected MainUIManager MainUIManager { 
            get {
                if(backingMainUIManager == null)
                {
                    backingMainUIManager = GetComponentInParent<MainUIManager>();
                }
                return backingMainUIManager;
            }
        }

        protected CraftingUIManager CraftingUI => MainUIManager.CraftingUI;
        protected CombatUIManager CombatUI => MainUIManager.CombatUI;

    }
}
