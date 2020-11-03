using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZacharyChilders_Final_Project_CPT_185_FloppySharp.Helpers;

namespace ZacharyChilders_Final_Project_CPT_185_FloppySharp.Misc
{
    public class MiscCommands:ModuleBase<CommandContext>
    {
        

        [Command("add")]
        [Summary("Adds 2 numbers together.")]
        public async Task AddAsync(float num1, float num2)
        {
            await ReplyAsync($"The Answer To That Is: {num1 + num2}");
        }

        [Command("Subtract")]
        [Summary("Subtracts 2 numbers.")]
        public async Task SubstractAsync(float num1, float num2)
        {
            await ReplyAsync($"The Answer To That Is: {num1 - num2}");
        }

        [Command("Multiply")]
        [Summary("Multiplys 2 Numbers.")]
        public async Task MultiplyAsync(float num1, float num2)
        {
            await ReplyAsync($"The Answer To That Is {num1 * num2}");
        }

        [Command("Divide")]
        [Summary("Divides 2 Numbers.")]
        public async Task DivideAsync(float num1, float num2)
        {
            await ReplyAsync($"The Answer To That Is: {num1 / num2}");
        }

        [Command("Math")]
        [Summary("Computes mathematical operations.")]
        public async Task Computate(params String[] input)
        {
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                char[] inputWithoutSpaces = input.ElementAt(i).Where(c => !Char.IsWhiteSpace(c)).ToArray();
                for (int j = 0; j < inputWithoutSpaces.Count(); j++)
                {
                    word.Append(inputWithoutSpaces[j]);
                }

                input[i] = word.ToString();
                word = new StringBuilder();
                if (input.ElementAt(i).Length > 2)
                {
                    input[i] = MathButCooler.PerformComputation(input[i]).ToString(CultureInfo.CurrentCulture);
                }
            }
            StringBuilder sentence = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sentence.Append(input[i]);
            }

            await ReplyAsync($"{MathButCooler.PerformComputation(sentence.ToString())}");
        }


      




















    }
}
