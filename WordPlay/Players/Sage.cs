using System.Collections.Generic;
using System.Linq;

namespace WordPlay
{
    public class Sage : Player
    {
        public Sage(List<string> source) : base(source)
        {
            // our strategy is destructive
            // make a copy of the list.
            this.Wordlist = source.ToList();

        }

        public override char[] SelectWord()
        {
            return Wordlist.Random().ToCharArray();
        }

        public override void RespondToPlay(char[] guess, char[] response)
        {
            for (int i = 0; i < 5; i++)
            {
                if (response[i] == (char)responsetype.full) require(guess[i], i);
                if (response[i] == (char)responsetype.nomatch) whittle(guess[i]);
                if (response[i] == (char)responsetype.partial)
                {
                    restrict(guess[i], i);
                    gotta(guess[i]);
                }
            }
            Wordlist.Remove(new string(guess));
        }
    }
}
