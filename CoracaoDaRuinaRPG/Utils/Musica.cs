namespace CoracaoDaRuinaRPG;
using NAudio.Wave;

public static class Musica
{
    private static AudioFileReader _reader;
    private static WaveOutEvent _output;
    private static bool _loop;

    public static void Tocar(string caminho, float volume = 0.5f, bool loop = false)
    {
        Parar();

        _loop = loop;

        _reader = new AudioFileReader(caminho)
        {
            Volume = volume
        };

        _output = new WaveOutEvent();
        _output.Init(_reader);

        _output.PlaybackStopped += OnPlaybackStopped;

        _output.Play();
    }

    private static void OnPlaybackStopped(object sender, StoppedEventArgs e)
    {
        if (_loop && _reader != null && _output != null)
        {
            _reader.Position = 0;
            _output.Play();
        }
    }

    public static void Parar()
    {
        _loop = false;

        _output?.Stop();
        _output?.Dispose();
        _reader?.Dispose();
    }
}

