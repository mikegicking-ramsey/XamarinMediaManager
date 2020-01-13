﻿using System;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Media;
using Android.Support.V4.Media.Session;

namespace MediaManager.Platforms.Android.MediaSession
{
    public class MediaSessionCallback : MediaSessionCompat.Callback
    {
        protected MediaManagerImplementation MediaManager = CrossMediaManager.Android;

        public MediaSessionCallback()
        {
        }

        protected MediaSessionCallback(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public Action<MediaDescriptionCompat> OnAddQueueItemImpl { get; set; }
        public Action<MediaDescriptionCompat, int> OnAddQueueItemAtIndexImpl { get; set; }
        public Action OnFastForwardImpl { get; set; }
        public Func<Intent, bool> OnMediaButtonEventImpl { get; set; }
        public Action OnPauseImpl { get; private set; }
        public Action OnPlayImpl { get; private set; }
        public Action<string, Bundle> OnPlayFromMediaIdImpl { get; private set; }
        public Action<string, Bundle> OnPlayFromSearchImpl { get; private set; }
        public Action<global::Android.Net.Uri, Bundle> OnPlayFromUriImpl { get; private set; }
        public Action OnPrepareImpl { get; private set; }
        public Action<string, Bundle> OnPrepareFromMediaIdImpl { get; private set; }
        public Action<string, Bundle> OnPrepareFromSearchImpl { get; private set; }
        public Action<global::Android.Net.Uri, Bundle> OnPrepareFromUriImpl { get; private set; }
        public Action<MediaDescriptionCompat> OnRemoveQueueItemImpl { get; private set; }
        public Action<int> OnRemoveQueueItemAtImpl { get; private set; }
        public Action OnRewindImpl { get; private set; }
        public Action OnSeekToImpl { get; private set; }
        public Action OnSetCaptioningEnabledImpl { get; private set; }
        public Action<RatingCompat> OnSetRatingImpl { get; private set; }
        public Action<RatingCompat, Bundle> OnSetRatingWithExtrasImpl { get; private set; }
        public Action OnSetRepeatModeImpl { get; private set; }
        public Action OnSetShuffleModeImpl { get; private set; }
        public Action OnSkipToNextImpl { get; private set; }
        public Action OnSkipToPreviousImpl { get; private set; }
        public Action OnSkipToQueueItemImpl { get; private set; }
        public Action OnStopImpl { get; private set; }

        public override void OnAddQueueItem(MediaDescriptionCompat description)
        {
            OnAddQueueItemImpl?.Invoke(description);
        }

        public override void OnAddQueueItem(MediaDescriptionCompat description, int index)
        {
            OnAddQueueItemAtIndexImpl?.Invoke(description, index);
        }

        public override void OnFastForward()
        {
            if (MediaManager.BluetoothControls.SeekForwardImpl != null)
            {
                MediaManager.BluetoothControls.SeekForwardImpl.Invoke();
            }
            else if (MediaManager.BluetoothControls.SkipForwardImpl != null)
            {
                MediaManager.BluetoothControls.SkipBackwardImpl.Invoke();
            }
            else
            {
                OnFastForwardImpl?.Invoke();
            }
        }

        public override void OnRewind()
        {
            if (MediaManager.BluetoothControls.SeekBackwardImpl != null)
            {
                MediaManager.BluetoothControls.SeekBackwardImpl.Invoke();
            }
            else if (MediaManager.BluetoothControls.SkipBackwardImpl != null)
            {
                MediaManager.BluetoothControls.SkipBackwardImpl.Invoke();
            }
            else
            {
                OnRewindImpl?.Invoke();
            }
        }

        public override bool OnMediaButtonEvent(Intent mediaButtonEvent)
        {
            return OnMediaButtonEventImpl?.Invoke(mediaButtonEvent) ?? false;
        }

        public override void OnPause()
        {
            if (MediaManager.BluetoothControls.PauseImpl != null)
            {
                MediaManager.BluetoothControls.PauseImpl.Invoke();
            }
            else
            {
                OnPauseImpl?.Invoke();
            }
        }

        public override void OnPlay()
        {
            if (MediaManager.BluetoothControls.PlayImpl != null)
            {
                MediaManager.BluetoothControls.PlayImpl.Invoke();
            }
            else
            {
                OnPlayImpl?.Invoke();
            }
        }

        public override void OnPlayFromMediaId(string mediaId, Bundle extras)
        {
            OnPlayFromMediaIdImpl?.Invoke(mediaId, extras);
        }

        public override void OnPlayFromSearch(string query, Bundle extras)
        {
            OnPlayFromSearchImpl?.Invoke(query, extras);
        }

        public override void OnPlayFromUri(global::Android.Net.Uri uri, Bundle extras)
        {
            OnPlayFromUriImpl?.Invoke(uri, extras);
        }

        public override void OnPrepare()
        {
            OnPrepareImpl?.Invoke();
        }

        public override void OnPrepareFromMediaId(string mediaId, Bundle extras)
        {
            OnPrepareFromMediaIdImpl?.Invoke(mediaId, extras);
        }

        public override void OnPrepareFromSearch(string query, Bundle extras)
        {
            OnPrepareFromSearchImpl?.Invoke(query, extras);
        }

        public override void OnPrepareFromUri(global::Android.Net.Uri uri, Bundle extras)
        {
            OnPrepareFromUriImpl?.Invoke(uri, extras);
        }

        public override void OnRemoveQueueItem(MediaDescriptionCompat description)
        {
            OnRemoveQueueItemImpl?.Invoke(description);
        }

        public override void OnRemoveQueueItemAt(int index)
        {
            OnRemoveQueueItemAtImpl?.Invoke(index);
        }

        public override void OnSeekTo(long pos)
        {
            OnSeekToImpl?.Invoke();
        }

        public override void OnSetCaptioningEnabled(bool enabled)
        {
            OnSetCaptioningEnabledImpl?.Invoke();
        }

        public override void OnSetRating(RatingCompat rating)
        {
            OnSetRatingImpl?.Invoke(rating);
        }

        public override void OnSetRating(RatingCompat rating, Bundle extras)
        {
            OnSetRatingWithExtrasImpl?.Invoke(rating, extras);
        }

        public override void OnSetRepeatMode(int repeatMode)
        {
            OnSetRepeatModeImpl?.Invoke();
        }

        public override void OnSetShuffleMode(int shuffleMode)
        {
            OnSetShuffleModeImpl?.Invoke();
        }

        public override void OnSkipToNext()
        {
            if (MediaManager.BluetoothControls.NextImpl != null)
            {
                MediaManager.BluetoothControls.NextImpl.Invoke();
            }
            else
            {
                OnSkipToNextImpl?.Invoke();
            }
        }

        public override void OnSkipToPrevious()
        {
            if (MediaManager.BluetoothControls.PreviousImpl != null)
            {
                MediaManager.BluetoothControls.PreviousImpl.Invoke();
            }
            else
            {
                OnSkipToPreviousImpl?.Invoke();
            }
        }

        public override void OnSkipToQueueItem(long id)
        {
            OnSkipToQueueItemImpl?.Invoke();
        }

        public override void OnStop()
        {
            if (MediaManager.BluetoothControls.StopImpl != null)
            {
                MediaManager.BluetoothControls.StopImpl.Invoke();
            }
            else
            {
                OnStopImpl?.Invoke();
            }
        }
    }
}
