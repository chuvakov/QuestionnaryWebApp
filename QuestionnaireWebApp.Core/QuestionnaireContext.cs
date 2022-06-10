using Microsoft.EntityFrameworkCore;
using QuestionnaireWebApp.Core.Models;

namespace QuestionnaireWebApp.Core;

public class QuestionnaireContext : DbContext
{
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Form> Forms { get; set; }
    public DbSet<FormAnswer> FormAnswers { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Questionnaire> Questionnairees { get; set; }

    public QuestionnaireContext(DbContextOptions options) : base(options)
    {
    }
}