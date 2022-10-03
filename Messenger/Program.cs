using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            List<IMessageSender> senders = new List <IMessageSender>()
            {
                new EmailSender(), new SmsSender(), new MSMQSender(), new WebServiceSender()
            };

            Message message = new SystemMessage();
            message.Subject = "System message";
            message.Body = "This is text of a system message\n";
            
            foreach(IMessageSender sender in senders)
            {
                message.MessageSender = sender;
                message.Send();
            }
            program.SenderSelect();
            Console.ReadKey();
        }

        public void SenderSelect()
        {
            UserMessage userMessage = new UserMessage();
            Console.WriteLine("Write subject of a message:");
            userMessage.Subject = Console.ReadLine();
            Console.WriteLine("Write body of a message:");
            userMessage.Body = Console.ReadLine();
            Console.WriteLine("Choose type of platform to send message:\n1.Email\n2.SMS\nAny key - do not send");
            int selection= Convert.ToInt32(Console.ReadLine()); 
            switch (selection)
            {
                case 1:
                    userMessage.MessageSender = new EmailSender();
                    userMessage.Send();
                    Console.WriteLine("The message was sent succesfully. Press any key to exit.");
                    break;
                case 2:
                    userMessage.MessageSender = new SmsSender();
                    userMessage.Send();
                    Console.WriteLine("The message was sent succesfully. Press any key to exit.");
                    break;
                default:
                    Console.WriteLine("The message was not sent.");
                    break;
            }
        }
    }
}
