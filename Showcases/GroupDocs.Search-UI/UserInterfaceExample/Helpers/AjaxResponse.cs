namespace UserInterfaceExample.Helpers
{
    public class AjaxResponse
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public object Content { get; set; }

        protected AjaxResponse(bool status, string message, object content)
        {
            Status = status;
            Message = message;
            Content = content;
        }

        public static AjaxResponse Successful(string message, object content)
        {
            var response = new AjaxResponse(true, message, content);
            return response;
        }

        public static AjaxResponse Failed(string message, object content)
        {
            var response = new AjaxResponse(false, message, content);
            return response;

        }
    }
}