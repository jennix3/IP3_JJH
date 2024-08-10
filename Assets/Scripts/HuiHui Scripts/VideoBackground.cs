/*
 * Author: Looi Hui Hui
 * Date: 10/08/2024
 * Description: Manages the playback of a video background using the VideoPlayer component.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Manages the playback of a video background using the VideoPlayer component.
/// </summary>
public class VideoBackground : MonoBehaviour
{
    /// <summary>
    /// Reference to the VideoPlayer component.
    /// </summary>
    public VideoPlayer videoPlayer;

    /// <summary>
    /// Starts playing the video if the VideoPlayer is assigned.
    /// </summary>
    void Start()
    {
        if (videoPlayer != null)
        {
            videoPlayer.Play();
        }
    }
}
