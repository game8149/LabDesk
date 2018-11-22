using Entity.Code.Base.Documentary;
using System;
using System.Collections.Generic;

namespace Entity.Code.Analisis
{
    public class PriceList : EntityDocumentAble
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public IEnumerable<PriceListDetail> Items { get; set; }
        public DateTime OpenDay { get; set; }
        public DateTime CloseDay { get; set; }
    }
}
