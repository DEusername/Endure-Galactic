using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openingFades : MonoBehaviour
{
    public Animator animator;

    public musicBoxMaster musicBox;

    private bool openingExcerptOver = false;

    void Start()
    {
        StartCoroutine(SriTextFadeInCoro(2));
        StartCoroutine(SriSourceFadeInCoro(8));
        StartCoroutine(SriTextFadeOutCoro(17));
        StartCoroutine(FadeInCoro(22));
    }

    IEnumerator SriTextFadeInCoro(int timerLength)
    {
        yield return new WaitForSeconds(timerLength);
        animator.SetTrigger("SrillinTextFadeIn");
    }

    IEnumerator SriSourceFadeInCoro(int timerLength)
    {
        yield return new WaitForSeconds(timerLength);
        animator.SetTrigger("SrillinSourceFadeIn");
    }

    IEnumerator SriTextFadeOutCoro(int timerLength)
    {
        yield return new WaitForSeconds(timerLength);
        animator.SetTrigger("SrillinTextFadeOut");
        animator.SetTrigger("SrillinSourceFadeOut");
    }

    IEnumerator FadeInCoro(int timerLength)
    {
        yield return new WaitForSeconds(timerLength);
        animator.SetTrigger("SceneFadeIn");
        musicBox.PlayMusicTrack3();
        StartCoroutine(SetOpenExcerptOverTrue(6));
    }

    IEnumerator SetOpenExcerptOverTrue(int timerLength)
    {
        yield return new WaitForSeconds(timerLength);
        openingExcerptOver = true;
    }

    public bool GetOpeningExcerptOver()
    {
        return openingExcerptOver;
    }
}
