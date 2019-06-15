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
    public interface IMenuGroupService
    {
        MenuGroup Add(MenuGroup menu);
        void Update(MenuGroup menu);
        MenuGroup Delete(int id);
        MenuGroup Delete(MenuGroup menu);
        IEnumerable<MenuGroup> GetAll(string[] includes = null);
        MenuGroup GetById(int id);
        void Save();
    }
    public class MenuGroupService : IMenuGroupService
    {
        private IUnitOfWork unitOfWork;
        private IMenuGroupRepository menuGroupRepository;
        public MenuGroupService(IUnitOfWork unitOfWork, IMenuGroupRepository menuGroupRepository)
        {
            this.unitOfWork = unitOfWork;
            this.menuGroupRepository = menuGroupRepository;
        }
        public MenuGroup Add(MenuGroup menu)
        {
            return menuGroupRepository.Add(menu);
        }

        public MenuGroup Delete(int id)
        {
            return menuGroupRepository.Delete(id);
        }

        public MenuGroup Delete(MenuGroup menu)
        {
            return menuGroupRepository.Delete(menu);
        }

        public IEnumerable<MenuGroup> GetAll(string[] includes = null)
        {
            return menuGroupRepository.GetAll(includes);
        }

        public MenuGroup GetById(int id)
        {
            return menuGroupRepository.GetById(id);
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public void Update(MenuGroup menu)
        {
            menuGroupRepository.Update(menu);
        }
    }
}
