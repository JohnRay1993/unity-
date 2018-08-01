using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private GameObject[] blocks = new GameObject[4];
    [SerializeField] private Field f;
    [SerializeField] private Creator creator;

    private bool enable = true;

    private int speed = 1;

    private float maincd = 0.0f, cooldownH = 0.0f, cooldownV = 0.0f;

    private Vector2 newTransform;
    private Vector2 left, right, top, bottom;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
            Move();
    }


    private void Move()
    {
        GetPos();
        if (right.x <= 5 && left.x >= -5 && bottom.y > -5)
        {
            if (maincd <= 0.0f)
            {
                newTransform = new Vector2(bottom.x, bottom.y - 1);
                if (f.isFreeCell(newTransform))
                {
                    Vector2 oldPos, newPos;
                    oldPos = new Vector2(transform.position.x, transform.position.y);
                    transform.position += Vector3.down;
                    newPos = new Vector2(transform.position.x, transform.position.y);
                    //Debug.Log("down " + oldPos + " " + newPos);
                    f.Move(oldPos, newPos);
                }
                else
                {
                    Debug.Log("enable false");
                    enable = false;
                    f.AddGO(blocks[0]);
                    f.AddGO(blocks[1]);
                    f.AddGO(blocks[2]);
                    f.AddGO(blocks[3]);
                    creator.CreateOne();
                }
                maincd = 1f;
            }
            else
                maincd -= Time.deltaTime;

            float vert = Input.GetAxisRaw("Vertical");
            float hori = Input.GetAxisRaw("Horizontal");


            if (hori == 0.0f)
            {
                cooldownH = 0.0f;
            }

            if (cooldownH <= 0.0f)
            {
                if (Mathf.Abs(hori) == 1)
                {
                    newTransform = new Vector2((hori < 0 ? left.x : right.x) + hori, transform.position.y);
                    if (f.isFreeCell(newTransform))
                    {
                        Vector2 oldP, newP;
                        oldP = new Vector2(transform.position.x, transform.position.y);
                        transform.position += new Vector3(hori, 0.0f, 0.0f);
                        newP = new Vector2(transform.position.x, transform.position.y);
                        f.Move(oldP, newP);
                    }
                    hori = 0;
                    cooldownH = 0.2f;
                }
            }
            else
                cooldownH -= Time.deltaTime;



            if (vert == -1f)
            {
                if (cooldownV <= 0.0f)
                {
                    Debug.Log("vert down");
                    newTransform = new Vector2(bottom.x, bottom.y - 1);
                    if (f.isFreeCell(newTransform))
                    {
                        Vector2 oldP, newP;
                        oldP = new Vector2(transform.position.x, transform.position.y);
                        transform.position += Vector3.down;
                        newP = new Vector2(transform.position.x, transform.position.y);
                        f.Move(oldP, newP);
                    }
                    else
                    {
                        Debug.Log("enable false");
                        enable = false;
                        f.AddGO(blocks[0]);
                        f.AddGO(blocks[1]);
                        f.AddGO(blocks[2]);
                        f.AddGO(blocks[3]);
                    }
                    cooldownV = 0.1f;
                }
                else
                    cooldownV -= Time.deltaTime;
            }
        }
        else
        {
            if (bottom.y == -5)
            {
                Debug.Log("enable false");
                enable = false;
                f.AddGO(blocks[0]);
                f.AddGO(blocks[1]);
                f.AddGO(blocks[2]);
                f.AddGO(blocks[3]);
                creator.CreateOne();
            }
        }
    }

    private void GetPos()
    {
        left = new Vector2(blocks[0].transform.position.x, blocks[0].transform.position.y);
        if (left.x > blocks[1].transform.position.x) left = new Vector2(blocks[1].transform.position.x, blocks[1].transform.position.y);
        if (left.x > blocks[2].transform.position.x) left = new Vector2(blocks[2].transform.position.x, blocks[2].transform.position.y);
        if (left.x > blocks[3].transform.position.x) left = new Vector2(blocks[3].transform.position.x, blocks[3].transform.position.y);

        right = new Vector2(blocks[0].transform.position.x, blocks[0].transform.position.y);
        if (right.x < blocks[1].transform.position.x) right = new Vector2(blocks[1].transform.position.x, blocks[1].transform.position.y);
        if (right.x < blocks[2].transform.position.x) right = new Vector2(blocks[2].transform.position.x, blocks[2].transform.position.y);
        if (right.x < blocks[3].transform.position.x) right = new Vector2(blocks[3].transform.position.x, blocks[3].transform.position.y);

        top = new Vector2(blocks[0].transform.position.x, blocks[0].transform.position.y);
        if (top.y < blocks[1].transform.position.y) top = new Vector2(blocks[1].transform.position.x, blocks[1].transform.position.y);
        if (top.y < blocks[2].transform.position.y) top = new Vector2(blocks[2].transform.position.x, blocks[2].transform.position.y);
        if (top.y < blocks[3].transform.position.y) top = new Vector2(blocks[3].transform.position.x, blocks[3].transform.position.y);

        bottom = new Vector2(blocks[0].transform.position.x, blocks[0].transform.position.y);
        if (bottom.x > blocks[1].transform.position.y) bottom = new Vector2(blocks[1].transform.position.x, blocks[1].transform.position.y);
        if (bottom.x > blocks[2].transform.position.y) bottom = new Vector2(blocks[2].transform.position.x, blocks[2].transform.position.y);
        if (bottom.x > blocks[3].transform.position.y) bottom = new Vector2(blocks[3].transform.position.x, blocks[3].transform.position.y);
    }
}
