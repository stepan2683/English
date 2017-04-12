using First;
using System;
using System.Collections.Generic;
using System.Text;

namespace First
{
    public class Words
    {
        public List<Word> WordsDics;

        public Words()
        {
            WordsDics = DB.GetAll();
        }

        /// <summary>
        /// return all Words
        /// </summary>
        /// <returns></returns>
        public List<Word> GetAll()
        {
            return DB.GetAll();
        }

        /// <summary>
        /// returns one random Word according to weight
        /// </summary>
        /// <returns></returns>
        public Word GetRandom()
        {
            Random a = new Random();
            var random = a.Next(0, WordsDics.Count);
            return WordsDics[random];
        }
    }
}
