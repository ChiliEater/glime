
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CodeBrewery.Glime.UI.Manager {

    public class UIBehaviour : MonoBehaviour
    {
        private MainUIManager backingMainUIManager;
        protected MainUIManager mainUIManager { 
            get {
                if(backingMainUIManager == null)
                {
                    backingMainUIManager = GetComponentInParent<MainUIManager>();
                }
                return backingMainUIManager;
            }
        }

    }
}
