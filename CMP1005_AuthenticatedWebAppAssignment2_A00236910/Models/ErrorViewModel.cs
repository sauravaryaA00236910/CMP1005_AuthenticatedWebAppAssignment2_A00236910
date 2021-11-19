using System;

namespace CMP1005_AuthenticatedWebAppAssignment2_A00236910.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
