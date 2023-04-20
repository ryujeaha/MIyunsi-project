
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BlackOut : MonoBehaviour
{
    //�бⰡ �Ѿ�� ������.
    public int sceneIndex;
    public string sceneName;

    public float duration; //�����Ǵ� �ð�����

    public Image coverImage; //����ȿ���� �� �̹���

    public bool isSceneStart = false;
    public GameObject UI;
    private void Start()
    {
        coverImage.gameObject.SetActive(true);

        //���� ����ɶ�.
        if (isSceneStart)
        {
            //�ڷ�ƾ ����
            StartCoroutine(SceneBlackOutProcess());
        }
    }

    /*private void Update
    {
        //���� �������� ����.
        if (Input.GetKeyDown(KeyCode.C) && isSceneStart == false)
        {
            //�ڷ�ƾ ����
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
                //����� ���İ��� 0���� ����.
                alphaCount = t / duration;
            }
            else
            {
                //����� ���� ���� 1���� �����ؼ� ���� ���� ��
                alphaCount = 1 - (t / duration);
            }

            coverImage.color = new Color(0, 0, 0, alphaCount);

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();

        //�ŷε�
        if (isSceneStart == false)
        {
            //�ŷε�
            SceneManager.LoadScene(sceneIndex);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            //������ ������� ���������� ������Ʈ�� ����
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
