namespace MVC_Crud_NET_8.Models
{
        public class ErrorViewModel
        {
                public string? RequestId { get; set; }

                public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        }
}
