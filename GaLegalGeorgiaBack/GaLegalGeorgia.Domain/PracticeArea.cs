using GaLegalGeorgia.Domain.Common;

namespace GaLegalGeorgia.Domain
{
    public class PracticeArea : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; }

        public string TitleEn { get; set; }
        public string ContentEn { get; set; }
    }


}
