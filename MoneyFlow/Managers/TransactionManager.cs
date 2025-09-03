using MoneyFlow.Context;
using MoneyFlow.DTOs;
using MoneyFlow.Entities;

namespace MoneyFlow.Managers
{
    public class TransactionManager(AppDbContext _dbContext)
    {
        public int New(TransactionDTO modelDto)
        {
            var entity = new Transaction
            {
                Date = modelDto.Date,
                TotalAmount = modelDto.TotalAmount,
                Comment = modelDto.Comment,
                ServiceId = modelDto.ServiceId,
                UserId = modelDto.UserId,
            };

            _dbContext.Transactions.Add(entity);
            var affected_rows = _dbContext.SaveChanges();
            return affected_rows;
        }

        public List<HistorialDTO> GetHistorial(DateOnly startDate, DateOnly EndDate, int UserId)
        {
            var list = _dbContext.Transactions
                .Where (item => 
                    item.UserId == UserId &&
                    item.Date >= startDate && item.Date <= EndDate
                ).Select(item => new HistorialDTO {
                    Date = item.Date.ToString("dd/MM/yy"),
                    Month = item.Date.ToString("MMMM"),
                    TypeService = item.Service.Type,
                    Service = item.Service.Name,
                    TotalAmount = item.TotalAmount.ToString(),
                }).ToList();

            return list;
        }

    }
}
