using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Mario.Display
{
    public class TimeDisplay : MonoBehaviour
    {
        [SerializeField]
        private Text _timeText;

        private int _hour;
        private int _minute;
        private float _second;

        private void UpdateTime()
        {
            _second += Time.deltaTime;

            if((int)_second >= 60)
            {
                _second = 0;
                _minute++;
            }

            if(_minute >= 60)
            {
                _minute = 0;
                _hour++;
            }

            _timeText.text = string.Format("{0:D2}:{1:D2}:{2:D2}", _hour, _minute, (int)_second);
        }

        // Start is called before the first frame update
        void Start()
        {
            _second = _minute = 0;
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTime();
        }
    }
}
