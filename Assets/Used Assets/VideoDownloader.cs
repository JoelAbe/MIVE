using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

public class VideoDownloader : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;

    public void DownloadAndPlayVideo(string videoURL)
    {
        StartCoroutine(DownloadVideo(videoURL));
    }

    private IEnumerator DownloadVideo(string videoURL)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(videoURL))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to download video: " + webRequest.error);
                yield break;
            }

            // Save the downloaded video to a temporary file
            string tempPath = Application.persistentDataPath + "/tempVideo.mp4";
            System.IO.File.WriteAllBytes(tempPath, webRequest.downloadHandler.data);

            // Load and play the video from the temporary file
            videoPlayer.url = tempPath;
            videoPlayer.Play();
        }
    }
}
