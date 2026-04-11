using Microsoft.EntityFrameworkCore;
using OOPAlgoQuizGame.Models;

namespace OOPAlgoQuizGame.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Winner>   Winners   { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var questions = GetSeedQuestions();
            modelBuilder.Entity<Question>().HasData(questions);
        }

        private static List<Question> GetSeedQuestions()
        {
            var questions = new List<Question>();
            int id = 1;

            // LANGUAGE mapping by category
            static string CategoryLanguage(string category) => category switch
            {
                "SP" => "C++",
                "SOLID" => "Design principles (language agnostic)",
                "OOP" => "Java",
                "DS" => "C++",
                ".NET" => "C#",
                _ => "General"
            };

            static string BuildExplanation(string category, string correctText, string questionText)
            {
                var lang = CategoryLanguage(category);
                // Short templated explanation referencing the correct option and category language.
                // These are concise; replace with handwritten explanations if you want more depth.
                return $"{correctText} — This is the correct answer. In {lang}, this concept applies as described.";
            }

            // ══════════════════════════════════════════════════════════════
            // SP (Structured Programming) - C++ questions (sample set)
            // ══════════════════════════════════════════════════════════════
            var spQuestions = new (string Text, string A, string B, string C, string D, string Ans)[]
            {
                ("Which control structure is primarily used for repetition in structured programming?", "if-else", "switch", "for/while loops", "try-catch", "C"),
                ("Structured programming emphasizes which of the following?", "GOTO-based flow", "Sequential, selection, iteration", "Spaghetti code", "Self-modifying code", "B"),
                ("In C++, which construct is a structured way to select between two alternatives?", "for loop", "while loop", "switch", "if-else", "D"),
                ("Which C++ feature helps break a program into reusable pieces (structured approach)?", "Global variables only", "Functions and procedures", "GOTO statements", "Inline assembly", "B"),
                ("What is the preferred way to handle iteration in structured programming (C++)?", "Recursion only", "for / while loops", "Unstructured jumps", "Macros", "B"),
                ("Why avoid GOTO in structured programming?", "It improves readability", "It causes predictable flow", "It creates spaghetti code", "It removes loops", "C"),
                ("Which is a top-down structured design practice?", "Start with low-level code", "Begin with high-level modules", "Write random functions", "Mix UI and logic", "B"),
                ("In C++ structured programs, which promotes maintainability?", "Large monolithic functions", "Small focused functions", "One-file programs", "Multiple global flags", "B"),
                ("Which statement best expresses structured programming goal?", "Reduce modularity", "Clear, linear control flow", "Increase GOTO usage", "Maximize side effects", "B"),
                ("Which construct should you prefer for clarity in C++ loops?", "Unbounded GOTO", "for/while with clear exit", "Nested gotos", "Self-modifying loops", "B")
            };

            foreach (var (text, a, b, c, d, ans) in spQuestions)
            {
                string correctText = ans switch
                {
                    "A" => a,
                    "B" => b,
                    "C" => c,
                    "D" => d,
                    _ => ""
                };

                questions.Add(new Question
                {
                    Id = id++,
                    Category = "SP",
                    QuestionText = text,
                    OptionA = a,
                    OptionB = b,
                    OptionC = c,
                    OptionD = d,
                    CorrectAnswer = ans,
                    Explanation = BuildExplanation("SP", correctText, text)
                });
            }

            // ══════════════════════════════════════════════════════════════
            // SOLID Principles (kept separate, design-focused)
            // ══════════════════════════════════════════════════════════════
            var solidQuestions = new (string Text, string A, string B, string C, string D, string Ans)[]
            {
                ("What does SOLID stand for?", "System Object Logic Interface Design", "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion", "Simple Object Language Interface Definition", "Strong Object Linking Interface Design", "B"),
                ("Single Responsibility Principle means?", "One class many reasons to change", "Each class has one reason to change", "Multiple responsibilities encouraged", "No responsibilities", "B"),
                ("Open/Closed Principle is about?", "Open for modification only", "Open for extension, closed for modification", "Closed for both", "Always modifying code", "B"),
                ("Dependency Inversion means?", "Depend on concrete classes", "Depend on abstractions, not implementations", "Invert class hierarchy", "No dependencies", "B"),
                ("Interface Segregation advocates?", "Large interfaces", "Small specific interfaces", "No interfaces", "Multiple inheritance", "B")
            };

            foreach (var (text, a, b, c, d, ans) in solidQuestions)
            {
                string correctText = ans switch
                {
                    "A" => a,
                    "B" => b,
                    "C" => c,
                    "D" => d,
                    _ => ""
                };

                questions.Add(new Question
                {
                    Id = id++,
                    Category = "SOLID",
                    QuestionText = text,
                    OptionA = a,
                    OptionB = b,
                    OptionC = c,
                    OptionD = d,
                    CorrectAnswer = ans,
                    Explanation = BuildExplanation("SOLID", correctText, text)
                });
            }

            // ══════════════════════════════════════════════════════════════
            // OOP - Java-focused questions (kept existing content but explanations mention Java)
            // ══════════════════════════════════════════════════════════════
            var oopQuestions = new (string Text, string A, string B, string C, string D, string Ans)[]
            {
                ("Which principle focuses on bundling data and methods?", "Inheritance", "Encapsulation", "Polymorphism", "Abstraction", "B"),
                ("What is method overriding?", "Same method name, different signatures", "Redefining parent method in child", "Changing method return type", "Creating multiple methods", "B"),
                ("Which keyword prevents inheritance in C# or Java-like languages?", "abstract", "static", "sealed", "readonly", "C"),
                ("What is polymorphism?", "Multiple data types", "Same interface, different behavior", "Data hiding", "Code reusability", "B"),
                ("What is abstraction?", "Creating instances", "Hiding complexity", "Binding data", "Inheriting classes", "B")
            };

            foreach (var (text, a, b, c, d, ans) in oopQuestions)
            {
                string correctText = ans switch
                {
                    "A" => a,
                    "B" => b,
                    "C" => c,
                    "D" => d,
                    _ => ""
                };

                // tailor explanation to Java
                questions.Add(new Question
                {
                    Id = id++,
                    Category = "OOP",
                    QuestionText = text,
                    OptionA = a,
                    OptionB = b,
                    OptionC = c,
                    OptionD = d,
                    CorrectAnswer = ans,
                    Explanation = $"{correctText} — This matches the core OOP concept. In Java, this is typically implemented using classes and interfaces."
                });
            }

            // ══════════════════════════════════════════════════════════════
            // DATA STRUCTURES - C++ (explanations reference C++)
            // ══════════════════════════════════════════════════════════════
            var dsQuestions = new (string Text, string A, string B, string C, string D, string Ans)[]
            {
                ("LIFO principle followed by?", "Queue", "Stack", "Heap", "Tree", "B"),
                ("FIFO principle followed by?", "Stack", "Queue", "Both", "Neither", "B"),
                ("Array access time complexity?", "O(n)", "O(log n)", "O(1)", "O(n^2)", "C"),
                ("Binary Search Tree property?", "Left > Right", "Left < Right", "No order", "Random order", "B"),
                ("Heap sort time complexity?", "O(n)", "O(log n)", "O(n log n)", "O(n^2)", "C")
            };

            foreach (var (text, a, b, c, d, ans) in dsQuestions)
            {
                string correctText = ans switch
                {
                    "A" => a,
                    "B" => b,
                    "C" => c,
                    "D" => d,
                    _ => ""
                };

                questions.Add(new Question
                {
                    Id = id++,
                    Category = "DS",
                    QuestionText = text,
                    OptionA = a,
                    OptionB = b,
                    OptionC = c,
                    OptionD = d,
                    CorrectAnswer = ans,
                    Explanation = $"{correctText} — In C++ implementations, this property is used when implementing this data structure/algorithm."
                });
            }

            // ══════════════════════════════════════════════════════════════
            // .NET - C# (explanations reference C#)
            // ══════════════════════════════════════════════════════════════
            var dotnetQuestions = new (string Text, string A, string B, string C, string D, string Ans)[]
            {
                ("CLR stands for?", "Common Language Runtime", "Code Level Reuse", "C# Library Runtime", "Common Logic Run", "A"),
                ("IL code executes via?", "Direct CPU", "JIT compiler", "Interpreter", "Native code", "B"),
                ("async/await returns?", "Task", "Promise", "Future", "Coroutine", "A"),
                ("DbContext represents?", "Database table", "ORM session", "SQL connection", "DbSet", "B"),
                ("Add-Migration creates?", "Migration file", "Database", "Table", "Connection", "A")
            };

            foreach (var (text, a, b, c, d, ans) in dotnetQuestions)
            {
                string correctText = ans switch
                {
                    "A" => a,
                    "B" => b,
                    "C" => c,
                    "D" => d,
                    _ => ""
                };

                questions.Add(new Question
                {
                    Id = id++,
                    Category = ".NET",
                    QuestionText = text,
                    OptionA = a,
                    OptionB = b,
                    OptionC = c,
                    OptionD = d,
                    CorrectAnswer = ans,
                    Explanation = $"{correctText} — In C#, this is how the framework or language behaves."
                });
            }

            return questions;
        }
    }
}
