using WsBills.Models;

namespace WSBills.Interfaces
{
    public interface IBillService
    {
        Bill GetBill(int id);
        void AddBill(string name, string description, decimal amount, DateTime dueDate);
        void DeleteBill(int id);
        void UpdateBill(int id, string name, string description, decimal amount, DateTime dueDate);
        List<Bill> GetBills();
    }
}
