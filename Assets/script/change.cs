using System.Collections;
using UnityEngine;

public class change : MonoBehaviour
{
    [Header("玩家对象")]
    public GameObject player1;
    public GameObject player2;

    [Header("切换音效")]
    public AudioClip switchSFX;
    public AudioSource audioSource;

    private void Start()
    {
        var playerInput1 = player1.GetComponent<PlayerController>();
        var playerInput2 = player2.GetComponent<playercontroller2>();
        playerInput1.enabled = true;
        playerInput2.enabled = false;

        // 如果没拖 AudioSource，就自动添加
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var playerInput1 = player1.GetComponent<PlayerController>();
            var playerInput2 = player2.GetComponent<playercontroller2>();

            playerInput1.enabled = !playerInput1.enabled;
            playerInput2.enabled = !playerInput2.enabled;

            PlaySwitchSound();
        }
    }

    void PlaySwitchSound()
    {
        if (switchSFX != null && audioSource != null)
        {
            audioSource.PlayOneShot(switchSFX);
        }
    }
}
