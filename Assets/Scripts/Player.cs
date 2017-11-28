﻿using UnityEngine;
using System.Collections;




/*
 *	플레이어 클래스
 *	Maruchu
 *
 *	캐릭터 이동, 메카님(모션) 제어
 */
public class Player : MonoBehaviour
{


    BoxCollider boxcollisioncomponent;
    public GameObject playerObject = null;      //움직일 대상 모델
    public GameObject bulletObject = null;      //총알 프리팹

    public Transform bulletStartPosition = null;        //총알 발사 위치를 얻는 본



    private static readonly float MOVE_Z_FRONT = 5.0f;  //전진 속도
    private static readonly float MOVE_Z_BACK = -2.0f;  //후퇴 속도

    private static readonly float ROTATION_Y_KEY = 360.0f;  //회전 속도(키보드)
    private static readonly float ROTATION_Y_MOUSE = 720.0f;    //회전 속도(마우스)

    private float m_rotationY = 0.0f;       //플레이어의 회전 각도

    private bool m_mouseLockFlag = true;        //마우스를 고정하는 기능

    private float _doubleTapTime;
    bool doubleTap = false;
    private Vector3 startPOS;
    private Vector3 startROT;

    private void Start()
    {
        startPOS = transform.position;
        startROT = transform.position;
        boxcollisioncomponent = GetComponent<BoxCollider>();
    }
    public bool toggle = false;

    /*
	 *	매 프레임마다 호출되는 함수(invoked functions each frame)
	 */
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            toggle = !toggle;
            Debug.Log("key is pressed");
            GameObject[] walls = GameObject.FindGameObjectsWithTag("wall");

            foreach (GameObject go in walls)
            {
                go.GetComponent<BoxCollider>().enabled = toggle;

            }


        }

        //스테이지가 종료되면 조작을 무시한다(ignore control when finishing stage)
        if (Game.IsStageCleared())
        {
            return;
        }

        //마우스 잠금 처리(Lock mouse)
        CheckMouseLock();

        //이동 처리(movement)
        CheckMove();


      //  if (Input.GetKey(KeyCode.C)) {

        //    boxcollisioncomponent.enabled = false;
     //   }

       


    }




    /*
	 *	마우스 잠금 처리 검사(confirm whether mouse is locked or not)
	 */
    private void CheckMouseLock()
    {

        //Esc 키를 눌렀을 때의 동작(when pressing ESC)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //플래그를 반전시킨다(Reverse Flag)
            m_mouseLockFlag = !m_mouseLockFlag;
        }

        //마우스가 잠겨있는지 검사(Confirm mouse is lokced or not)
        if (m_mouseLockFlag)
        {
            //잠겨 있으면 잠금 해제(If locked, unlock)
            Screen.lockCursor = true;
            Cursor.visible = false;
        }
        else
        {
            //잠금이 해제되어 있다면 잠금(If unlocked, lock)
            Screen.lockCursor = false;
            Cursor.visible = true;
        }
    }
    /*
 *	이동 처리 검사(confirm movement)
 */
    private void CheckMove()
    {

        //회전(rotation)
        {
            //이 프레임에서 움직이는 회전량(amount of rotaion each frame)
            float addRotationY = 0.0f;

            //키 조작으로 회전(rotation by key control
            if (Input.GetKey(KeyCode.A))
            {
                addRotationY = -ROTATION_Y_KEY;
            }
            else
            if (Input.GetKey(KeyCode.D))
            {
                addRotationY = ROTATION_Y_KEY;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                addRotationY = -ROTATION_Y_KEY;
            }
            else
            if (Input.GetKey(KeyCode.RightArrow))
            {
                addRotationY = ROTATION_Y_KEY;
            }

            Vector3 vecInput1 = new Vector3(0f, Input.GetAxisRaw("Horizontal"), 0);
            if (vecInput1.y > 0)
            {
                addRotationY = ROTATION_Y_KEY;
            } else if (vecInput1.y < 0)
            {
                addRotationY = -ROTATION_Y_KEY;
            }



            //마우스 이동량에 의한 회전
            if (m_mouseLockFlag)
            {
                //이동량을 얻어서 각도 처리로 넘겨준다
                addRotationY += (Input.GetAxis("Mouse X") * ROTATION_Y_MOUSE);
            }

            //현재 각도에 더한다
            m_rotationY += (addRotationY * Time.deltaTime);
            /* 
             * 이동량, 회전량에는 Time.deltaTime을 곱해서 실행 환경(기기 성능에 의해 발생되는 프레임 수의 차이)에 따라 차이가 없게 한다
             */


            //오일러 각으로 입력한다
            transform.rotation = Quaternion.Euler(0, m_rotationY, 0);       //Y축 회전으로 캐릭터 방향을 옆으로 바꾼다
        }

        //이동
        Vector3 addPosition = Vector3.zero;     //이동량(z 값은 메카님에도 넘겨준다)
        {

            //키 조작에서 이동할 양을 얻는다
            Vector3 vecInput = new Vector3(0f, 0, Input.GetAxisRaw("Vertical"));        // 앞뒤 방향 입력 값을 받아 Z에 넣는다([W], [S] 게임 패드 입력 등)

            //Z에 값이 입력되어 있는지 확인한다
            if (vecInput.z > 0)
            {
                //전진
                addPosition.z = MOVE_Z_FRONT;
            }
            else
            if (vecInput.z < 0)
            {
                //후퇴
                addPosition.z = MOVE_Z_BACK;
            }

            //이동량을 Transform에 넘겨주어 이동시킨다
            transform.position += ((transform.rotation * addPosition) * Time.deltaTime);
            /*
                Vector3 형식으로 transform.rotation을 곱하면 그 방향으로 꺾어진다
                이 때 Vector3는 Z+ 방향을 정면으로 여긴다
             */
        }

        //사격
        bool shootFlag;
        {
            //사격 버튼(클릭)을 눌렀는지 확인한다
            if (Input.GetButtonDown("Fire1"))
            {
                //사격 처리
                shootFlag = true;

                //총알을 발사할 위치가 지정되어 있는지 여부를 검사
                if (null != bulletStartPosition)
                {
                    //총알을 생성할 위치 지정
                    Vector3 vecBulletPos = bulletStartPosition.position;
                    //전진하는 방향으로 조금 진행한다
                    vecBulletPos += (transform.rotation * Vector3.forward);
                    //Y 높이를 적당히 올린다
                    vecBulletPos.y = 1.0f;

                    //총알을 생성한다
                    Instantiate(bulletObject, vecBulletPos, transform.rotation);
                }
            }
            else
            {
                //발사하지 않는다
                shootFlag = false;
            }
        }


        // 메카님(모션)
        {
            // 애니메이터를 얻는다
            Animator animator = playerObject.GetComponent<Animator>();

            // 설정한 값을 Animator로 넘겨준다
            animator.SetFloat("SpeedZ", addPosition.z); // Z(앞뒤 방향 이동량)
            animator.SetBool("Shoot", shootFlag);       // 사격 플래그
        }


        //reset CURRENT player position
        if (Input.GetKey(KeyCode.End))
        {

            transform.position = startPOS;
            transform.position = startROT;
        }



        //logging that checks for double tapping
        if (doubleTap == true)
        {

            Debug.Log("double tap worked");
            doubleTap = false;
        }


        if (Input.GetKey(KeyCode.I))
        {
            gameObject.layer = LayerMask.NameToLayer("ghost");


        }



        //adding comments here to test out github close and pull requests

    }
}