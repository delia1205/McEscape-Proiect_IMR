using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class KeypadController : MonoBehaviour
{
    public GameObject ronald;
    public List<Light> roomLights = new List<Light>();
    public AudioSource ronaldLaugh;
    public GameObject doors;
    private Animator doorAnimator;
    public AudioSource doorSound;
    public AudioSource backgroundMusic;

    public Camera MainCamera;

    public List<int> correctPassword = new List<int>();
    private List<int> inputPasswordList = new List<int>();
    [SerializeField] private TMP_InputField codeDisplay;
    [SerializeField] private float resetTime = 2f;
    [SerializeField] private string successText;
    [Space(5f)]
    [Header("Keypad Entry Events")]
    public UnityEvent onCorrectPassword;
    public UnityEvent onIncorrectPassword;

    public bool allowMultipleActivations = false;
    private bool hasUsedCorrectCode = false;
    public bool HasUsedCorrectCode {  get { return hasUsedCorrectCode; } }

    public void UserNumberEntry(int selectedNum)
    {
        if(inputPasswordList.Count >= 4)
        {
            return;
        }

        inputPasswordList.Add(selectedNum);

        UpdateDisplay();

        if(inputPasswordList.Count >= 4)
        {
            CheckPassword();
        }
    }

    private void CheckPassword()
    {
        for(int i=0; i<correctPassword.Count; i++)
        {
            if(inputPasswordList[i] != correctPassword[i])
            {
                IncorrectPassword();
                return;
            }
        }
        CorrectPasswordGiven();
    }

    private void CorrectPasswordGiven()
    {
        if(!allowMultipleActivations && !hasUsedCorrectCode)
        {
            onCorrectPassword.Invoke();
            hasUsedCorrectCode = true;
            codeDisplay.text = successText;

            MainCamera.GetComponent<ExitGame>().hasEnteredCorrectCode = true;
            ronald.GetComponent<BehindCamera>().hasEnteredCorrectCode = true;

            ronald.GetComponent<RonaldLookAt>().setNewPosition(6.19f, 8.49f, -8.49f);
            ronald.GetComponent<RonaldLookAt>().turnOnLight();

            StartCoroutine(FadeAudioSource.StartFade(backgroundMusic, 2, 0));

            for (int i=0; i<roomLights.Count; i++)
            {
                roomLights[i].intensity = 0.01f;
                if(i == 0 || i == 4)
                {
                    roomLights[i].GetComponent<LightFlickerEffect>().enabled = false;
                }
            }
            ronaldLaugh.Play();
            Wait(5f);

            doorAnimator = doors.GetComponent<Animator>();
            doorAnimator.SetBool("isOpened", true);
            doorSound.Play();
        }
    }

    private void IncorrectPassword()
    {
        onIncorrectPassword.Invoke();
        StartCoroutine(ResetKeycode());
    }

    private void UpdateDisplay()
    {
        codeDisplay.text = null;
        for(int i=0; i<inputPasswordList.Count; i++)
        {
            codeDisplay.text += inputPasswordList[i];
        }
    }

    public void DeleteEntry()
    {
        if(inputPasswordList.Count <= 0)
        {
            return;
        }

        var listPosition = inputPasswordList.Count - 1;
        inputPasswordList.RemoveAt(listPosition);

        UpdateDisplay();
    }

    IEnumerator ResetKeycode()
    {
        yield return new WaitForSeconds(resetTime);

        inputPasswordList.Clear();
        codeDisplay.text = "Enter code...";
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}

public static class FadeAudioSource
{
    public static IEnumerator StartFade(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
