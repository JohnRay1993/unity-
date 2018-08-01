using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class Hit : MonoBehaviour
    {
        //[SerializeField] private game.UI ui;
        [SerializeField] private game.myUI p;

        private void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    GameObject hitObj = hit.collider.gameObject;
                    if (hitObj)
                    {
                        Destroy(hitObj);
                        Debug.Log("HIT");
                        p.Coins++;
                    }
                }
            }

        }
    }
}