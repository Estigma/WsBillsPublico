using WSBills.Data;
using WsBills.Models;
using WSBills.Interfaces;

namespace WSBills.Implementations
{
    public class BillService : IBillService
    {
        AppDbContext _context;

        public BillService(AppDbContext context)
        {
            _context = context;
        }


        public void AddBill(string name, string description, decimal amount, DateTime dueDate)
        {
            Bill bill = new Bill
            {
                Name = name,
                Description = description,
                Amount = amount,
                DueDate = dueDate
            };

            _context.Bills.Add(bill);
            _context.SaveChanges();
        }

        public void DeleteBill(int id)
        {
            Bill contacto = _context.Bills.Find(id);
            if (contacto != null)
            {
                _context.Bills.Remove(contacto);
                _context.SaveChanges();
            }
        }

        public Bill GetBill(int id)
        {
            var contact = _context.Bills.Find(id);
            
            return contact;
        }


        public List<Bill> GetBills()
        {
            var contacts = _context.Bills.ToList();
            return contacts;
        }

        public void UpdateBill(int id, string name, string description, decimal amount, DateTime dueDate)
        {
            Bill bill = _context.Bills.Find(id);
            if (bill != null)
            {
                bill.Name = name;
                bill.Description = description;
                bill.Amount = amount;
                bill.DueDate = dueDate;
                _context.SaveChanges();
            }
        }
    }
}
