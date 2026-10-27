using UnityEngine;

public class ExitGameUI : MonoBehaviour
{
    [Header("退出确认UI面板")]
    public GameObject exitPanel;

    private bool isShowing = false;

    void Start()
    {
        if (exitPanel != null)
            exitPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleExitUI();
        }
    }

    void ToggleExitUI()
    {
        isShowing = !isShowing;

        if (exitPanel != null)
            exitPanel.SetActive(isShowing);

        // 暂停/恢复游戏
        Time.timeScale = isShowing ? 0f : 1f;

        // 🎵 同步控制背景音乐
        if (BGMManager.Instance != null)
        {
            if (isShowing)
                BGMManager.Instance.GetComponent<AudioSource>().Pause();
            else
                BGMManager.Instance.GetComponent<AudioSource>().UnPause();
        }
    }

    // 绑定给“是”按钮
    public void OnClickYes()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // 绑定给“否”按钮
    public void OnClickNo()
    {
        isShowing = false;

        if (exitPanel != null)
            exitPanel.SetActive(false);

        Time.timeScale = 1f;

        // 🎵 恢复音乐
        if (BGMManager.Instance != null)
            BGMManager.Instance.GetComponent<AudioSource>().UnPause();
    }

    public void OnClickLoadMenu()
    {
        Time.timeScale = 1f;

        if (BGMManager.Instance != null)
            BGMManager.Instance.GetComponent<AudioSource>().UnPause();

        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
