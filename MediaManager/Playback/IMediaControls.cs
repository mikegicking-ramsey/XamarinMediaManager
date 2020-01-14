using System;

namespace MediaManager.Playback
{
    public interface IMediaControls
    {
        /// <summary>
        /// If null, default action is to step backwards by MediaManager.StepSize (default 15 seconds)
        /// </summary>
        Action SkipBackwardImpl { get; set; }

        /// <summary>
        /// If null, default action is to step forwards by MediaManager.StepSize (default 15 seconds)
        /// </summary>
        Action SkipForwardImpl { get; set; }

        /// <summary>
        /// If null, default action is to step backwards by MediaManager.StepSize (default 15 seconds)
        /// </summary>
        Action SeekBackwardImpl { get; set; }

        /// <summary>
        /// If null, default action is to step forwards by MediaManager.StepSize (default 15 seconds)
        /// </summary>
        Action SeekForwardImpl { get; set; }

        /// <summary>
        /// If null, default action is to stop playback
        /// </summary>
        Action StopImpl { get; set; }

        /// <summary>
        /// If null, default action is to pause playback
        /// </summary>
        Action PauseImpl { get; set; }

        /// <summary>
        /// If null, default action is to resume or start playback
        /// </summary>
        Action PlayImpl { get; set; }

        /// <summary>
        /// If null, default action is to toggle play/pause
        /// </summary>
        Action PlayPauseImpl { get; set; }

        /// <summary>
        /// If null, default action is to start playback of the previous media item in the queue
        /// </summary>
        Action PreviousImpl { get; set; }

        /// <summary>
        /// If null, default action is to start playback of the next media item in the queue
        /// </summary>
        Action NextImpl { get; set; }

        /// <summary>
        /// If null, default action is to toggle the shuffle flag
        /// </summary>
        Action ShuffleImpl { get; set; }

        /// <summary>
        /// If null, default action is to toggle the repeat flag
        /// </summary>
        Action RepeatImpl { get; set; }

        /// <summary>
        /// Overrides the OnMediaButtonEvent Handler for Android. For iOS, please use the other fields in this class.
        /// <para>
        /// intent: The Android.Content.Intent of the MediaButtonEvent
        /// </para>
        /// </summary>
        /// <remarks>
        /// The OnMediaButtonEvent does not exist for iOS.
        /// </remarks>
        Func<object, bool> MediaButtonEventImpl { get; set; }
    }
}
