using System.Reflection;
using NAudio.Midi;

namespace MoonscraperChartEditor.Song.IO
{
    public static class Workaround
    {
        static FieldInfo field = typeof(SysexEvent).GetField("data",
            BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic);

        public static byte[] GetData(this SysexEvent e) => (byte[]) field.GetValue(e);
    }
}