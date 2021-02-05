using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace TestDiscordBot.Modules
{
    public class Comands : ModuleBase<SocketCommandContext>
    {
        private const long ObludnykID = 195273938337660928;
        private const long MyID = 387309508822827009;

        [Command("хтозайшов")]
        public async Task Who()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=NUkfXWOCcV8");
        }
        
        [Command("інфа")]
        public async Task Info(SocketGuildUser user = null)
        {
            if (user == null)
            {
                var builder = new EmbedBuilder()
                    .WithThumbnailUrl(Context.User.GetAvatarUrl() ?? Context.User.GetDefaultAvatarUrl())
                    .WithDescription("Інфа сотка")
                    .WithColor(new Color(33, 176, 252))
                    .AddField("ID акауну", Context.User.Id,true)
                    .AddField("Акаунт створено", Context.User.CreatedAt.ToString("dd/MM/yyyy"),true)
                    .AddField("Зайшов на сервер", (Context.User as SocketGuildUser).JoinedAt.Value.ToString("dd/MM/yyyy"),true)
                    .WithCurrentTimestamp();
                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
            else
            {
                var builder = new EmbedBuilder()
                   .WithThumbnailUrl(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl())
                   .WithDescription("Інфа сотка")
                   .WithColor(new Color(33, 176, 252))
                   .AddField("ID акауну", user.Id,true)
                   .AddField("Акаунт створено", user.CreatedAt.ToString("dd/MM/yyyy"),true)
                   .AddField("Зайшов на сервер", user.JoinedAt.Value.ToString("dd/MM/yyyy"),true)
                   .WithCurrentTimestamp();
                var embed = builder.Build();
                await Context.Channel.SendMessageAsync(null, false, embed);
            }
        }

        [Command("автор")]
        public async Task Author()
        {
            await Context.Channel.SendFileAsync(@"D:\Programs\TestDiscordBot\Content\author.jpg", "Найкраща людина в світі @bushmek");
            
        }

        [Command("лох")]
        public async Task Loh(SocketGuildUser user = null)
        {
            if (user == null)
            {
                if (Context.User.Id == MyID)
                    await Context.Channel.SendMessageAsync("Ти норм тіп " + Context.User.Mention, false, null, null);
                else
                    await Context.Channel.SendMessageAsync("Але ти лошара " + Context.User.Mention, false, null, null);
            }
            else
                await Context.Channel.SendMessageAsync("Їбалай не треба нікого відмічати " + Context.User.Mention, false, null, null);
        }

        [Command("бібаметр")]
        public async Task BibaMetr()
        {
            if (Context.User.Id == ObludnykID)
            {
                await Context.Channel.SendMessageAsync(Context.User.Mention + " ти гуль яка біба?");
            }
            else
            {
                Random rand = new Random();
                int result = rand.Next(31);
                await Context.Channel.SendMessageAsync(Context.User.Mention + " в тебе біба " + result + " cм");
            }
        }

        [Command("похуй")]
        public async Task Pofig()
        {
            await Context.Channel.SendFileAsync(@"D:\Programs\TestDiscordBot\Content\pofig.jpg");
        }

        [Command("команди")]
        public async Task AllCommands()
        {
                await ReplyAsync("Список команд бота:\n\n"
                        +"?хтозайшов\n"
                        + "?інфа\n"
                        + "?лох\n"
                        + "?бібаметр\n"
                        + "?похуй\n"
                        + "?автор");
        }


    }
}
