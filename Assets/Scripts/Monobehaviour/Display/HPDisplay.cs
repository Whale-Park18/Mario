using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mario.Display
{
    public class HPDisplay : MonoBehaviour
    {
        [SerializeField]
        private HPInfo _hpInfo;

        private Image[] _hpIcons;

        private void UpdateHPIcon()
        {
            for(int i=0;i<_hpIcons.Length;i++)
            {
                if (i < _hpInfo.HP)
                    _hpIcons[i].color = Color.white;
                else
                    _hpIcons[i].color = new Color(60/255f, 60/255f, 60/255f);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            _hpIcons = new Image[transform.childCount];
            for(int i = 0; i < transform.childCount; i++)
            {
                _hpIcons[i] = transform.transform.GetChild(i).GetComponent<Image>();
            }
        }

        // Update is called once per frame
        void Update()
        {
            UpdateHPIcon();
        }
    }
}