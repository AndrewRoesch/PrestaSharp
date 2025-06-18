using Bukimedia.PrestaSharp.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Factories
{
    public class OrderHistoryFactory : GenericFactory<order_history>
    {
        protected override string singularEntityName { get { return "order_history"; } }
        protected override string pluralEntityName { get { return "order_histories"; } }

        public OrderHistoryFactory(string BaseUrl, string Account, string SecretKey)
            : base(BaseUrl, Account, SecretKey)
        {
           
        }

        public new order_history Add(order_history Entity)
        {
            long? idAux = Entity.id;
            Entity.id = null;
            List<PrestaSharp.Entities.PrestaShopEntity> Entities = new
            List<PrestaSharp.Entities.PrestaShopEntity>();
            Entities.Add(Entity);
            RestRequest request = this.RequestForAdd($"{pluralEntityName}&sendemail=1", Entities);
            request.AddParameter("sendemail", 1);
            order_history aux = this.Execute<order_history>(request);
            Entity.id = idAux;
            if (aux == null)
            {
                return null;

            }
            else
            {

                return this.Get((long)aux.id);
            }
        }
    } 
}