using System;

namespace EntityLab.Code.Base
{
    public class EntityDocumentState : EntityDocument
    {
        public int IdAccountBegun { get; set; }
        public DateTime DateBegun { get; set; }
        public int  IdAccountTerminated { get; set; }
        public DateTime DateTerminated { get; set; }

        public DocumentState State { get; set; }

        public enum DocumentState
        {
            Pending,
            OnProcess,
            Terminated
        }
    }
}
