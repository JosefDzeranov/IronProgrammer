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
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Complexity> Complexities { get; set; }
        public DbSet<Country> Сountries { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Problem> OriginalTasks { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TypeProblem> TypeTasks { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
    }
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ProblemContext>
    {
        protected override void Seed(ProblemContext context)
        {

            Models.EF.Attribute a = new Attribute();
            a.Name = "Условие задачи";
            context.Attributes.Add(a);
            context.SaveChanges();
            a.Name = "Код программы";
            context.Attributes.Add(a);
            context.SaveChanges();
            a.Name = "Тэг";
            context.Attributes.Add(a);
            context.SaveChanges();
            a.Name = "Сложность";
            context.Attributes.Add(a);
            context.SaveChanges();
            a.Name = "Тип задания";
            context.Attributes.Add(a);
            context.SaveChanges();

            Models.EF.Topic tmp = new Topic();
            tmp.Name = "Ввод вывод информации";
            context.Topics.Add(tmp);
            context.SaveChanges();

            tmp.Name = "Условный оператор";
            context.Topics.Add(tmp);
            context.SaveChanges();
            tmp.Name = "Циклы";
            context.Topics.Add(tmp);
            context.SaveChanges();
            tmp.Name = "Строки";
            context.Topics.Add(tmp);
            context.SaveChanges();

            Models.EF.Problem t = new Problem();
            t.Topics.Add(tmp);
            foreach (var i in context.Attributes)
            {
                ProblemAttribute task = new ProblemAttribute();
                task.Value = "asdklasldja;dsad";
                task.Attribute = i;
                t.TaskAttributes.Add(task);
            }
            string[] s = new string[]
            {
            "foreach (var i in context.Attributes)",
            "{"," TaskAttribute task = new TaskAttribute();",
            "task.Value = \"asdklasldja;dsad\";",
            " task.Attribute = i;",
            "}"
            };
            foreach (var item in s)
            {
                var codeline = new CodeLine();
                codeline.Content = item;
                //t.Codelines.Add(codeline);
            }
            context.OriginalTasks.Add(t);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}