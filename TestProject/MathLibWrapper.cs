using System.Runtime.InteropServices;

namespace TestProject;

public class MathLibraryWrapper
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ErrStatus
    {
        public byte Success;
        public uint Error;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string ErrorMsg;
    }

    [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr createMathLibrary(int size, ref ErrStatus opResult);

    [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void freeMathLibrary(IntPtr lib);

    [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte putData_MathLib(IntPtr lib, int parameter, ref ErrStatus opResult);

    [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte processData_MathLib(IntPtr lib, ref ErrStatus opResult);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ResultCallback(int result);

    [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte addResultCallback_MathLib(IntPtr lib, ResultCallback callback, ref ErrStatus opResult);

    [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte removeResultCallback_MathLib(IntPtr lib, ref ErrStatus opResult);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void ErrorCallback(ErrStatus errStatus);

    [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte addErrorCallback_MathLib(IntPtr lib, ErrorCallback callback, ref ErrStatus opResult);

    [DllImport("MathLibrary.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern byte removeErrorCallback_MathLib(IntPtr lib, ref ErrStatus opResult);
}