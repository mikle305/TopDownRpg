using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileStorage<T>: IStorage<T> where T: new()
{
    private readonly string _filePath;
    private readonly BinaryFormatter _formatter;

    public FileStorage(string savePath)
    {
        _filePath = Application.persistentDataPath + savePath;
        var directory = _filePath[.._filePath.LastIndexOf('/')];
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        
        _formatter = new BinaryFormatter();
    }

    public T Load()
    {
        if (!File.Exists(_filePath))
        {
            var defaultData = new T();
            Save(defaultData); 
            return defaultData;
        }
        
        using var file = File.Open(_filePath, FileMode.Open);
        return (T) _formatter.Deserialize(file);
    }

    public void Save(T data)
    {
        using var file = File.Create(_filePath);
        _formatter.Serialize(file, data);
    }
}