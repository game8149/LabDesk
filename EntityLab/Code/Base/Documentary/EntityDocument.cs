using System;

namespace Entity.Code.Base.Documentary
{
    public class EntityDocument
    {
        public string AccountInsert { get; set; }
        public string AccountModify { get; set; }
        public DateTime OnInsert { get; set; }
        public DateTime OnUpdate { get; set; }

    }
}
