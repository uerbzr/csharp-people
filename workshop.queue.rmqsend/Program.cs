using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(queue: "person", durable: false, exclusive: false, autoDelete: false,
    arguments: null);

bool running = true;
while (running)
{

    Console.WriteLine(" Enter message / q to exit.");
    string message = Console.ReadLine()!;
    if (message == "q")
    {
        running = false;
        break;
    }
    var body = Encoding.UTF8.GetBytes(message);

    await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);
    Console.WriteLine($" [x] Sent {message}");

}
//Console.ReadLine();