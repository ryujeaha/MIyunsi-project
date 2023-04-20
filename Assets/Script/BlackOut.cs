
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackOut : MonoBehaviour
{
    //분기가 넘어갈때 정해줌.
    public int sceneIndex;
    public string sceneName;

    public float duration; //암전되는 시간길이

    public Image coverImage; //암전효과를 낼 이미지

    public bool isSceneStart = false;
    public GameObject UI;
    private void Start()
    {
        coverImage.gameObject.SetActive(true);

        //씬이 실행될때.
        if (isSceneStart)
        {
            //코루틴 실행
            StartCoroutine(SceneBlackOutProcess());
        }
    }

    /*private void Update
    {
        //씬이 끝났을때 실행.
        if (Input.GetKeyDown(KeyCode.C) && isSceneStart == false)
        {
            //코루틴 실행
            StartCoroutine(SceneBlackOutProcess());
        }
    }
    */
    IEnumerator SceneBlackOutProcess()
    {
        coverImage.gameObject.SetActive(true);

        float t = 0.0f;
        float alphaCount = 0.0f;
        while (t <= duration)
        {
            t += Time.deltaTime;
            if (isSceneStart == false)
            {
                //여기는 알파값이 0에서 시작.
                alphaCount = t / duration;
            }
            else
            {
                //여기는 알파 값을 1부터 시작해서 계산된 값은 뺌
                alphaCount = 1 - (t / duration);
            }

            coverImage.color = new Color(0, 0, 0, alphaCount);

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();

        //신로드
        if (isSceneStart == false)
        {
            //신로드
            SceneManager.LoadScene(sceneIndex);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            //서서히 밝아지고 투명해지면 오브젝트를 숨김
            coverImage.gameObject.SetActive(false);
        }

        isSceneStart = !isSceneStart;
    }
    public void OnCLick()
    {
        StartCoroutine(SceneBlackOutProcess());
        UI.SetActive(false);
    }
}
