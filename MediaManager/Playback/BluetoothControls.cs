using System;
namespace MediaManager.Playback
{
    public class BluetoothControls : IBluetoothControls
    {
        private IMediaManager _mediaManager = CrossMediaManager.Current;

        public BluetoothControls()
        {
        }

        #region Command Overrides

        public Action SkipBackwardImpl { get; set; }

        public Action SkipForwardImpl { get; set; }

        public Action SeekBackwardImpl { get; set; }

        public Action SeekForwardImpl { get; set; }

        public Action StopImpl { get; set; }

        public Action PauseImpl { get; set; }

        public Action PlayImpl { get; set; }

        public Action PlayPauseImpl { get; set; }

        public Action PreviousImpl { get; set; }

        public Action NextImpl { get; set; }

        public Action ShuffleImpl { get; set; }

        public Action RepeatImpl { get; set; }

        #endregion

        #region Baked-In Overrides

        public bool SeekInsteadOfSkip
        {
            get
            {
                return SeekInsteadOfSkip;
            }
            set
            {
                if (value)
                {
                    PreviousImpl = new Action(() =>
                    {
                        _mediaManager.StepBackward();
                    });
                    NextImpl = new Action(() =>
                    {
                        _mediaManager.StepForward();
                    });
                }
                else
                {
                    PreviousImpl = null;
                    NextImpl = null;
                }
            }
        }

        #endregion
    }
}
