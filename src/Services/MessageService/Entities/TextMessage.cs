namespace MessageService.Entities;

public class TextMessage : MessageBase
{
    public string TextContent { get; set; }
    public ICollection<Attachment> Attachments { get; set; } = [];

    public TextMessage(string textContent, int senderId, int receiverId)
    {
        TextContent = textContent;
        SenderId = senderId;
        ReceiverId = receiverId;
    }

    private TextMessage()
    {
        
    }
}