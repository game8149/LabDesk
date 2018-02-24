using System;

namespace EntityLab.Code.Base
{
    public class EntityDocumentCheck : EntityDocument
    {
        public CheckType Type { get; set; }
        public int IdUserCheck { get; set; }
        public DateTime DateCheck { get; set; }

        public enum CheckType
        {
            Pending,
            Aprobed,
            Denied
        }


    }
}
