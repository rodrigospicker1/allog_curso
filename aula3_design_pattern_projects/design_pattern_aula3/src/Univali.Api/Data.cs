using Univali.Api.Controllers;

namespace Univali.Api
{
    public class Data
    {
        private List<Customer> Customer {get; set;}

        private static Data? _instance;

        public static Data Instance
        {
            get
            {
                if(_instance == null){
                    _instance = new Data();
                }
                return _instance;
            }
        }
    }
}