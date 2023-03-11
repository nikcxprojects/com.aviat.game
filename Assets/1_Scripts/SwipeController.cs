using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    [SerializeField] private Reels _reels;
    
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    
    private void Update()
    {
    #if UNITY_EDITOR
        PCSwipe();
    #else
        MobileSwipe();
    #endif
    }

    private void PCSwipe()
    {
        if(Input.GetMouseButtonDown(0))
        {
            firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            currentSwipe.Normalize();
 
            //switch (currentSwipe.y)
            //{
            //    case > 0 when currentSwipe.x is > -0.5f and < 0.5f:
            //        _reels.Up();
            //        break;
            //    case < 0 when currentSwipe.x is > -0.5f and < 0.5f:
            //        _reels.Down();
            //        break;
            //}
        }
    }

    private void MobileSwipe()
    {
        if(Input.touches.Length > 0)
        {
            var t = Input.GetTouch(0);
            if(t.phase == TouchPhase.Began)
            {
                firstPressPos = new Vector2(t.position.x,t.position.y);
            }
            else if(t.phase == TouchPhase.Ended)
            {
                secondPressPos = new Vector2(t.position.x,t.position.y);
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                currentSwipe.Normalize();
 
                //switch (currentSwipe.y)
                //{
                //    case > 0 when currentSwipe.x is > -0.5f and < 0.5f:
                //        _reels.Up();
                //        break;
                //    case < 0 when currentSwipe.x is > -0.5f and < 0.5f:
                //        _reels.Down();
                //        break;
                //}
            }
        }
    }
}
