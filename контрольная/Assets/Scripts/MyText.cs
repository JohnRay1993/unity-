using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class MyText : MonoBehaviour
    {
        [SerializeField] Text text;

        string coinsText;
        public int Coins{
            get{
                return Coins;
            }
            set{
                Coins = value;
                coinsText = "Coins" + coinsText;
            }
        }

        // Use this for initialization
        void Start()
        {
            Coins = 0;
        }

        // Update is called once per frame
        void Update()
        {
            text.text = coinsText;
        }
    }
}