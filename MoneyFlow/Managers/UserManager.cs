using MoneyFlow.Context;
using MoneyFlow.Entities;
using MoneyFlow.Models;
using MoneyFlow.Utilities;
using System.Runtime.Intrinsics.Arm;

namespace MoneyFlow.Managers
{
    public class UserManager(AppDbContext _dbContext)
    {
        public UserVM Login(LoginVM viewModel) 
        {
            var found = _dbContext.Users.Where( item =>
                item.Email == viewModel.Email &&
                item.Password == Sha256Hasher.ComputeHash(viewModel.Password)
                ).FirstOrDefault();

        var user = new UserVM();

        if (found != null)
            {
                user.UserId = found.UserId;
                user.FullName = found.FullName;
                user.Email = found.Email;
            }

            return user;
         
        }

        public int Register(UserVM viewModel)
        {
            if (viewModel.Password != viewModel.RepeatPassword)
                throw new InvalidOperationException("The passwords are not the same");

            var foundEmail = _dbContext.Users.Any(i => i.Email == viewModel.Email);
            if (foundEmail)
                throw new InvalidOperationException("Ya estas registrado");

            var entity = new User
            {
                Email = viewModel.Email,
                Password = Sha256Hasher.ComputeHash(viewModel.Password),
                FullName = viewModel.FullName
            };

            _dbContext.Users.Add(entity);
            var affected_rows = _dbContext.SaveChanges();

            return affected_rows;
        }
    }
}
