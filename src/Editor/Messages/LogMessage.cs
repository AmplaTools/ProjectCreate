
namespace AmplaTools.ProjectCreate.Editor.Messages
{
    public class LogMessage : IMessage
    {
         public LogMessage(string message)
         {
             Message = message;
         }

         public string Message { get; private set; }
    }
}