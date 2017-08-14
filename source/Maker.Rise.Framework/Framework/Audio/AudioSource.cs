using OpenTK.Audio.OpenAL;

namespace Maker.Rise.Framework.Audio
{
    public sealed class AudioSource
    {
        public int Handle { get; private set; }

        public AudioSource(AudioBuffer sound)
        {
            Handle = AL.GenSource();
            Debugger.WriteLog($"created on handle {Handle}.", LogType.Message, nameof(AudioSource));
            AL.Source(Handle, ALSourcei.Buffer, sound.Handle);
        }

        public void Play() { AL.SourceRewind(Handle); AL.SourcePlay(Handle);}
        public void Pause() { AL.SourcePause(Handle); }
        public void Stop() { AL.SourceStop(Handle); }

        public void SetVolume(float volume) { AL.Source(Handle, ALSourcef.Gain, volume); }
        public void SetPitch(float pitch) { AL.Source(Handle, ALSourcef.Pitch, pitch); }
        public void SetLooping(bool Enable) { AL.Source(Handle, ALSourceb.Looping, Enable); }

        public bool IsPlaying()
        {
            var state = AL.GetSourceState(Handle);
            return state == ALSourceState.Playing;
        }

        public void Destroy()
        {
            AL.DeleteSource(Handle);
        }
    }
}
