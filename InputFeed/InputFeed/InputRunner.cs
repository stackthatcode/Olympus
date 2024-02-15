using System;
using NAudio.Wave;
using NAudio.CoreAudioApi;

public class InputRunner
{
    private readonly string _outputFilePath;
    public InputRunner()
    {
        _outputFilePath = @"C:\temp\AudioTest\recordedAudio.wav";
    }


    public void Execute()
    {
        Console.WriteLine("Press any key to start recording...");
        Console.ReadKey();

        using (var waveIn = new WaveInEvent())
        {
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new WaveFormat(44100, 1); // CD quality audio

            using (var writer = new WaveFileWriter(_outputFilePath, waveIn.WaveFormat))
            {
                waveIn.DataAvailable += (sender, e) =>
                {
                    writer.Write(e.Buffer, 0, e.BytesRecorded);
                    writer.Flush();
                };

                waveIn.StartRecording();
                Console.WriteLine("Recording... Press any key to stop.");
                Console.ReadKey();

                waveIn.StopRecording();
            }
        }

        Console.WriteLine($"Recording stopped and saved to {_outputFilePath}");
    }
}

