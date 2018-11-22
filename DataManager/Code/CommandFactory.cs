using Entity.Code.Interfaces;
using Entity.Code.Management;

namespace DataManager.Code
{
    public class CommandFactory
    {
        IEntityRepository<Account, int> repo;
        public CommandFactory()
        {
            
        }

    }
}
