using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;   //이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f;            //이동 속력
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");         // 수평 축
        float zInput = Input.GetAxis("Vertical");           // 수직 축
        // 수평 축과 수직 축의 입력값을 감지하여 저장

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        // 실제 이동 속도를 입력값과 이동 속력을 사용해 결정

        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);       // Vetcot3 속도 설정
        playerRigidbody.velocity = newVelocity;                     // 리지드바디 속도에 newVelocity할당
        
    
    }

    public void Die()
    {
        gameObject.SetActive(false);        // 게임오브젝트 비활성화

        GameManager gameManager = FindObjectOfType<GameManager>();   // 씬에 존재하는 GameManager타입의 오브젝트를 찾아서 가져오기
        gameManager.EndGame();                                       // 가져온 GameManager 오브젝트의 EndGame() 함수 실행
    }
}
