using System;
using System.IO;

namespace exus.Model
{
    internal class Database
    {
        Controller controller;
        int pos, size = 0;
        string mis_text;
        public Database(Controller cr) 
        { 
            controller = cr; pos = 0; 
        }
        public string SetText()
        {
            string temp = File.ReadAllText("text.txt");
            string[] text = temp.Split('\n');
            mis_text = temp;
            size = mis_text.Length;
            return text[0];
        }
        public void TextCheck(char a)
        {
            if (a == mis_text[pos])
            {
                pos++;
                controller.Correct(a);
                if (size  == pos)
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
