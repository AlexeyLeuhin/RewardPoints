using CsvHelper;
using RewardPoints.Data.Models;
using RewardPoints.Shared;
using RewardPoints.Shared.Exceptions;
using System.Globalization;

namespace RewardPoints.Data;

public class CsvStorageContext : IStorageContext
{
    public IEnumerable<Customer> GetCustomers()
    {
        return GetEntitiesFromCsvFile<Customer>(Constants.CustomersFilePath);
    }

    public IEnumerable<Transaction> GetTransactions()
    {
        return GetEntitiesFromCsvFile<Transaction>(Constants.TransactionsFilePath);
    }

    private IEnumerable<T> GetEntitiesFromCsvFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new StorageFileNotFoundException(typeof(T));
        }

        using (var streamReader = new StreamReader(filePath))
        using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
        {
            return csvReader.GetRecords<T>().ToList();
        }
    }
}
