using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement; // Import SceneManager

public class TextCutsceneAnimator : MonoBehaviour
{
    public GameObject[] textObjects; // Array untuk elemen teks (Cerita Awal, Cerita Awal (1), dst.)
    public float displayTime = 2f; // Waktu tampilan untuk setiap teks
    public float fadeDuration = 0.5f; // Durasi fade in dan fade out
    public string nextSceneName; // Nama scene berikutnya

    private int currentTextIndex = 0;

    void Start()
    {
        // Pastikan semua teks disembunyikan di awal
        foreach (var textObj in textObjects)
        {
            textObj.SetActive(false);
        }
        
        // Mulai cutscene
        StartCoroutine(PlayTextCutscene());
    }

    IEnumerator PlayTextCutscene()
    {
        while (currentTextIndex < textObjects.Length)
        {
            GameObject currentText = textObjects[currentTextIndex];
            currentText.SetActive(true);

            // Fade in teks
            yield return StartCoroutine(FadeText(currentText, 0f, 1f, fadeDuration));

            // Tampilkan teks selama `displayTime`
            yield return new WaitForSeconds(displayTime);

            // Fade out teks
            yield return StartCoroutine(FadeText(currentText, 1f, 0f, fadeDuration));

            // Sembunyikan teks
            currentText.SetActive(false);

            // Lanjut ke teks berikutnya
            currentTextIndex++;
        }

        // Ganti scene setelah semua teks selesai
        ChangeScene();
    }

    IEnumerator FadeText(GameObject textObj, float startAlpha, float endAlpha, float duration)
    {
        CanvasGroup canvasGroup = textObj.GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            canvasGroup = textObj.AddComponent<CanvasGroup>();
        }

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            canvasGroup.alpha = alpha;
            yield return null;
        }

        canvasGroup.alpha = endAlpha;
    }

    void ChangeScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Nama scene berikutnya belum ditentukan!");
        }
    }
}
