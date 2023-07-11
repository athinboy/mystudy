using System;
using System.Runtime.InteropServices;

namespace MyApp // Note: actual namespace depends on the project name.
{


    [StructLayout(LayoutKind.Sequential)]
    class SystemTime
    {
        public ushort Year;
        public ushort Month;
        public ushort DayOfWeek;
        public ushort Day;
        public ushort Hour;
        public ushort Minute;
        public ushort Second;
        public ushort Millisecond;
    }


    internal class MarshallPro
    {

        [DllImport("kernel32.dll")]
        static extern void GetSystemTime(SystemTime systemTime);

        static void Main(string[] args)
        {
            SystemTime st = new SystemTime();
            GetSystemTime(st);
            Console.WriteLine(st.Year);
        }
    }

}