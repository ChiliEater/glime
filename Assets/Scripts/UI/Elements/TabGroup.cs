using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBrewery.Glime.UI.Element
{
    public class TabGroup : MonoBehaviour
    {
        public List<ManagedTab> Tabs;

        public int CurrentTabIndex { get; private set; } = 0;
        public ManagedTab CurrentTab => Tabs.FirstOrDefault();

        public UnityEvent<TabGroup> OnTabChanged;

        void Start()
        {
        }

        public void ActivateTab(ManagedTab tab)
        {
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
            public bool IsInitialSelection;
            public Sprite UntoggledSprite;
            public Sprite ToggledSprite;
            private Image image;
            public TabGroup TabGroup;

            public bool IsTabActivated => TabGroup.CurrentTab == this;

            public int TabIndex => TabGroup.Tabs.IndexOf(this);


            void Start()
            {
                image = GetComponent<Image>();
                if (TabGroup == null) {
                    throw new System.Exception($"No tab group found for tab {gameObject.GetPath()}");
                }
                if(IsInitialSelection)
                {
                    ((IManagedTab) this).OnTabActivated();
                }
            }

            public void ActivateTab()
            {
                TabGroup.ActivateTab(this);
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
