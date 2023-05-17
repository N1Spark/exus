using exus.Model;

namespace exus
{
    public class Controller
    {
        Database db;
        Form1 view;
        Results res;
        public Controller(Form1 view)
        {
            this.view = view; 
        }
        public void Createdb()
        {
            db = new Database(this);
        }
        public string SetText()
        {
            return db.SetText();
        }
        public void Mistake()
        {
            view.Mistake();
        }
        public void Correct(char a)
        {
            view.Correct(a);
        }
        public void TapCheck(char a)
        {
            db.TextCheck(a);
        }
        public void End()
        {
            view.End();
        }
        public void AddResult(int mistake, int timer)
        {
            db.AddResult(mistake, timer);
        }
        public void ResultForm1()
        {
            res = new Results(this);
            res.ShowMenu();
        }
        public string GetResult() 
        { 
            return db.GetResult(); 
        }
    }
}
