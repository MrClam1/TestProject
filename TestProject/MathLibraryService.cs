namespace TestProject;

public class MathLibraryService: IDisposable
{
    private IntPtr _library;

    public MathLibraryService(int sizeArray)
    {
        MathLibraryWrapper.ErrStatus err = new();
        
        _library = MathLibraryWrapper.createMathLibrary(sizeArray, ref err);
        PrintError(err);

        MathLibraryWrapper.addResultCallback_MathLib(_library, PrintResult, ref err);
        PrintError(err);
        
        MathLibraryWrapper.addErrorCallback_MathLib(_library, PrintError, ref err);
        PrintError(err);
    }

    ~MathLibraryService()
    {
        Dispose(false);
    }

    public void PutArray(List<int> arr)
    {
        MathLibraryWrapper.ErrStatus err = new();
        foreach (var value in arr)
        {
            MathLibraryWrapper.putData_MathLib(_library, value, ref err);
            PrintError(err);
        }
    }

    public void Process()
    {
        MathLibraryWrapper.ErrStatus err = new();
        MathLibraryWrapper.processData_MathLib(_library, ref err);
        PrintError(err);
    }
    
    public void Dispose()
    {
        Dispose(true);
    }
    
    private void Dispose(bool disposing)
    {
        if (_library == IntPtr.Zero)
            return;
        
        if (disposing)
        {
            // Освобождение управляемых ресурсов
        }
        
        // Освобождение неуправляемых ресурсов
        MathLibraryWrapper.ErrStatus err = new();
        MathLibraryWrapper.removeResultCallback_MathLib(_library, ref err);
        PrintError(err);
        
        MathLibraryWrapper.removeErrorCallback_MathLib(_library, ref err);
        PrintError(err);
        
        MathLibraryWrapper.freeMathLibrary(_library);
        _library = IntPtr.Zero;
        
        Console.WriteLine("Destructor called for MathLibraryService!");
    }

    private void PrintResult(int res)
    {
        Console.WriteLine($"[Result] [{res}]");
    }

    private void PrintError(MathLibraryWrapper.ErrStatus errStatus)
    {
        if (errStatus.Success != 1)
        {
            Console.WriteLine($"[Error] [{errStatus.Error}] [{errStatus.ErrorMsg}]");
        }
    }
}