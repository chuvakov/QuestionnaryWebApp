using QuestionnaireWebApp.Core.Enums;

namespace QuestionnaireWebApp.Core.Models;

public static class FileLoader
{
    private const string PATH_TO_FILES = @"/Users/aleksandr/Desktop/Questionnaire/Questionnaire.ConsoleApp/Files";

    public static void DownloadCompletedQuestionnaire(Questionnaire questionnaire)
    {
        using (StreamWriter sw =
               new StreamWriter(Path.Combine(PATH_TO_FILES, "CompletedQestionnaireas", $"{questionnaire.Name}.txt")))
        {
            sw.WriteLine("Название опроса: " + questionnaire.Name);
            sw.WriteLine("Колличество вопросов: " + questionnaire.Questions.Count);
            sw.WriteLine();

            foreach (var question in questionnaire.Questions)
            {
                PrintQuestion(question, sw);

                // if (question.SelectedAnswer.IsExistExtraQuestion())
                // {
                //     PrintQuestion(question.SelectedAnswer.ExtraQuestion, sw, true);
                // }
            }
        }
    }

    private static void PrintQuestion(Question question, StreamWriter sw, bool isExtraQuestion = false)
    {
        string prefix = isExtraQuestion ? "Доп.вопрос" : $"{question.Number}. Вопрос";

        if (question.Type == QuestionType.Many || question.Type == QuestionType.Single)
        {
            sw.WriteLine($"{prefix} (открытый): {question.Text}");
            //sw.WriteLine($"Ответ: {question.SelectedAnswer.Text}\n");
            return;
        }

        sw.WriteLine($"{prefix}: {question.Text}");
        sw.WriteLine("\nВарианты ответа: ");

        foreach (var answer in question.AnswerVariants)
        {
            // if (answer == question.SelectedAnswer)
            // {
            //     sw.WriteLine($"{answer.Number}. {answer.Text} (Выбранный)");
            // }
            // else if (answer.Text == "Ответить самому" && question.SelectedAnswer.Number == 0)
            // {
            //     sw.WriteLine($"{answer.Number}. {answer.Text} (Выбранный)");
            //     sw.WriteLine("Ответ: " + question.SelectedAnswer.Text);
            // }
            // else
            // {
            //     sw.WriteLine($"{answer.Number}. {answer.Text}");
            // }
        }

        sw.WriteLine();
    }

    public static void ExportQuestionnaire(Questionnaire questionnaire)
    {
        using (var sw = new StreamWriter(Path.Combine(PATH_TO_FILES, "Templates", $"{questionnaire.Name}.txt")))
        {
            //sw.WriteLine(JsonConvert.SerializeObject(questionnairee));
        }
    }

    public static Questionnaire ImportQuestionnaire(string fileName)
    {
        Questionnaire questionnaire = null;

        using (var sr = new StreamReader(Path.Combine(PATH_TO_FILES, "Templates", $"{fileName}.txt")))
        {
            //questionnairee = JsonConvert.DeserializeObject<Questionnairee>(sr.ReadLine());
        }

        return questionnaire;
    }
}
