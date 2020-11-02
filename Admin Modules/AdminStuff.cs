using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public async Task Say([Remainder, Summary("User's words repeated by Floppy")] string say)
        {
            await ReplyAsync(say);
            await Context.Message.DeleteAsync();
        }
        //gotta have a purge command when dealing with bots
        //testing functions will quickly fill up a channel
        //gotta clear it afterwards
        [Command("purge", RunMode = RunMode.Async)]
        [Remarks("Purges messages (int) amount from guild channel")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Clear(int amountOfMessagesToDelete)
        {
            await (Context.Message.Channel as SocketTextChannel).DeleteMessagesAsync(await Context.Message.Channel.GetMessagesAsync(amountOfMessagesToDelete + 1).FlattenAsync());
            await Context.Message.DeleteAsync();
        }

        [Command("purge")]
        [Remarks("Purges A User's Last Messages. Default Amount To Purge Is 100")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Clear(SocketGuildUser user, int amountOfMessagesToDelete = 100)
        {
            if (user == Context.User)
                amountOfMessagesToDelete++; //Because it will count the purge command as a message

            var messages = await Context.Message.Channel.GetMessagesAsync(amountOfMessagesToDelete).FlattenAsync();

            var result = messages.Where(x => x.Author.Id == user.Id && x.CreatedAt >= DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(14)));

            await (Context.Message.Channel as SocketTextChannel).DeleteMessagesAsync(result);

        }
        //This will set the bot's "Playing" status
        [Command("Game"), Alias("ChangeGame", "SetGame")]
        [Remarks("Change what the bot is currently playing.")]
        [RequireOwner]
        public async Task SetGame([Remainder] string gamename)
        {
            await Context.Client.SetGameAsync(gamename);
            await ReplyAsync($"Changed game to `{gamename}`");
            await Context.Message.DeleteAsync();
        }




        [Command("off"),
            Alias("ok back to your hole",
            "stop",
            "go away",
            "end")]
        [Remarks("Shuts off the bot with style :)")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task EndSession
     



}
}
        
