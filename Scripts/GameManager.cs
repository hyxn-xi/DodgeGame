using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   // UI관련 라이브러리
using UnityEngine.SceneManagement;      // Scene관련 라이브러리
using TMPro;                            // TextMeshPro관련 라이브러리

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;     // 게임오버 시 활성화할 텍스트 게임 오브젝트
    public TMP_Text timeText;           // 생존 시간을 표시할 텍스트 컴포넌트
    public TMP_Text recordText;         // 최고기록 표시 텍스트 컴포넌트

    private float surviveTime;          // 생존 시간
    private bool isGameover;            // 게임 오버

    void Start()
    {
        surviveTime = 0;                // 생존 시간 초기화
        isGameover = false;             // 게임오버 상태 초기화
    }

    void Update()
    {
        if (!isGameover)                // 게임오버가 아닌 동안
        {
            surviveTime += Time.deltaTime;                      // 생존시간 갱신
            timeText.text = "Time : " + (int)surviveTime;       // 갱신한 생존시간을 timeText 텍스트 컴포넌트를 이용해 표시
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))                    // 게임오버 상태에서 R키를 누를 경우
            {
                SceneManager.LoadScene("SampleScene");          // SampleScene 씬을 로드
            }
        }
    }
    public void EndGame()           // 현재 게임을 게임오버 상태로 변경하는 함수
    {
        isGameover = true;                                  // 현재 상태를 게임오버 상태로 전환
        gameoverText.SetActive(true);                       // 게임오버 텍스트 게임 오브젝트를 활성화

        float bestTime = PlayerPrefs.GetFloat("BestTime");  // BestTime 키로 저장된 이전까지의 최고기록 불러오기

        if (surviveTime > bestTime)                         // 이전까지의 최고기록보다 현재 생존 시간이 더 길다면
        {
            bestTime = surviveTime;                         // 최고기록 값을 현재 생존시간 값으로 변경
            PlayerPrefs.SetFloat("BestTime", bestTime);    // 변경된 최고 기록을 BestTime키로 저장
        }

        recordText.text = "Best Time : " + (int)bestTime;   // 최고기록을 recordText 텍스트 컴포넌트를 이용해 표시
        }

}
