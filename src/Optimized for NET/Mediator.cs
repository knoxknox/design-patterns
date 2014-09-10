using System;
using System.Collections.Generic;

namespace DoFactory.GangOfFour.Mediator.NETOptimized
{
    /// <summary>
    /// MainApp startup class for .NET optimized 
    /// Mediator Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Create chatroom participants
            Participant George = new Beatle { Name = "George" };
            Participant Paul = new Beatle { Name = "Paul" };
            Participant Ringo = new Beatle { Name = "Ringo" };
            Participant John = new Beatle { Name = "John" };
            Participant Yoko = new NonBeatle { Name = "Yoko" };

            // Create chatroom and register participants
            Chatroom chatroom = new Chatroom();
            chatroom.Register(George);
            chatroom.Register(Paul);
            chatroom.Register(Ringo);
            chatroom.Register(John);
            chatroom.Register(Yoko);

            // Chatting participants
            Yoko.Send("John", "Hi John!");
            Paul.Send("Ringo", "All you need is love");
            Ringo.Send("George", "My sweet Lord");
            Paul.Send("John", "Can't buy me love");
            John.Send("Yoko", "My sweet love");

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Mediator' interface
    /// </summary>
    interface IChatroom
    {
        void Register(Participant participant);
        void Send(string from, string to, string message);
    }

    /// <summary>
    /// The 'ConcreteMediator' class
    /// </summary>
    class Chatroom : IChatroom
    {
        private Dictionary<string, Participant> _participants =
            new Dictionary<string, Participant>();

        public void Register(Participant participant)
        {
            if (!_participants.ContainsKey(participant.Name))
            {
                _participants.Add(participant.Name, participant);
            }

            participant.Chatroom = this;
        }

        public void Send(string from, string to, string message)
        {
            Participant participant = _participants[to];
            if (participant != null)
            {
                participant.Receive(from, message);
            }
        }
    }

    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    class Participant
    {
        // Gets or sets participant name
        public string Name { get; set; }

        // Gets or sets chatroom
        public Chatroom Chatroom { get; set; }

        // Send a message to given participant
        public void Send(string to, string message)
        {
            Chatroom.Send(Name, to, message);
        }

        // Receive message from participant
        public virtual void Receive(
            string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'",
                from, Name, message);
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    class Beatle : Participant
    {
        public override void Receive(string from, string message)
        {
            Console.Write("To a Beatle: ");
            base.Receive(from, message);
        }
    }

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    class NonBeatle : Participant
    {
        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beatle: ");
            base.Receive(from, message);
        }
    }
}
