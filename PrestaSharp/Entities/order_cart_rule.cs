using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bukimedia.PrestaSharp.Lib;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class order_cart_rule : PrestaShopEntity, IPrestaShopFactoryEntity
    {
        public long? id { get; set; }
        public long? id_order { get; set; }
        public long? id_customer { get; set; }
        public long? id_cart_rule { get; set; }
        public long? id_order_invoice { get; set; }
        public List<Entities.AuxEntities.language> name { get; set; }
        public string code { get; set; }
        public decimal value { get; set; }
        public decimal value_tax_excl { get; set; }
        public int free_shipping { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_from { get; set; }
        /// <summary>
        /// It´s a logical DateTime. Format YYYY-MM-DD HH:MM:SS.
        /// </summary>
        public string date_to { get; set; }
        public decimal? reduction_amount { get; set; }
        public decimal? reduction_percent { get; set; }
        /// <summary>
        /// It´s a logical bool.
        /// </summary>
        public int active { get; set; }
        public int quantity { get; set; }
        public int quantity_per_user { get; set; }

        public order_cart_rule()
        {
            this.name = new List<AuxEntities.language>();
        }

        public void AddName(Entities.AuxEntities.language Language)
        {
            Language.Value = Functions.GetPrestaShopName(Language.Value);
            lock (this.name)
            {
                this.name.Add(Language);
            }
        }
    }
}