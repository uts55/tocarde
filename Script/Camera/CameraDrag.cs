using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CameraDrag : MonoBehaviour
{
    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;

    float z = 0.0f;

    //진동할 시간
    public float ShakeTime;
    //진동량 -진동할 거리
    public float ShakeAmount;
    //진동할 카메라의 속도
    public float ShakeSpeed;
    internal bool shake;
    new AudioSource audio;

    void Start()
    {
        audio = GetComponentInChildren<AudioSource>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Input.mousePosition.y > 250 / 1080.0f * Screen.height)
                {
                    hit_position = Input.mousePosition;
                    camera_position = transform.position;
                }
                else
                {
                    hit_position = Vector3.zero;
                }
            }
            if (Input.GetMouseButton(0) && Input.mousePosition.y > 250 / 1080.0f * Screen.height && hit_position != Vector3.zero)
            {
                current_position = Input.mousePosition;
                MouseDrag();
            }
            if (shake == true)
            {
                StartCoroutine(Shake());
            }
        }
    }

    void MouseDrag()
    {
        current_position.z = hit_position.z = camera_position.y;

        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);
        
        direction = direction * -1;

        Vector3 position = camera_position + direction;
        
        if (position.x > 2.51f)
        {
            position.x = 2.51f; 
        }
        else if (position.x < -26.1f)
        {
            position.x = -26.1f;
        }

        transform.position = new Vector3(position.x, 0, position.z);
    }
    IEnumerator Shake()
    {
        audio.Play();
        shake = false;
        //카메라의 원래 위치를 저장해둔다.
        Vector3 OrigPosition = transform.localPosition;

        //소요시간(초)을 잰다.
        float ElapsedTime = 0.0f;

        //총 진동 시간 동안 반복한다.
        while (ElapsedTime < ShakeTime)
        {
            //단위 구상의 한 점을 무작위로 선택한다.
            Vector3 RandomPoint = OrigPosition + Random.insideUnitSphere * ShakeAmount;

            //위치를 업데이트한다.
            transform.localPosition = Vector3.Lerp(transform.localPosition, RandomPoint, Time.deltaTime * ShakeSpeed);

            //다음 프레임까지 멈춘다.
            yield return null;

            //시간을 업데이트한다.
            ElapsedTime += Time.deltaTime;
        }

        //카메라의 위치를 원래대로 되돌린다.
        transform.localPosition = OrigPosition;
    }
}