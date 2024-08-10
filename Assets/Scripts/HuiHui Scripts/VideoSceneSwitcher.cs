/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Manages video playback and switches to a new scene when the video finishes.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

/// <summary>
/// Manages video playback and switches to a new scene when the video finishes.
/// </summary>
public class VideoSceneSwitcher : MonoBehaviour
{
    /// <summary>
    /// The VideoPlayer component used to play the video.
    /// </summary>
    public VideoPlayer videoPlayer;

    /// <summary>
    /// Initializes the VideoPlayer and subscribes to the loop point reached event.
    /// </summary>
    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Subscribe to the event that triggers when the video finishes
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    /// <summary>
    /// Called when the video finishes playing; switches to the specified scene.
    /// </summary>
    /// <param name="vp">The VideoPlayer that finished playing.</param>
    void OnVideoFinished(VideoPlayer vp)
    {
        // Load the scene with the build index of 2
        SceneManager.LoadScene(2);
    }
}
