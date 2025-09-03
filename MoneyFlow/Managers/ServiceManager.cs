using Microsoft.EntityFrameworkCore;
using MoneyFlow.Context;
using MoneyFlow.Models;
using MoneyFlow.Models.Entities;

namespace MoneyFlow.Managers
{
    public class ServiceManager(AppDbContext _dbContext)
    {
        public List<ServiceVM> GetAll(int userId)
        {
            var list = _dbContext.Services
            .Where(item => item.UserId == userId)
            .Select(item => new ServiceVM
            {
                ServiceId = item.ServiceId,
                UserId = item.UserId,
                Name = item.Name,
                Type = item.Type,

            })
            .ToList();

            return list;
        }

        public int New(ServiceVM viewModel)
        {
            var entity = new Service
            {
                Name = viewModel.Name,
                Type = viewModel.Type,
                UserId = viewModel.UserId,
            };

            _dbContext.Services.Add(entity);
            var affected_rows = _dbContext.SaveChanges();

            return affected_rows;
        }

        public ServiceVM GetById(int Id)
        {
            var entity = _dbContext.Services.Find(Id);

            var model = new ServiceVM
            {
                ServiceId = Id,
                Name = entity.Name,
                Type = entity.Type,
            };

            return model;
        }

        public int Edit(ServiceVM model)
        {
            var entity = _dbContext.Services.Find(model.ServiceId);

            entity.Name = model.Name;
            entity.Type = model.Type;

            _dbContext.Services.Update (entity);
            var affected_rows = _dbContext.SaveChanges();
            return affected_rows;
        }

        public int Delete(int id) 
        {
            var entity = _dbContext.Services.Find(id);

            if (entity != null)
            _dbContext.Services.Remove(entity);
            var affected_rows = _dbContext.SaveChanges();
            
            return affected_rows;
        }

        public List<ServiceVM> GetByType(int userId, string type) 
        {
             var list = _dbContext.Services
                .Where(item =>
                item.UserId == userId &&
                item.Type == type)
                .Select(item => new ServiceVM
                {
                    UserId = item.UserId,
                    ServiceId = item.ServiceId,
                    Name = item.Name,
                    Type = item.Type,

                }).ToList();

            return list;

        }

    }
}
