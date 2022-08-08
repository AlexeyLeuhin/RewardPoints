using RewardPoints.Data.Models;

namespace RewardPoints.Data;

public interface IStorageContext
{
    public IEnumerable<Customer> GetCustomers();

    public IEnumerable<Transaction> GetTransactions();
}
