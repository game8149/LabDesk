using System;

namespace Entity.Code.Base.Documentary
{
    public class EntityDocumentCheck : EntityDocument
    {
        public CheckType Type { get; set; }
        public string AccountCheck { get; set; }
        public DateTime OnCheck { get; set; }

        public enum CheckType
        {
            Pending,
            Aprobed,
            Denied
        }


    }
}
