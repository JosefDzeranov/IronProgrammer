using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IronProgrammer.Models.EF
{
    public class ProblemContext : DbContext
    {
        public ProblemContext() : base("IronProgrammer") { }

        public DbSet<TypeProblem> TypeProblems { get; set; }

        public DbSet<Complexity> Complexities { get; set; }

        public DbSet<Topic> Topics { get; set; }


        public DbSet<Problem> Problems { get; set; }
        

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ProblemAttribute> ProblemAttributes { get; set; }

    }
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ProblemContext>
    {
        protected override void Seed(ProblemContext context)
        {
            TypeProblem temp = new TypeProblem() { Name = EnumTypeProblems.OneAnswer.ToString(), };
            context.TypeProblems.Add(temp);

            temp = new TypeProblem() { Name = EnumTypeProblems.MoreAnswer.ToString() };
            context.TypeProblems.Add(temp);


            Complexity complexity = new Complexity() { Name = "Легкий" };
            context.Complexities.Add(complexity);

            complexity = new Complexity() { Name = "Средний" };
            context.Complexities.Add(complexity);

            complexity = new Complexity() { Name = "Тяжелый" };
            context.Complexities.Add(complexity);

            Topic topic = new Topic() { Name = "Ввод вывод, арифметические операции" };
            context.Topics.Add(topic);

            topic = new Topic() { Name = "Условный оператор" };
            context.Topics.Add(topic);

            topic = new Topic() { Name = "Циклические конструкции" };
            context.Topics.Add(topic);

            topic = new Topic() { Name = "Одномерные массивы" };
            context.Topics.Add(topic);

            topic = new Topic() { Name = "Многомерные массивы" };
            context.Topics.Add(topic);

            topic = new Topic() { Name = "Рекурсия" };
            context.Topics.Add(topic);

            topic = new Topic() { Name = "Динамическое программирование" };
            context.Topics.Add(topic);

            topic = new Topic() { Name = "Графы" };
            context.Topics.Add(topic);



            context.SaveChanges();




            //Models.EF.Attribute a = new Attribute();
            //a.Name = "Условие задачи";
            //context.Attributes.Add(a);
            //context.SaveChanges();
            //a.Name = "Код программы";
            //context.Attributes.Add(a);
            //context.SaveChanges();
            //a.Name = "Тэг";
            //context.Attributes.Add(a);
            //context.SaveChanges();
            //a.Name = "Сложность";
            //context.Attributes.Add(a);
            //context.SaveChanges();
            //a.Name = "Тип задания";
            //context.Attributes.Add(a);
            //context.SaveChanges();

            //Models.EF.Topic tmp = new Topic();
            //tmp.Name = "Ввод вывод информации";
            //context.Topics.Add(tmp);
            //context.SaveChanges();

            //tmp.Name = "Условный оператор";
            //context.Topics.Add(tmp);
            //context.SaveChanges();
            //tmp.Name = "Циклы";
            //context.Topics.Add(tmp);
            //context.SaveChanges();
            //tmp.Name = "Строки";
            //context.Topics.Add(tmp);
            //context.SaveChanges();

            //Models.EF.Problem t = new Problem();
            //t.Topics.Add(tmp);
            //foreach (var i in context.Attributes)
            //{
            //    ProblemAttribute task = new ProblemAttribute();
            //    task.Value = "asdklasldja;dsad";
            //    task.Attribute = i;
            //    t.TaskAttributes.Add(task);
            //}
            //string[] s = new string[]
            //{
            //"foreach (var i in context.Attributes)",
            //"{"," TaskAttribute task = new TaskAttribute();",
            //"task.Value = \"asdklasldja;dsad\";",
            //" task.Attribute = i;",
            //"}"
            //};
            //foreach (var item in s)
            //{
            //    var codeline = new CodeLine();
            //    codeline.Content = item;
            //    //t.Codelines.Add(codeline);
            //}
            //context.Problems.Add(t);
            //context.SaveChanges();

            base.Seed(context);
        }
    }
}