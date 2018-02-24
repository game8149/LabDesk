using EntityLab.Code.Base;
using System;
using System.Collections.Generic;

namespace EntityLab.Code.Hospital.Analisis.Pricing
{
    public class PackagePriceList : EntityDocumentAble
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public IEnumerable<PackagePriceListDetailed> Prices { get; set; }
        public DateTime OpenDay { get; set; }
        public DateTime CloseDay { get; set; }
    }
}
