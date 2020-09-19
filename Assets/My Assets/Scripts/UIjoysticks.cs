using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIjoysticks : MonoBehaviour
{

   
    public Vector3 initPosition;
   
    public float r;
    
    public Transform border;

    public bool m_isDrag = false;
    void Start()
    {
        border = GameObject.Find("border").transform;
        initPosition = GetComponentInParent<RectTransform>().position;
        r = Vector3.Distance(transform.position, border.position);
        StartCoroutine(Move());
    }


    IEnumerator Move()
    {

            while (m_isDrag)
            {
                if (transform.localPosition.x > 0)
                {
                    float angle = Mathf.Atan(transform.localPosition.y / transform.localPosition.x);
                    if (angle > Mathf.PI / 4)
                    {
                        PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_UP;
                        yield return new WaitForFixedUpdate();
                        if (PacmanMove.PACMAN_CANMOVE == false)
                        {
                            PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_RIGHT;
                            yield return new WaitForFixedUpdate();
                        }
                    }
                    else if (angle < -Mathf.PI / 4)
                    {
                        PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_DOWN;
                        yield return new WaitForFixedUpdate();
                        if (PacmanMove.PACMAN_CANMOVE == false)
                        {
                            PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_RIGHT;
                            yield return new WaitForFixedUpdate();
                        }
                    }

                    else
                    {
                        PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_RIGHT;
                        yield return new WaitForFixedUpdate();
                        if (PacmanMove.PACMAN_CANMOVE == false)
                        {
                            if (angle > 0)
                            {
                                PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_UP;
                                yield return new WaitForFixedUpdate();
                            }
                            else
                            {
                                PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_DOWN;
                                yield return new WaitForFixedUpdate();
                            }
                        }

                    }
                }
                else if (transform.localPosition.x <= 0)
                {
                    float angle = Mathf.Atan(transform.localPosition.y / -transform.localPosition.x);
                    //print("angle:" + Mathf.Atan(transform.localPosition.y / -transform.localPosition.x));
                    //print("y:" + transform.localPosition.y);
                    //print("x:" + transform.localPosition.x);
                    if (angle > Mathf.PI / 4)
                    {
                        PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_UP;
                        yield return new WaitForFixedUpdate();
                        if (PacmanMove.PACMAN_CANMOVE == false)
                        {
                            PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_LEFT;
                            yield return new WaitForFixedUpdate();
                        }
                    }
                    else if (angle < -Mathf.PI / 4)
                    {
                        PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_DOWN;
                        yield return new WaitForFixedUpdate();
                        if (PacmanMove.PACMAN_CANMOVE == false)
                        {
                            PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_LEFT;
                            yield return new WaitForFixedUpdate();
                        }
                    }
                    else
                    {
                        PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_LEFT;
                        yield return new WaitForFixedUpdate();
                        if (PacmanMove.PACMAN_CANMOVE == false)
                        {
                            if (angle > 0)
                            {
                                PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_UP;
                                yield return new WaitForFixedUpdate();
                            }
                            else
                            {
                                PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_DOWN;
                                yield return new WaitForFixedUpdate();
                            }
                        }
                    }
                }
            }
            yield return new WaitForFixedUpdate();
            StartCoroutine(Move());

        
    }

    public void OnDragIng()
    {
   
        if (Vector3.Distance(Input.mousePosition, initPosition) < r)
        {
    
            transform.position = Input.mousePosition;
        }
        else
        {
       
            Vector3 dir = Input.mousePosition - initPosition;            transform.position = initPosition + dir.normalized * r;

        }
        m_isDrag = true;
    }

    public void OnDragEnd()
    {

        transform.position = initPosition;
        m_isDrag = false;
        PacmanMove.m_PacmanMoveState = PacmanMove.MOVE_NONE;
    }
}