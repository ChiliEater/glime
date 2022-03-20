using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBrewery.Glime.UI.Element
{
    public class TabGroup : MonoBehaviour
    {
        public List<ManagedTab> Tabs { get; } = new List<ManagedTab>();

        public int CurrentTabIndex { get; private set; } = 0;
        public ManagedTab CurrentTab => Tabs[CurrentTabIndex];

        public UnityEvent<TabGroup> OnTabChanged;

        void Start()
        {
            Tabs.AddRange(GetComponentsInChildren<Tab>());
        }

        public void ActivateTab(ManagedTab tab)
        {
            Debug.Log("try to activate tab " + tab.gameObject.GetPath());
            int index = Tabs.IndexOf(tab);
            if(index < 0)
            {
                throw new Exception($"Unkown tab {tab.gameObject.GetPath()}");
            }
            ActivateTab(index);
        }

        public void ActivateTab(int tabIndex)
        {
            if(tabIndex == CurrentTabIndex) return;
            if(tabIndex < 0 || tabIndex > Tabs.Count)
            {
                throw new IndexOutOfRangeException($"Selected tab index {tabIndex} is out of bounds. (Number of tabs: {Tabs.Count})");
            }

            IManagedTab oldTab = (IManagedTab)CurrentTab;
            oldTab?.OnTabDeactivated();
            CurrentTabIndex = tabIndex;
            IManagedTab newTab = (IManagedTab)CurrentTab;
            newTab?.OnTabActivated();
            OnTabChanged.Invoke(this);
        }

        protected interface IManagedTab
        {
            void OnTabDeactivated();
            void OnTabActivated();
        }

        [RequireComponent(typeof(Image))]
        public class ManagedTab : MonoBehaviour, IManagedTab
        {
            public Sprite UntoggledSprite;
            public Sprite ToggledSprite;
            private Image image;
            private TabGroup tabGroup;

            public bool IsTabActivated => tabGroup.CurrentTab == this;

            private void Start()
            {
                image = GetComponent<Image>();
                tabGroup = GetComponentInParent<TabGroup>();
                if (tabGroup == null) {
                    throw new System.Exception($"No tab group found for tab {gameObject.GetPath()}");
                }
            }

            public void ActivateTab()
            {
                tabGroup.ActivateTab(this);
            }

            void IManagedTab.OnTabActivated()
            {
                image.sprite = ToggledSprite;                 
            }

            void IManagedTab.OnTabDeactivated()
            {
                image.sprite = UntoggledSprite;                 
            }
        }
    }
}
