using OOP_Exam.Exams;
using OOP_Exam.Models;
using OOP_Exam.Questions;
using OOP_Exam.Utilities;

namespace ExamSystem
{
    // بسم الله الرحمن الرحيم 
    // أنا في الواقع اضفت حاجات تانية فوق اللي مطلوب ف التاسك
    // بارك الله فيكم وجزاكم الله خيرا

    /* 
     برده فيه حاجة انا مش مستخدم النيم سبيسس 
    system or system.collections.generic or system.Threading
    عشان بس الفيرجن من الدوت نت بتاعتي 9.0 ف مثلا لو الفيرجن للباشمهندس بتقوله ان فيه ايرورز 
    ف ممكن يدخلها عنده ويضيف النيم سبيسس 
     */

    class Program
    {
        static void Main()
        {
            Answer ans1 = new Answer(1, "True");
            Answer ans2 = new Answer(2, "False");

            Answer ans3 = new Answer(1, "Python");
            Answer ans4 = new Answer(2, "Java");
            Answer ans5 = new Answer(3, "C#");

            Answer ans6 = new Answer(1, "class");
            Answer ans7 = new Answer(2, "public");
            Answer ans8 = new Answer(3, "void");

            TrueFalseQuestion q1 = new TrueFalseQuestion("Q1", "C# is an OOP language?", 5, ans1);
            MCQQuestion q2 = new MCQQuestion(
                "Q2",
                "Which programming language is a interpreted language?",
                10,
                new List<Answer> { ans3, ans4, ans5 },
                ans3
            );

            MCQQuestion q3 = new MCQQuestion(
                "Q3",
                "Which keyword is used to define a class in C#?",
                8,
                new List<Answer> { ans6, ans7, ans8 },
                ans6
            );

            FinalExam finalExam = new FinalExam(duration: 1, numQuestions: 2);
            finalExam.Questions.Add(q1);
            finalExam.Questions.Add(q2); 

            PracticalExam practicalExam = new PracticalExam(duration: 1, numQuestions: 2);
            practicalExam.Questions.Add(q3); 
            practicalExam.Questions.Add(new TrueFalseQuestion("Q4", "C# supports multiple inheritance?", 5, ans2));

            Subject subject1 = new Subject(101, "Computer Science");
            subject1.CreateExam(finalExam);

            Subject subject2 = new Subject(102, "Software Engineering");
            subject2.CreateExam(practicalExam);

            subject1.DisplayExamInformation();
            AnimatedConsole.WriteLineAnimated("\nStarting Final Exam for Computer Science:", 30);
            subject1.Exam.TakeExam();

            subject2.DisplayExamInformation();
            AnimatedConsole.WriteLineAnimated("\nStarting Practical Exam for Software Engineering:", 30);
            subject2.Exam.TakeExam();

            AnimatedConsole.WriteLineAnimated("\nPress any key to exit", 15);
            Console.ReadKey();
        }

    }
}