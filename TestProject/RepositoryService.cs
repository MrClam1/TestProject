namespace TestProject;

public class RepositoryService: IDisposable
{
    public void SaveData(List<int> arr)
    {
        // Выполнение сохранение данных на сервер
    }

    ~RepositoryService()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Освобождение управляемых ресурсов
        }
        
        // Освобождение неуправляемых ресурсов
        
        Console.WriteLine("Destructor called for RepositoryService!");
    }
}