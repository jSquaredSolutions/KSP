
using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Media; 

namespace KeyLogger {
public static class Program {
private const int WH_KEYBOARD_LL = 13;
private const int WM_KEYDOWN = 0x0100;
// private static string logFileName = "log.txt";
// private static StreamWriter logFile;
private static HookProc hookProc = HookCallback;
private static IntPtr hookId = IntPtr.Zero;
public static void Main()
{
  //  logFile = File.AppendText(logFileName);
  //  logFile.AutoFlush = true;
    hookId = SetHook(hookProc);
    Application.Run();
    UnhookWindowsHookEx(hookId);
}
private static IntPtr SetHook(HookProc hookProc)
{
    IntPtr moduleHandle = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);
    return SetWindowsHookEx(WH_KEYBOARD_LL, hookProc, moduleHandle, 0);
}
private delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
{
    if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
    {
       int vkCode = Marshal.ReadInt32(lParam);
                Console.WriteLine((Keys)vkCode+"   "+vkCode+"    "+lParam);
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                switch (vkCode)
                 {
                     case 65: // A Yaw left
                        myPlayer.SoundLocation = @"C:\Users\jsquared\Desktop\KSP\ConsoleApp1\SoundMedia\YawUp.wav";
                        myPlayer.Play();
                        break;
                    case 68: // D Yaw right
                        myPlayer.SoundLocation = @"C:\Users\jsquared\Desktop\KSP\ConsoleApp1\SoundMedia\YawRight.wav";
                        myPlayer.Play();
                        break;
                    case 83: // S PitchUp
                        myPlayer.SoundLocation = @"C:\Users\jsquared\Desktop\KSP\ConsoleApp1\SoundMedia\pitchUp.wav";
                        myPlayer.Play();
                        break;
                    case 87: // W PitchDown
                        myPlayer.SoundLocation = @"C:\Users\jsquared\Desktop\KSP\ConsoleApp1\SoundMedia\pitchDown.wav";
                        myPlayer.Play();
                        break;
                    case 160: // LeftShift Throddle up
                        myPlayer.SoundLocation = @"C:\Users\jsquared\Desktop\KSP\ConsoleApp1\SoundMedia\throttleUp.wav";
                        myPlayer.Play();
                        break;
                    case 162: // Leftcontrol Throddle down
                        myPlayer.SoundLocation = @"C:\Users\jsquared\Desktop\KSP\ConsoleApp1\SoundMedia\throttleDown.wav";
                        myPlayer.Play();
                        break;
                    case 77: // Map
                        myPlayer.SoundLocation = @"C:\Users\jsquared\Desktop\KSP\ConsoleApp1\SoundMedia\map.wav";
                        myPlayer.Play();
                        break;
                    case 20: // Precise Controls
                        myPlayer.SoundLocation = @"C:\Users\jsquared\Desktop\KSP\ConsoleApp1\SoundMedia\Pcontrol.wav";
                        myPlayer.Play();
                        break;
                    case 46: // Delete Part
                        myPlayer.SoundLocation = @"C:\Users\jsquared\Desktop\KSP\ConsoleApp1\SoundMedia\RemovePart.wav";
                        myPlayer.Play();
                        break;
                    case 88: // cut throt
                        myPlayer.SoundLocation = @"C:\Users\jsquared\Desktop\KSP\ConsoleApp1\SoundMedia\cutThrottle.wav";
                        myPlayer.Play();
                        break;

                }             
                    }
    return CallNextHookEx(hookId, nCode, wParam, lParam);
}
[DllImport("user32.dll")]
private static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);
[DllImport("user32.dll")]
private static extern bool UnhookWindowsHookEx(IntPtr hhk);
[DllImport("user32.dll")]
private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
[DllImport("kernel32.dll")]
private static extern IntPtr GetModuleHandle(string lpModuleName);
}
}
