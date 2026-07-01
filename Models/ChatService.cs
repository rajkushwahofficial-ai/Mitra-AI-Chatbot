using ChatBotProject.Models;

namespace ChatBotProject.Services;

public class ChatService
{
    public ChatResponse GetReply(ChatRequest request)
    {
        string msg = request.Message.ToLower();

        string reply;

        if (msg.Contains("hello") || msg.Contains("hi"))
        {
            reply = "Hello 👋 How are you?";
        }
        else if (msg.Contains("name"))
        {
            reply = "My name is C# AI ChatBot.";
        }
        else if (msg.Contains("time"))
        {
            reply = DateTime.Now.ToString("hh:mm tt");
        }
        else if (msg.Contains("date"))
        {
            reply = DateTime.Now.ToShortDateString();
        }
        else if (msg.Contains("bye"))
        {
            reply = "Good Bye 👋";
        }
        else
        {
            reply = "Sorry, I don't understand.";
        }

        return new ChatResponse
        {
            Reply = reply
        };
    }
}