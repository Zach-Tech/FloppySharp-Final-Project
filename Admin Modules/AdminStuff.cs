using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyChilders_Final_Project_CPT_185_FloppySharp.Admin_Modules
{
    [Name("Admin Commands")]
    [RequireContext(ContextType.Guild)]
    [RequireUserPermission(GuildPermission.ManageRoles)]
    public class AdminStuff : ModuleBase<SocketCommandContext>
    {
        [Command("say"), Summary("Bot will repeat argument -> ")]
        public async Task  Say([Remainder,Summary("User's words repeated by Floppy")] string say)
        {
            await ReplyAsync(say);
            await Context.Message.DeleteAsync();
        }

    }
}
