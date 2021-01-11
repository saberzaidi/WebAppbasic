using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppbasic.models
{
    public class GuessingGame
    {
        public int Num { get; set; }


        public static int getRandomNum()
        {
            int num = 0;

            Random random = new Random();
            num = random.Next(1, 100);

            return num;
        }

        public static string getResult(int usrGuessNumm, int genNum)
        {
            string msg = null;

            if (usrGuessNumm == genNum)
            {
                msg = "Perfect. You Guessed it!";
            }

            if (usrGuessNumm > genNum)
            {
                msg = "Oops.That was too high.Try Again!";
            }

            if (usrGuessNumm < genNum)
            {
                msg = "Oops.That was too low.Try Again!";
            }

            return msg;
        }

    }
}
