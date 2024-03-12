using GaLegalGeorgia.Domain.Common;

namespace GaLegalGeorgia.Domain
{
    public class ConsultationRequest : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    
        public string MessageStatus { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }

      
    }
}
