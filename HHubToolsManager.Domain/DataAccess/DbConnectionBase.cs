using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HZ.HHub.Data;
using NLog;

namespace HHubToolsManager.Domain.DataAccess
{
    public class DbConnectionBase
    {
        private static ILogger logger;

        public static Database GetGatewayOrderDB()
        {
            logger = LogManager.GetCurrentClassLogger();
            try
            {
                Database db = DatabaseFactory.CreateDatabase("CentralGateway");
                return db;

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }


        }
    }
}
