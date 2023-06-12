using System;
using System.IO;

namespace exus.Model
{
    internal class Database
    {
        Controller controller;
        int pos, size = 0, randnum;
        string mis_text;
        Random rand;
        public Database(Controller cr) 
        { 
            controller = cr; 
            pos = 0; 
        }
        public string SetText()
        {
            rand = new Random();
            randnum = rand.Next(0,3);
            string temp = File.ReadAllText("text.txt");
            string[] text = temp.Split('\n');
            mis_text = text[randnum];
            size = mis_text.Length - 1;
            return text[randnum];
        }
        public void TextCheck(char a)
        {
            if (a == mis_text[pos])
            {
                pos++;
                controller.Correct(a);
                if (size == pos)
                {
                    controller.End();
                }
            }
            else
            {
                controller.Mistake();
            }
        }
        public void AddResult(int mistake, int timer)
        {
            string date = DateTime.Now.ToString();
            string res = $"Date: {date}\nMistakes: {mistake}\nTime: {timer} сек\n\n";
            File.AppendAllText("results.txt", res);
        }
        public string GetResult()
        {
            return File.ReadAllText("results.txt");
        }
    }
}