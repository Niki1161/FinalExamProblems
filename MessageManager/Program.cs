using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Read the maximum capacity of messages
        int capacity = int.Parse(Console.ReadLine());

        // Dictionary to store user data (username -> [sent, received])
        Dictionary<string, int[]> users = new Dictionary<string, int[]>();

        // Process commands until "Statistics" command is encountered
        while (true)
        {
            string command = Console.ReadLine();

            // Stop processing if the "Statistics" command is given
            if (command == "Statistics")
            {
                break;
            }

            // Process the "Add" command
            if (command.StartsWith("Add="))
            {
                string[] parts = command.Substring(4).Split('=');
                string username = parts[0];
                int sent = int.Parse(parts[1]);
                int received = int.Parse(parts[2]);

                if (!users.ContainsKey(username))
                {
                    users[username] = new int[] { sent, received };  // Add user
                }
            }
            // Process the "Message" command
            else if (command.StartsWith("Message="))
            {
                string[] parts = command.Substring(8).Split('=');
                string sender = parts[0];
                string receiver = parts[1];

                if (users.ContainsKey(sender) && users.ContainsKey(receiver))
                {
                    users[sender][0]++;  // Increase sender's sent count
                    users[receiver][1]++;  // Increase receiver's received count

                    // Check if sender reached capacity
                    if (users[sender][0] + users[sender][1] > capacity)
                    {
                        users.Remove(sender);
                        Console.WriteLine($"{sender} reached the capacity!");
                    }

                    // Check if receiver reached capacity
                    else if (users[receiver][0] + users[receiver][1] > capacity)
                    {
                        users.Remove(receiver);
                        Console.WriteLine($"{receiver} reached the capacity!");
                    }
                }
            }
            // Process the "Empty" command
            else if (command.StartsWith("Empty="))
            {
                string username = command.Substring(6);

                if (username == "All")
                {
                    users.Clear();  // Remove all users
                }
                else if (users.ContainsKey(username))
                {
                    users.Remove(username);  // Remove specific user
                }
            }
        }

        // Print the number of users and their total messages (sent + received)
        Console.WriteLine($"Users count: {users.Count}");
        foreach (var user in users)
        {
            int totalMessages = user.Value[0] + user.Value[1];
            Console.WriteLine($"{user.Key} - {totalMessages}");
        }
    }
}
