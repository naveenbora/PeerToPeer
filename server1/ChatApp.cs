namespace server1
{
    public class ChatApp
    {
        public void Start()
        {
            User user = new User();
            user.Name = "Naveen";
            user.IpAddress = "127.0.0.1";
            user.Port = 3333;
            Network network = new Network(user);

            Conversation conversation = new Conversation(user, network.EstablishConnection());
            conversation.StartChatting();
        }
    }


}