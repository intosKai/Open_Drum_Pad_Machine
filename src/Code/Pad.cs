using CSCore;
using CSCore.Codecs;
using CSCore.SoundOut;
using CSCore.Streams;
using System;
using System.Threading;
using System.Windows;
using enums;

namespace DrumPad_beta
{
    public class PadEventsArgs
    {
        
    }
    public class Pad
    {
        public string path { get; private set; }
        private IWaveSource soundSource;
        public ISoundOut soundOut;
        public IWaveStream soundStream;
        public VolumeSource soundVol;
        public bool IsInit { get; private set; }
        public PlayMode Mode { get; set; }
        public static int delay = 0;

        //public constructs
        public Pad() //Initialize empty object
        {
            IsInit = false;
        }
        public Pad(string path)
        {
            this.path = path;
            soundSource = GetSoundSource();
            soundOut = GetSoundOut();
            Mode = PlayMode.PlayAgain;

            soundSource = soundSource.AppendSource(x => new VolumeSource(soundSource), out soundVol).ToWaveSource();

            soundOut.Stopped += new EventHandler<PlaybackStoppedEventArgs>(this.AgainPad_Stopped);
            soundOut.Initialize(soundSource);

            
            IsInit = true;
        }

        //public
        public void Play()
        {
            if (IsInit)
            {
                if (soundOut.PlaybackState == PlaybackState.Playing)
                    soundOut.Stop();

                soundOut.Play();
            }
        }
        public void Stop()
        {
            if (IsInit)
            {
                soundOut.Stop();
            }
        }
        public void Dispose()
        {
            if (soundOut != null)
            {
                soundOut.Dispose();
                IsInit = false;
            }
        }
        public PlaybackState GetState()
        {
            if (soundOut != null)
                return soundOut.PlaybackState;
            else
                return PlaybackState.Paused;
        }
        public void SetVol(float volume)
        {

            if (IsInit)
            {
                soundVol.Volume = volume;
            }
        }
        public void SetMode(PlayMode Mode)
        {
            if(IsInit)
            {
                if (soundOut.PlaybackState == PlaybackState.Playing)
                    soundOut.Stop();
                switch(Mode)
                {
                    case PlayMode.Loop:
                        soundOut.Stopped -= new EventHandler<PlaybackStoppedEventArgs>(this.AgainPad_Stopped);
                        soundOut.Stopped += new EventHandler<PlaybackStoppedEventArgs>(this.LoopPad_Stopped);
                        this.Mode = PlayMode.Loop;
                        break;
                    case PlayMode.PlayAgain:
                        soundOut.Stopped += new EventHandler<PlaybackStoppedEventArgs>(this.AgainPad_Stopped);
                        soundOut.Stopped -= new EventHandler<PlaybackStoppedEventArgs>(this.LoopPad_Stopped);
                        this.Mode = PlayMode.PlayAgain;
                        break;
                }
            }
        }
        public void LoopStop()
        {
            if (IsInit && this.Mode == PlayMode.Loop)
            {
                if (soundOut.PlaybackState == PlaybackState.Playing)
                {
                    soundOut.Stopped -= new EventHandler<PlaybackStoppedEventArgs>(this.LoopPad_Stopped);
                    soundOut.Stop();
                    soundSource.SetPosition(new TimeSpan(0, 0, 0));
                    soundOut.Stopped += new EventHandler<PlaybackStoppedEventArgs>(this.LoopPad_Stopped);
                }
                else
                    soundOut.Play();
            }
        }

        //private:
        private void AgainPad_Stopped(object sender, EventArgs e)
        {
            soundSource.SetPosition(new TimeSpan(0, 0, 0));
        }
        private void LoopPad_Stopped(object sender, EventArgs e)
        {
            soundSource.SetPosition(new TimeSpan(0, 0, 0));
            Thread.Sleep(delay);
            soundOut.Play();
        }
        private ISoundOut GetSoundOut()
        {
            if (WasapiOut.IsSupportedOnCurrentPlatform)
                return new WasapiOut();
            else
                return new DirectSoundOut();
        }
        private IWaveSource GetSoundSource()
        {
            //return any source ... in this example, we'll just play a mp3 file
            return CodecFactory.Instance.GetCodec(path);
        }

    }
}