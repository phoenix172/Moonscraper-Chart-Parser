using System;
using System.Linq;
using MoonscraperChartEditor.Song;
using MoonscraperChartEditor.Song.IO;
using Newtonsoft.Json;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SongMidi_ParsedSuccessfully()
        {
            var a = MidReader.CallbackState.None;
            var song = MidReader.ReadMidi("TestData\\notes.mid", ref a);
            var chart = song.GetChart(Song.Instrument.Drums, Song.Difficulty.Hard);

            var notes = chart.notes.Select(x => (x.time, x.drumPad.ToString()));
            var json = JsonConvert.SerializeObject(notes, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
            Console.WriteLine(json);

            Assert.IsNotEmpty(notes);
        }

        [Test]
        public void SongChart_ParsedSuccessfully()
        {
            var song = ChartReader.ReadChart("TestData\\notes.chart");
            var chart = song.GetChart(Song.Instrument.Guitar, Song.Difficulty.Expert);

            var notes = chart.notes.Select(x => (x.time, x.guitarFret.ToString()));
            var json = JsonConvert.SerializeObject(notes, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            });
            Console.WriteLine(json);

            Assert.IsNotEmpty(notes);
        }
    }
}