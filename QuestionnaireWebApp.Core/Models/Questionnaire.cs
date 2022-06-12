using QuestionnaireWebApp.Core.Enums;

namespace QuestionnaireWebApp.Core.Models;

public class Questionnaire : Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Question> Questions { get; set; }

    private void PrintQuestion(Question question)
    {
        Console.WriteLine($"Вопрос № {question.Number}: {question.Text}");
        if (question.Type == QuestionType.Our)
        {
            Console.WriteLine("Варианты ответов: ");
            foreach (var answer in question.AnswerVariants)
            {
                Console.WriteLine(answer);
            }
        }
        else
        {
            Console.WriteLine("Данный вопрос является открытым.");
        }
    }
    
    /// <summary>
    /// Получение ответа на вопрос
    /// </summary>
    private void GetAnswer(Question question)
    {
        lableStart:
        
        if (question.Type == QuestionType.Many || question.Type == QuestionType.Single)
            Console.Write("Введите ваш ответ: ");
        else
            Console.Write("Введите вариант ответа: ");
        
        string answerText = Console.ReadLine();
        if (question.Type == QuestionType.Many || question.Type == QuestionType.Single)
        {
            //question.SelectedAnswer = new Answer(answerText);
            return;
        }
        
        if (!CheckAnswerText(answerText, question))
            goto lableStart;

        int selectedAnswerNumber = int.Parse(answerText);
        // question.SelectedAnswer = question.AnswerVariants
        //     .First(a => a.Number == selectedAnswerNumber);

        // if (question.Type == QuestionType.Mixed && question.SelectedAnswer.Text == "Ответить самому")
        // {
        //     Console.Write("Введите ваш ответ: ");
        //     answerText = Console.ReadLine();
        //     question.SelectedAnswer = new Answer(answerText);
        // }
    }
    
    /// <summary>
    /// Проверка введенного варианта ответа для закрытого и смешанного вопроса
    /// </summary>
    private bool CheckAnswerText(string answerText, Question question)
    {
        try
        {
            int selectedAnswerNumber = int.Parse(answerText);

            if (!question.AnswerVariants.Any(a => a.Number == selectedAnswerNumber))
            {
                throw new Exception();
            }
            
            return true;
        }
        catch 
        {
            Console.WriteLine("Выбран неверный вариант ответа, попробуйте снова.");
            return false;
        }
    }

    private void AskQuestion(Question question)
    {
        PrintQuestion(question);
        GetAnswer(question);

        //Answer selectedAnswer = question.SelectedAnswer;

        // if (selectedAnswer.IsExistExtraQuestion())
        // {
        //     AskQuestion(selectedAnswer.ExtraQuestion);
        // }
    }
    
    public void Start()
    {
        Console.WriteLine(Name);
        Questions = Questions
            .OrderBy(question => question.Number)
            .ToList();

        foreach (var question in Questions)
        {
            AskQuestion(question);
        }
    }

    public void AddQuestion(Question question)
    {
        if (question == null || Questions.Any(q => q.Text == question.Text))
            return;

        if (question.Type == QuestionType.Our)
        {
            //question.AnswerVariants.Add(new Answer(question.AnswerVariants.Count + 1, "Ответить самому"));
        }

        question.Number = Questions.Count + 1;
        Questions.Add(question);
    }
}