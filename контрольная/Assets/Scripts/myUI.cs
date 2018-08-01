using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class myUI : MonoBehaviour
    {

        [SerializeField] private Text text;

        private int curCoins = 0;

        public int Coins
        {
            get
            {
                return curCoins;
            }
            set
            {
                curCoins = value;
                text.text = "Coins " + curCoins;
            }
        }

        private void Start()
        {
            Coins = 0;
        }
    }
}