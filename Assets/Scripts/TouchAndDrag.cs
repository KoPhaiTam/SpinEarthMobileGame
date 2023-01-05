using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndDrag : MonoBehaviour
{
    public float rotateSpeed;
    private bool isDragging; //bi?n d�ng ?? ki?m tra c� ?ang ch?m kh�ng
    private Vector2 touchPosittion;// tr? v? v? tr� ch?m
    private Rigidbody2D rb;// bi?n x�c ??nh c� ?ang k�o v?t th? kh�ng
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            //touchPosition ???c g�n gi� tr? c?a v? tr� ???c ch?m tr�n m�n h�nh
            touchPosittion = Camera.main.ScreenToWorldPoint(touch.position);

            if(touch.phase == TouchPhase.Began)
            {
                //ch?m v�o trong ph?m vi c?a collider
                if(GetComponent<Collider2D>().OverlapPoint(touchPosittion))
                {
                    isDragging = true;
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                isDragging=false;
            }
        }

        
        if (isDragging)
        {
            rb.velocity = Vector2.zero;
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        if (!isDragging)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }

    }
}
