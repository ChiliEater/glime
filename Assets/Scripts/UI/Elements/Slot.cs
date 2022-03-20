using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBrewery.Glime.UI.Element
{
    public class Slot : MonoBehaviour
    {

        public GameObject itemPrefab;

        private GameObject itemInstance;

        void Start()
        {
            itemInstance = Instantiate(itemPrefab, transform);
        }

    }
}
