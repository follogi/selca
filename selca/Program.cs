using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace selca
{
    class Program
    {
        private const int WM_SETTEXT = 0x000c;

        private const int WM_KEYDOWN = 0x0100;

        static void Main(string[] args)
        {
            var process = Process.GetProcesses().Where(p => p.MainWindowTitle.StartsWith("DOSBox 0.74-3")).FirstOrDefault();
            if (process == null) process = Process.Start("C:\\Program Files (x86)\\DOSBox-0.74-3\\DOSBox.exe", "-c \"mount c c:\\temp\\selca\\exe\" -c \"c:\"");

            Thread.Sleep(5000);

            NativeMethods.SetForegroundWindow(process.MainWindowHandle);
            Thread.Sleep(1000);

            var simulator = new InputSimulator();

            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_A);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_S);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_E);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_L);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_C);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_O);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_N);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_V);
            simulator.Keyboard.KeyPress(VirtualKeyCode.OEM_PERIOD);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_E);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_X);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_E);
            simulator.Keyboard.Sleep(1000);
            simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            simulator.Keyboard.Sleep(1000);

            simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            simulator.Keyboard.Sleep(1000);

            simulator.Keyboard.KeyPress(VirtualKeyCode.F2);
            simulator.Keyboard.Sleep(1000);

            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_N);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_P);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_D);
            simulator.Keyboard.Sleep(1000);
            simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            simulator.Keyboard.Sleep(1000);

            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_N);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_P);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_D);
            simulator.Keyboard.KeyPress(VirtualKeyCode.VK_2);
            simulator.Keyboard.Sleep(1000);
            simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            simulator.Keyboard.Sleep(1000);

            simulator.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            simulator.Keyboard.Sleep(10000);

            simulator.Keyboard.KeyPress(VirtualKeyCode.ESCAPE);

            Console.WriteLine("Press any Key to terminate the application.");
            Console.ReadKey(true);
        }
    }

    internal static class NativeMethods
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, Keys wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
