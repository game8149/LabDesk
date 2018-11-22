using System;

namespace Entity.Code.Base.Documentary
{
    public class EntityDocumentState : EntityDocument
    {
        public string AccountBegun { get; set; }
        public DateTime OnBegun { get; set; }
        public string AccountTerminated { get; set; }
        public DateTime OnTerminated { get; set; }

        public DocumentState State { get; set; }

        public enum DocumentState
        {
            Pending = 0,
            OnProcess = 1,
            Terminated = 2
        }
    }
}
