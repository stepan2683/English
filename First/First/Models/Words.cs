using First;
using System;
using System.Collections.Generic;
using System.Text;

namespace First
{
    public class Words
    {
        public List<Word> WordsDics;
        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 6;


        public Words()
        {
            WordsDics = DB.GetAllWithWeight();
        }

        /// <summary>
        /// return all Words
        /// </summary>
        /// <returns></returns>
        public List<Word> GetAllWithWeight()
        {
            return DB.GetAllWithWeight();
        }

        public void UpdateOne(Word item)
        {
            DB.Update(item);
        }

        public void InsertIfNotExists(Word item)
        {
            if (!DB.Exists(item))
                DB.Insert(item);
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

        /// <summary>
        /// Add more weight - you didnt know the translation
        /// </summary>
        /// <param name="item"></param>
        public void SetMoreWeight(Word item)
        {
            int weight = item.Weight;
            if (item.Weight <= MIN_WEIGHT)
                weight = MIN_WEIGHT;
            else if (item.Weight >= MAX_WEIGHT)
                weight = MAX_WEIGHT;
            else
                weight++;

            // set it for all items
            SetWeightForAll(item, weight);

            var count = WordsDics.FindAll(a => a.WordCZ == item.WordCZ).Count;
            if (count < MAX_WEIGHT)
                WordsDics.Add(item);
        }

        /// <summary>
        /// Set less weight - you knew the translation
        /// </summary>
        /// <param name="item"></param>
        public void SetLessWeight(Word item)
        {
            int weight = item.Weight;
            if (item.Weight <= MIN_WEIGHT)
                weight = MIN_WEIGHT;
            else if (item.Weight >= MAX_WEIGHT)
                weight = MAX_WEIGHT;
            else
                weight--;

            SetWeightForAll(item, weight);

            var count = WordsDics.FindAll(a => a.WordCZ == item.WordCZ).Count;
            if (count > MIN_WEIGHT)
                WordsDics.Remove(item);
        }

        private void SetWeightForAll(Word item, int weight)
        {
            foreach (var i in WordsDics.FindAll(a => a.WordCZ == item.WordCZ))
            {
                i.Weight = weight;
            }

            DB.UpdateOneByCZWord(item, weight);
        }

    }
}
