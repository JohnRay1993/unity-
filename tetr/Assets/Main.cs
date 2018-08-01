using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Text text;

    private GameObject[,] arr = new GameObject[11, 11];


    private GameObject[] currentGObjects;

    private float mainT = 0, freeT = 0, buttonT = 0;



    // Use this for initialization
    void Start()
    {
        NewO();
    }

    private void NewO()
    {
        GameObject[] g = new GameObject[4];

        if (IsFree(0, 4))
        g[0] = Instantiate(prefab);
        if (g[0] != null)
        {
            g[0].transform.position = new Vector3(0, 4, 0);
            if (IsFree(1, 4))
            g[1] = Instantiate(prefab);
            if (g[1] != null)
            {
                g[1].transform.position = new Vector3(1, 4, 0);
                if (IsFree(0, 5))
                g[2] = Instantiate(prefab);
                if (g[2] != null)
                {
                    g[2].transform.position = new Vector3(0, 5, 0);
                    if (IsFree(1, 5))
                    g[3] = Instantiate(prefab);
                    if (g[3] != null)
                    {
                        g[3].transform.position = new Vector3(1, 5, 0);
                        if (AddNew(g))
                            currentGObjects = g;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentGObjects[0] != null && currentGObjects[1] != null && currentGObjects[2] != null && currentGObjects[3] != null)
            Move();
        else
            NewO();


        text.text = "";
        for (int i = 4; i < 9; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                text.text += arr[i, j] == null ? "0 " : "1 ";
            }
            text.text += "\r\n";
        }
        text.text += currentGObjects[0] + " " + currentGObjects[1] + " " + currentGObjects[2] + " " + currentGObjects[3];
    }

    private void Move()
    {
        if (currentGObjects[0] != null && currentGObjects[1] != null && currentGObjects[2] != null && currentGObjects[3] != null)
        {
            if (mainT <= 0)
            {
                Move(currentGObjects, Vector3.down);
                mainT = 1;
            }
            else
                mainT -= Time.deltaTime;

            float hori = Input.GetAxisRaw("Horizontal");
            float vert = Input.GetAxisRaw("Vertical");
            if (buttonT <= 0)
            {
                if (Mathf.Abs(hori) > 0)
                {
                    Move(currentGObjects, new Vector3(hori, 0, 0));
                    buttonT = 1f;
                }
            }
            else
                buttonT -= Time.deltaTime;

        }
    }

    private void Move(GameObject[] g, Vector3 dir)
    {
        for (int i = 0; i < 4; i++)
        {
            if (g[i] != null)
            {
                if (dir.y < 0 || dir.x < 0)//down
                {
                    if (g[i].transform.position.y > -5 &&
                        g[i].transform.position.x > -5 &&
                        g[i].transform.position.x <= 5)
                    {
                        if (IsFree((int)(g[i].transform.position.x + dir.x), (int)(g[i].transform.position.y + dir.y)))
                        {
                            Vector2 oldP = new Vector2(g[i].transform.position.x, g[i].transform.position.y);
                            g[i].transform.position += dir;
                            Vector2 newP = new Vector2(g[i].transform.position.x, g[i].transform.position.y);
                            arr[(int)newP.x + 5, (int)newP.y + 5] = arr[(int)oldP.x + 5, (int)oldP.y + 5];
                            arr[(int)oldP.x + 5, (int)oldP.y + 5] = null;
                        }
                        else
                            g[i] = null;
                    }
                    else
                    {
                        if (g[i].transform.position.y < -4 && dir.x != 0f)
                        {
                            g[i] = null;
                        }
                    }
                }

                if (dir.x > 0)
                {
                    int j = 3 - i;
                    if (g[j].transform.position.x < 5)
                    {
                        if (IsFree((int)(g[j].transform.position.x + dir.x), (int)(g[j].transform.position.y + dir.y)))
                        {

                            Vector2 oldP = new Vector2(g[j].transform.position.x, g[j].transform.position.y);
                            g[j].transform.position += dir;
                            Vector2 newP = new Vector2(g[j].transform.position.x, g[j].transform.position.y);
                            arr[(int)newP.x + 5, (int)newP.y + 5] = arr[(int)oldP.x + 5, (int)oldP.y + 5];
                            arr[(int)oldP.x + 5, (int)oldP.y + 5] = null;
                        }
                    }
                }
            }
        }
    }

    public bool AddNew(GameObject[] go)
    {
        if (IsFree(go))
        {
            currentGObjects = go;
            SetInstance(go);
            return true;
        }
        else
            return false;
    }

    void SetInstance(GameObject[] g)
    {
        for (int i = 0; i < 4; i++)
            arr[(int)g[i].transform.position.x + 5, (int)g[i].transform.position.y + 5] = g[i];
    }

    bool IsFree(GameObject[] g)
    {
        if (arr[(int)g[0].transform.position.x + 5, (int)g[0].transform.position.y + 5] == null)
            if (arr[(int)g[1].transform.position.x + 5, (int)g[1].transform.position.y + 5] == null)
                if (arr[(int)g[2].transform.position.x + 5, (int)g[2].transform.position.y + 5] == null)
                    if (arr[(int)g[3].transform.position.x + 5, (int)g[3].transform.position.y + 5] == null)
                        return true;
                    else
                        return false;
                else
                    return false;
            else
                return false;
        else
            return false;
    }

    bool IsFree(int x, int y)
    {
        return arr[x + 5, y + 5] == null ? true : false;
    }
}