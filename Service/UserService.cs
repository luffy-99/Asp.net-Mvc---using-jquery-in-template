using Data.Infrastructủe;
using Data.Repositories;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        User Add(User user);
        void Update(User user);
        User Delete(int id);
        User Delete(User user);
        bool GetUser(string userName, string passWord);
        User GetUserById(int id);
        IEnumerable<User> GetAll(string[] includes = null);
        void Save();
    }
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IUnitOfWork unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
        public User Add(User user)
        {
            return userRepository.Add(user);
        }

        public User Delete(int id)
        {
            return userRepository.Delete(id);
        }

        public User Delete(User user)
        {
            return userRepository.Delete(user);
        }

        public IEnumerable<User> GetAll(string[] includes = null)
        {
            return userRepository.GetAll();
        }

        public bool GetUser(string userName, string passWord)
        {
            return userRepository.GetUser(userName, passWord);
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }
    }
}
