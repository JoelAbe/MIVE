using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VideoURLInput : MonoBehaviour
{
    [SerializeField] private VideoDownloader videoDownloader;
    [SerializeField] private TMP_InputField inputField;

    public void OnSubmitButtonClicked()
    {
        string videoURL = inputField.text;
        videoDownloader.DownloadAndPlayVideo(videoURL);
    }
}
