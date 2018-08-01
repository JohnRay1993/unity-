using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour {

    [SerializeField] private Text text;

    bool[,] field = new bool[11, 11];   //true - busy, false - free
    GameObject[,] obj = new GameObject[11, 11];
    

    public bool isFreeCell(Vector2 t)
    {
        //true - free
        if (field[(int)t.x + 5, (int)t.y + 5] == true)
            return false;
        return true;
    }

    public void Move(Vector2 oldP, Vector2 newP)
    {
        field[(int)oldP.x + 5, (int)oldP.y + 5] = false;
        field[(int)newP.x + 5, (int)newP.y + 5] = true;
    }

    public void AddGO(GameObject go)
    {
        int x = (int)go.transform.position.x + 5;
        int y = (int)go.transform.position.y + 5;

        if (obj[x, y] == null)
        {
            obj[x, y] = go;
            text.text += "\r\nnew " + go.transform.position;
        }
        else
            Debug.Log("obj[" + x + ", " + y + "] is not null");
    }




    private void Update()
    {

        //destroy full line and offset others
        for (int i = 10; i >=0; i--)
        {
            if (obj[i, 0] != null && 
                obj[i, 1] != null && 
                obj[i, 2] != null && 
                obj[i, 3] != null && 
                obj[i, 4] != null && 
                obj[i, 5] != null && 
                obj[i, 6] != null && 
                obj[i, 7] != null && 
                obj[i, 8] != null && 
                obj[i, 9] != null && 
                obj[i, 10] != null && 
                obj[i, 11] != null)
            {
                for (int i1 = i; i1 >= 0; i1--)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        obj[i1, j] = obj[i1 - 1, j];
                        if (obj[i1, j] != null)
                        {
                            Vector2 oldP, newP;
                            oldP.x = obj[i1, j].transform.position.x;
                            oldP.y = obj[i1, j].transform.position.y;
                            obj[i1, j].transform.position += Vector3.down;
                            newP.x = obj[i1, j].transform.position.x;
                            newP.y = obj[i1, j].transform.position.y;
                            Move(oldP, newP);
                        }
                    }
                }
            }
        }



    }



}
