using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Microsoft.AspNetCore.Mvc;

namespace MS.RabbitMQMessageApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMessage()
    {
        // RabbitMQ bağlantısı için bir connection factory oluşturulur
        var factory = new ConnectionFactory()
        {
            HostName = "localhost" // RabbitMQ sunucu adresi
        };

        // RabbitMQ sunucusuna asenkron bağlantı sağlanır
        var connection = await factory.CreateConnectionAsync();

        // Bağlantı üzerinden bir kanal (channel) oluşturulur
        var channel = await connection.CreateChannelAsync();

        // Kuyruk tanımlanır: ismi 'Kuyruk2', kalıcı değil (durable: false), sadece bu bağlantıya özel (exclusive: false), otomatik silinmeyen (autoDelete: false)
        await channel.QueueDeclareAsync("Kuyruk2", false, false, false, arguments: null);

        // Gönderilecek mesaj tanımlanır
        var message = "Merhaba bugün hava çok soğuk.";

        // Mesaj UTF8 formatında byte dizisine dönüştürülür
        var byteMessage = Encoding.UTF8.GetBytes(message);

        // Mesaj yayınlanır: exchange boş (default exchange), routingKey olarak kuyruk adı kullanılır
        await channel.BasicPublishAsync(exchange: "", routingKey: "Kuyruk2", body: byteMessage);

        // Başarılı işlem sonrası kullanıcıya bilgi dönülür
        return Ok("Mesajınız kuyruğa alınmıştır.");
    }

    [HttpGet]
    public async Task<IActionResult> ReadMessage()
    {
        // RabbitMQ bağlantısı için bir connection factory oluşturulur
        var factory = new ConnectionFactory();

        factory.HostName = "localhost"; // RabbitMQ sunucu adresi

        // RabbitMQ sunucusuna asenkron bağlantı sağlanır
        var connection = await factory.CreateConnectionAsync();

        // Bağlantı üzerinden bir kanal (channel) oluşturulur
        var channel = await connection.CreateChannelAsync();

        // Asenkron mesaj tüketici (consumer) tanımlanır
        var consumer = new AsyncEventingBasicConsumer(channel);

        // Gelen mesajı dışarı aktarmak için TaskCompletionSource kullanır
        var tcs = new TaskCompletionSource<string>();

        // Mesaj geldiğinde çalışacak event tanımlanır
        consumer.ReceivedAsync += async (model, x) =>
        {
            // Mesajın içeriği byte dizisi olarak gelir, string'e çevirilir
            var byteMessage = x.Body.ToArray();
            var message = Encoding.UTF8.GetString(byteMessage);

            // TaskCompletionSource ile mesajı dışarı aktarılır
            tcs.SetResult(message);

            // RabbitMQ'ya mesajı başarıyla alındığı bildirilir (ack)
            await channel.BasicAckAsync(x.DeliveryTag, multiple: false);

            // Event handler asenkron olduğundan tamamlandığını bildirilir
            await Task.CompletedTask;
        };

        // Kuyruktaki mesajları tüketmeye başlanır (autoAck: false — elle ack verilir)
        await channel.BasicConsumeAsync(queue: "Kuyruk2", autoAck: false, consumer: consumer);

        // Mesaj gelene kadar beklenir, geldikten sonra devam edilir
        string receivedMessage = await tcs.Task;

        // Mesajı HTTP 200 OK olarak döndürülür
        if (string.IsNullOrEmpty(receivedMessage))
        {
            return NotFound("Kuyrukta mesaj bulunmamaktadır.");
        }
        else
        {
            return Ok(receivedMessage);
        }
    }
}
