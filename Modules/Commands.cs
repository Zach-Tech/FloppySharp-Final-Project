using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyChilders_Final_Project_CPT_185_FloppySharp.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        //Basic first command, I say "Ping", bot replies "Pong"
        //Generally, all commands must be activated by a prefix,
        //Unless the bot utilizes listeners and kwargs.
        [Command("Ping")]
        public async Task Ping() { await ReplyAsync("pong"); }




    }
}
