using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Data.Linq.Mapping;

namespace ProductDetailsContracts
{
    [Table (Name="Products")]
    [DataContract]
    public class Product
    {
        [Column]
        [DataMember]
        public int ProductID { get; set; }
        
        [Column]
        [DataMember]
        public string ProductName { get; set; }

        [Column]
        [DataMember]
        public int? SupplierID { get; set; }

        [Column]
        [DataMember]
        public int? CategoryID { get; set; }

        [Column]
        [DataMember]
        public string QuantityPerUnit { get; set; }

        [Column]
        [DataMember]
        public decimal? UnitPrice { get; set; }

        [Column]
        [DataMember]
        public short? UnitsInStock { get; set; }

        [Column]
        [DataMember]
        public short? UnitsOnOrder { get; set; }

        [Column]
        [DataMember]
        public short? ReorderLevel { get; set; }

        [Column]
        [DataMember]
        public bool Discontinued { get; set; }
    }
}
