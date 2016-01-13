using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MargieBot.Models;
using MargieBot.Responders;
using System.Text.RegularExpressions;

namespace SOCVR.Slack.BeefBot.Responders
{
    class AddBeefResponder : IResponder
    {
        Regex commandPattern = new Regex(@"(?i)^beef (low|medium|high) (\d+) (.+)?$", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public bool CanRespond(ResponseContext context)
        {
            return
                commandPattern.IsMatch(context.Message.Text) && //  Must match command regex.
                !context.Message.User.IsSlackbot && // Message must be said by a non-bot.
                context.Message.MentionsBot; // Message must mention the bot.
        }

        public BotMessage GetResponse(ResponseContext context)
        {
            throw new NotImplementedException();
        }
    }
}
