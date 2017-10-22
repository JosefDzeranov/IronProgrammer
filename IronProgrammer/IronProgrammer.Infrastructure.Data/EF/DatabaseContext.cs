using System.Data.Entity;
using IronProgrammer.Domain.Core.EF;
using IronProgrammer.Models.EF;

namespace IronProgrammer.Infrastructure.Data.EF
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("IronProgrammer") { }

        public DbSet<TypeProblem> TypeProblems { get; set; }

        public DbSet<Complexity> Complexities { get; set; }

        public DbSet<Topic> Topics { get; set; }


        public DbSet<Problem> Problems { get; set; }

        public DbSet<ProblemAttribute> ProblemAttributes { get; set; }

    }
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
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
            base.Seed(context);
        }
    }
}