namespace TestProject;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("Main Program started!");
        
        Example10();
        
        Console.WriteLine("Main Program finished!");
    }
    
    private static void Example1()
    {
        long totalMemory = GC.GetTotalMemory(false);
        Console.WriteLine($"Total Memory: {totalMemory} bytes");
        
        var obj = new ExampleObject("Obj1");
        
        int gen_before = GC.GetGeneration(obj);
        
        Console.WriteLine($"Generation for obj: {gen_before}");
        
        GC.Collect();
        
        int gen_after = GC.GetGeneration(obj);
        
        Console.WriteLine($"Generation for obj: {gen_after}");
    }

    private static void Example2()
    {
        Init(); // Инициализация объектов
        ForceGc(); // Принудительный вызов сборщика мусора

        return;

        void Init()
        {
            var exampleObject1 = new ExampleObject("Obj1");
            var exampleObject2 = new ExampleObject("Obj2");
        }
    }

    private static void Example3()
    {
        Init();
        ForceGc();

        return;

        void Init()
        {
            List<ExampleObject> list = new();

            if (list == null!)
                return;

            for (var i = 0; i < 5; i++)
            {
                list.Add(new ExampleObject($"Name{i}"));
            }
        }
    }

    private static void Example4()
    {
        Init();
        ForceGc();

        return;

        void Init()
        {
            var data = new List<int>();

            using (var service = new RepositoryService())
            {
                service.SaveData(data);
            }
        }
    }

    private static void Example5()
    {
        const int size = 10;

        using var service = new MathLibraryService(size);

        var list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        
        service.PutArray(list);
        service.Process();
    }
    
    private static void Example6()
    {
        const int size = 10;

        using var service = new MathLibraryService(size);

        var list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        
        service.PutArray(list);
        service.Process();
    }
    
    private static void Example7()
    {
        const int size = 5;

        using var service = new MathLibraryService(size);

        var list = new List<int> { 0, 1, 2, 3, 4 };
        
        service.PutArray(list);
        service.Process();
        
        service.Dispose();
        
        service.Process();
    }

    private static void Example8()
    {
        unsafe
        {
            var obj = new ExampleObject("Name");
            ExampleObject* x = &obj;
            
            Console.WriteLine($"Obj Name: {obj.Name}");
            
            x->SetName("NewName");
            
            Console.WriteLine($"Obj Name: {obj.Name}");
        }
    }

    private static void Example9()
    {
        unsafe
        {
            int* arr = stackalloc int[5];

            for (int i = 0; i < 5; i++)
            {
                arr[i] = i;
            }
            
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Arr value[{i}]: {arr[i]}");
            }
        }
    }

    private static void Example10()
    {
        int[] arr = new[] { 0, 1, 2, 3, 4 };
        
        unsafe
        {
            fixed (int* pArr = arr)
            {
                pArr[2] = 10;
                pArr[4] = 1;
                
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Arr value[{i}]: {pArr[i]}");
                }
            }
        }
    }

    private static void ForceGc()
    {
        GC.Collect(); // Запуск сборщика мусора
        GC.WaitForPendingFinalizers(); // Освобождение памяти
    }
}

