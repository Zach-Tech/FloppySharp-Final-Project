using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyChilders_Final_Project_CPT_185_FloppySharp.Modules
{

    public class Commands : ModuleBase<SocketCommandContext>
    {
        Dictionary<string, string> HelpCommand = new Dictionary<string, string>()
        {
            {"\n**Ping**", "Returns Pong\n"}, {"\n**Help**", "Returns This command\n"}, 
            {"\n**Add**", "Adds together two numbers\n"}
        };

       
        private readonly CommandService _service;

        public Commands(CommandService service)
        {
            _service = service;
        }
  


        //Basic first command, I say "Ping", bot replies "Pong"
        //Generally, all commands must be activated by a prefix,
        //Unless the bot utilizes listeners and kwargs.
        [Command("Ping")]
        public async Task Ping() { await ReplyAsync("pong"); }

        [Command("Help"),
            Alias("h",
            "help"), Summary("A helping hand in your darkest hour")]
        public async Task HelpAsync()
        {
            await Context.Channel.SendMessageAsync("Check Your Messages");

            var dmChannel = await Context.User.GetOrCreateDMChannelAsync();

            var embed = new EmbedBuilder
            {
                // Embed property can be set within object initializer
                Title = "Hello world!",
                Description = HelpCommand.Values
            };


            //none of this shit works and im actually mad about it
            // will find a new method for a help command

            await dmChannel.SendMessageAsync()

        }

        private object Embed(EmbedBuilder embed)
        {
            throw new NotImplementedException();
        }
    }
}
