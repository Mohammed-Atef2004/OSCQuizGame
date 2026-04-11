using Microsoft.EntityFrameworkCore;
using OOPAlgoQuizGame.Models;

namespace OOPAlgoQuizGame.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Winner> Winners { get; set; }

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

            // ══════════════════════════════════════════════════════════════
            // SP (Structured Programming) — C++
            // ══════════════════════════════════════════════════════════════
            var spQuestions = new (string Text, string A, string B, string C, string D, string Ans, string Explanation)[]
            {
                (
                    "Which control structure is primarily used for repetition in structured programming?",
                    "if-else",
                    "switch",
                    "for/while loops",
                    "try-catch",
                    "C",
                    "Repetition (iteration) in structured programming is handled by loop constructs like 'for' and 'while'. " +
                    "In C++, a 'for' loop repeats a block a known number of times, while 'while' repeats as long as a condition is true. " +
                    "'if-else' handles decisions, 'switch' handles multi-case selection, and 'try-catch' handles exceptions — none of these repeat code."
                ),
                (
                    "Structured programming emphasizes which of the following?",
                    "GOTO-based flow",
                    "Sequential, selection, and iteration constructs",
                    "Spaghetti code",
                    "Self-modifying code",
                    "B",
                    "Structured programming, introduced by Dijkstra and Böhm-Jacopini, is built on three core constructs: " +
                    "(1) Sequence — instructions run top-to-bottom, " +
                    "(2) Selection — if/else or switch to choose paths, " +
                    "(3) Iteration — for/while loops to repeat blocks. " +
                    "GOTO and spaghetti code are exactly what structured programming was designed to eliminate, because they make code hard to read and debug."
                ),
                (
                    "In C++, which construct is a structured way to select between two alternatives?",
                    "for loop",
                    "while loop",
                    "switch",
                    "if-else",
                    "D",
                    "'if-else' is the standard structured construct for binary selection — choosing between exactly two paths. " +
                    "Example in C++: if (score >= 50) { cout << \"Pass\"; } else { cout << \"Fail\"; }. " +
                    "'switch' handles multi-way selection (many cases), while 'for' and 'while' handle repetition, not selection."
                ),
                (
                    "Which C++ feature helps break a program into reusable pieces (structured approach)?",
                    "Global variables only",
                    "Functions and procedures",
                    "GOTO statements",
                    "Inline assembly",
                    "B",
                    "Functions are the backbone of modular structured programming. Each function performs one specific task and can be called from multiple places. " +
                    "In C++: int add(int a, int b) { return a + b; } — this function can be reused anywhere without rewriting the logic. " +
                    "Global variables create hidden dependencies and make testing harder. GOTO breaks the clear flow structure. Inline assembly is non-portable and low-level."
                ),
                (
                    "What is the preferred way to handle iteration in structured programming (C++)?",
                    "Recursion only",
                    "for / while loops",
                    "Unstructured jumps",
                    "Macros",
                    "B",
                    "'for' and 'while' loops are the structured way to repeat a block of code. " +
                    "A 'for' loop is preferred when the number of iterations is known: for (int i = 0; i < 10; i++). " +
                    "A 'while' loop is preferred when repetition depends on a condition: while (input != 0). " +
                    "Recursion can replace loops but can cause stack overflow for large inputs if not managed. Unstructured jumps (GOTO) are avoided."
                ),
                (
                    "Why avoid GOTO in structured programming?",
                    "It improves readability",
                    "It causes predictable flow",
                    "It creates spaghetti code and unpredictable control flow",
                    "It removes loops",
                    "C",
                    "GOTO jumps execution to an arbitrary label anywhere in the code, making it nearly impossible to trace the program's logic. " +
                    "This leads to 'spaghetti code' — tangled, hard-to-maintain programs. " +
                    "Edsger Dijkstra's famous 1968 letter 'Go To Statement Considered Harmful' proved that any program using GOTO can be rewritten using structured constructs (sequence, selection, iteration) that are far clearer and more maintainable."
                ),
                (
                    "Which is a top-down structured design practice?",
                    "Start with low-level code",
                    "Begin with high-level modules and refine downward",
                    "Write random functions",
                    "Mix UI and logic in one place",
                    "B",
                    "Top-down design starts by defining the overall problem at a high level, then progressively breaking it into smaller sub-problems (stepwise refinement). " +
                    "Example: Design a 'Bank System' → decompose into 'Login', 'Withdraw', 'Deposit' → each function then decomposed further. " +
                    "This approach makes large problems manageable and each piece testable independently. It contrasts with bottom-up design, which starts from low-level utilities."
                ),
                (
                    "In C++ structured programs, which promotes maintainability?",
                    "Large monolithic functions",
                    "Small, focused functions that do one thing",
                    "One-file programs with thousands of lines",
                    "Multiple global flags",
                    "B",
                    "Small functions that do exactly one thing are easier to read, test, and fix. " +
                    "If a bug exists in 'calculateTax()', you look in one small function, not search 1000 lines. " +
                    "This is the basis of the Single Responsibility Principle (also part of SOLID). " +
                    "Global flags create hidden coupling between functions — changing a flag in one place can silently break behavior elsewhere."
                ),
                (
                    "Which statement best expresses the goal of structured programming?",
                    "Reduce modularity",
                    "Achieve clear, readable, and maintainable control flow",
                    "Increase GOTO usage",
                    "Maximize side effects",
                    "B",
                    "The ultimate goal of structured programming is code that humans can read, understand, and maintain confidently. " +
                    "By limiting control flow to three constructs (sequence, selection, iteration) and breaking programs into functions, " +
                    "structured programming makes bugs easier to find, code easier to test, and teams able to collaborate on large codebases without confusion."
                ),
                (
                    "Which construct should you prefer for clarity in C++ loops?",
                    "Unbounded GOTO",
                    "for/while with a clear exit condition",
                    "Nested gotos",
                    "Self-modifying loops",
                    "B",
                    "A well-written loop has three clear parts: initialization, condition, and update. " +
                    "Example: for (int i = 0; i < n; i++) — anyone reading this immediately knows it runs n times. " +
                    "A 'while' loop with a clear condition (while (!done)) is equally readable. " +
                    "Self-modifying code or GOTO-based loops hide their behavior, making debugging a nightmare and maintenance very risky."
                )
            };

            foreach (var (text, a, b, c, d, ans, explanation) in spQuestions)
            {
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
                    Explanation = explanation
                });
            }

            // ══════════════════════════════════════════════════════════════
            // SOLID Principles
            // ══════════════════════════════════════════════════════════════
            var solidQuestions = new (string Text, string A, string B, string C, string D, string Ans, string Explanation)[]
            {
                (
                    "What does the acronym SOLID stand for?",
                    "System Object Logic Interface Design",
                    "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion",
                    "Simple Object Language Interface Definition",
                    "Strong Object Linking Interface Design",
                    "B",
                    "SOLID is a set of five design principles coined by Robert C. Martin (Uncle Bob): " +
                    "S — Single Responsibility: a class should have only one reason to change. " +
                    "O — Open/Closed: open for extension, closed for modification. " +
                    "L — Liskov Substitution: subtypes must be replaceable for their base types. " +
                    "I — Interface Segregation: prefer small specific interfaces over one large interface. " +
                    "D — Dependency Inversion: depend on abstractions, not concrete implementations. " +
                    "Following SOLID leads to flexible, testable, and maintainable object-oriented code."
                ),
                (
                    "What does the Single Responsibility Principle (SRP) state?",
                    "One class should handle many responsibilities",
                    "Each class should have only one reason to change",
                    "Multiple responsibilities are encouraged per class",
                    "A class should have no responsibilities",
                    "B",
                    "SRP states that a class should do one thing and do it well. " +
                    "Example: a 'Report' class should generate a report but NOT save it to disk — that's a second responsibility. " +
                    "If you mix report generation and file saving in one class, a change in the file format forces you to modify the report logic too, risking bugs. " +
                    "Separating them means each class changes only when its single responsibility changes."
                ),
                (
                    "What does the Open/Closed Principle (OCP) state?",
                    "Classes should always be open for modification",
                    "Classes should be open for extension but closed for modification",
                    "Classes should be closed for both extension and modification",
                    "Always rewrite code when adding features",
                    "B",
                    "OCP means you should add new behavior by extending classes (e.g., creating a subclass or implementing an interface), not by editing existing code. " +
                    "Example: Instead of adding an 'if (shape == circle)' inside a drawing function, create a 'Shape' interface with a 'draw()' method. Each new shape implements 'draw()' without touching existing code. " +
                    "This protects existing tested code from accidental breakage when adding features."
                ),
                (
                    "What does the Dependency Inversion Principle (DIP) state?",
                    "High-level modules should depend on concrete low-level classes",
                    "Modules should depend on abstractions, not on concrete implementations",
                    "Invert the class inheritance hierarchy",
                    "Remove all dependencies between classes",
                    "B",
                    "DIP says high-level business logic should not be tightly coupled to low-level details like databases or file systems. " +
                    "Instead, both should depend on an abstraction (interface). " +
                    "Example: instead of 'OrderService' directly using 'MySqlDatabase', define an 'IDatabase' interface. " +
                    "'OrderService' uses 'IDatabase', and you can swap MySQL for SQLite or an in-memory database for testing without changing 'OrderService'. " +
                    "This is the foundation of dependency injection frameworks."
                ),
                (
                    "What does the Interface Segregation Principle (ISP) advocate?",
                    "One large interface with many methods",
                    "Multiple small, specific interfaces rather than one large general one",
                    "No interfaces at all",
                    "Using multiple inheritance instead",
                    "B",
                    "ISP states that a class should not be forced to implement methods it does not use. " +
                    "Example: a fat 'IAnimal' interface with 'fly()', 'swim()', 'run()' forces a 'Dog' class to implement 'fly()' even though dogs can't fly. " +
                    "Instead, split into 'IFlyable', 'ISwimmable', 'IRunnnable'. Now 'Dog' implements only 'ISwimmable' and 'IRunnnable'. " +
                    "This keeps implementations clean and avoids dummy/empty method bodies."
                )
            };

            foreach (var (text, a, b, c, d, ans, explanation) in solidQuestions)
            {
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
                    Explanation = explanation
                });
            }

            // ══════════════════════════════════════════════════════════════
            // OOP — Java-focused
            // ══════════════════════════════════════════════════════════════
            var oopQuestions = new (string Text, string A, string B, string C, string D, string Ans, string Explanation)[]
            {
                (
                    "Which OOP principle focuses on bundling data and methods together inside a class?",
                    "Inheritance",
                    "Encapsulation",
                    "Polymorphism",
                    "Abstraction",
                    "B",
                    "Encapsulation bundles an object's data (fields) and the methods that operate on that data inside one class, and restricts direct access from outside. " +
                    "In Java, this is done with private fields and public getters/setters: " +
                    "private String name; public String getName() { return name; }. " +
                    "This protects internal state, prevents invalid data, and allows the internal implementation to change without breaking external code."
                ),
                (
                    "What is method overriding in OOP?",
                    "Same method name with different parameter signatures in the same class",
                    "Redefining a parent class method in a child class with the same signature",
                    "Changing a method's return type in any subclass",
                    "Creating multiple unrelated methods",
                    "B",
                    "Overriding allows a subclass to provide its own implementation of a method already defined in its parent class. " +
                    "In Java, use the @Override annotation: class Animal { void speak() { System.out.println(\"...\"); } } — " +
                    "class Dog extends Animal { @Override void speak() { System.out.println(\"Woof!\"); } }. " +
                    "This is how runtime polymorphism works: the JVM calls the correct overridden version based on the actual object type, not the reference type."
                ),
                (
                    "Which keyword prevents a class from being subclassed in Java or C#?",
                    "abstract",
                    "static",
                    "sealed (C#) / final (Java)",
                    "readonly",
                    "C",
                    "In Java, the 'final' keyword on a class prevents inheritance: final class String { } — you cannot extend String. " +
                    "In C#, the equivalent is 'sealed': sealed class MyClass { }. " +
                    "This is used when a class's behavior must not be altered by subclassing — for security, performance optimization by the JIT compiler, or design intent. " +
                    "'abstract' does the opposite — it forces subclassing. 'static' means the class holds only static members."
                ),
                (
                    "What does polymorphism allow in OOP?",
                    "Storing multiple data types in one variable",
                    "The same interface or method name to behave differently depending on the object",
                    "Hiding all data from external access",
                    "Copying code from one class to another",
                    "B",
                    "Polymorphism (Greek: 'many forms') lets one interface represent different underlying types. " +
                    "Example in Java: Animal a = new Dog(); a.speak(); — even though 'a' is declared as Animal, Java calls Dog's 'speak()' at runtime. " +
                    "This is 'runtime polymorphism'. Compile-time polymorphism is method overloading (same name, different parameters). " +
                    "Polymorphism is what makes design patterns like Strategy, Factory, and Command possible."
                ),
                (
                    "What is abstraction in OOP?",
                    "Creating instances of every class",
                    "Hiding complex implementation details and exposing only what is necessary",
                    "Physically binding data to methods",
                    "Copying behavior from parent classes",
                    "B",
                    "Abstraction means showing the user only what they need to know and hiding the internal complexity. " +
                    "Example: when you call list.sort() in Java, you don't need to know whether it uses Timsort internally — you just know it sorts the list. " +
                    "In Java, abstraction is achieved through abstract classes (abstract class Shape { abstract void draw(); }) and interfaces. " +
                    "Abstract classes cannot be instantiated — they exist to be extended. This separates 'what a class does' from 'how it does it'."
                )
            };

            foreach (var (text, a, b, c, d, ans, explanation) in oopQuestions)
            {
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
                    Explanation = explanation
                });
            }

            // ══════════════════════════════════════════════════════════════
            // DATA STRUCTURES — C++
            // ══════════════════════════════════════════════════════════════
            var dsQuestions = new (string Text, string A, string B, string C, string D, string Ans, string Explanation)[]
            {
                (
                    "Which data structure follows the LIFO (Last In, First Out) principle?",
                    "Queue",
                    "Stack",
                    "Heap",
                    "Tree",
                    "B",
                    "A Stack works like a pile of plates — the last plate you put on top is the first one you take off (LIFO). " +
                    "Operations: push() adds to the top, pop() removes from the top, both O(1). " +
                    "In C++: std::stack<int> s; s.push(1); s.push(2); s.pop(); // removes 2. " +
                    "Real-world uses: function call stack (how recursion works), undo/redo in editors, browser back button. " +
                    "A Queue is FIFO (opposite), a Heap is for priority-based retrieval, and a Tree is hierarchical."
                ),
                (
                    "Which data structure follows the FIFO (First In, First Out) principle?",
                    "Stack",
                    "Queue",
                    "Both Stack and Queue",
                    "Neither",
                    "B",
                    "A Queue works like a real-world queue/line — the first person to join is the first to be served (FIFO). " +
                    "Operations: enqueue() adds to the back, dequeue() removes from the front, both O(1). " +
                    "In C++: std::queue<int> q; q.push(1); q.push(2); q.front(); // returns 1; q.pop(); // removes 1. " +
                    "Real-world uses: print job scheduling, CPU process scheduling, BFS (Breadth-First Search) graph traversal."
                ),
                (
                    "What is the time complexity of accessing an element by index in an array?",
                    "O(n)",
                    "O(log n)",
                    "O(1)",
                    "O(n²)",
                    "C",
                    "Arrays store elements in contiguous memory locations. Since each element is the same size, the CPU can compute any element's address as: " +
                    "address = base_address + (index × element_size). This arithmetic is done in one step regardless of array size, making it O(1) — constant time. " +
                    "In C++: int arr[5] = {10,20,30,40,50}; cout << arr[3]; // directly accesses 40 in O(1). " +
                    "This is why arrays are preferred when random access speed is critical."
                ),
                (
                    "What is the key ordering property of a Binary Search Tree (BST)?",
                    "Left child is greater than the parent",
                    "Left child is less than the parent, right child is greater",
                    "Nodes have no specific order",
                    "Nodes are in random order",
                    "B",
                    "In a BST, for every node: all values in the left subtree are less than the node's value, and all values in the right subtree are greater. " +
                    "This allows binary search: to find 7 in a BST rooted at 10, go left (since 7 < 10), then compare again. Each step halves the search space. " +
                    "Search, insert, and delete are O(log n) for balanced BSTs and O(n) in the worst case (degenerate/skewed tree). " +
                    "C++ offers std::map and std::set, which are implemented as balanced BSTs (Red-Black Trees)."
                ),
                (
                    "What is the time complexity of Heap Sort?",
                    "O(n)",
                    "O(log n)",
                    "O(n log n)",
                    "O(n²)",
                    "C",
                    "Heap Sort works in two phases: (1) Build a max-heap from the array — O(n). " +
                    "(2) Repeatedly extract the maximum element and place it at the end — each extraction is O(log n) and is done n times, giving O(n log n). " +
                    "Total: O(n log n) in all cases — best, average, and worst — making it more predictable than QuickSort (which is O(n²) worst case). " +
                    "It sorts in-place (O(1) extra space) but is not stable (equal elements may change relative order). " +
                    "In C++, std::sort_heap implements this after std::make_heap."
                )
            };

            foreach (var (text, a, b, c, d, ans, explanation) in dsQuestions)
            {
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
                    Explanation = explanation
                });
            }

            // ══════════════════════════════════════════════════════════════
            // .NET — C#
            // ══════════════════════════════════════════════════════════════
            var dotnetQuestions = new (string Text, string A, string B, string C, string D, string Ans, string Explanation)[]
            {
                (
                    "What does CLR stand for in the .NET ecosystem?",
                    "Common Language Runtime",
                    "Code Level Reuse",
                    "C# Library Runtime",
                    "Common Logic Run",
                    "A",
                    "The Common Language Runtime (CLR) is the virtual machine at the heart of .NET. It provides: " +
                    "(1) Memory management via Garbage Collection — frees unused objects automatically. " +
                    "(2) JIT compilation — converts IL (Intermediate Language) to native machine code at runtime. " +
                    "(3) Type safety, exception handling, and thread management. " +
                    "Because all .NET languages (C#, VB.NET, F#) compile to the same IL, the CLR can run any of them — " +
                    "this is what makes .NET 'language agnostic' within the framework."
                ),
                (
                    "How is IL (Intermediate Language) code executed in .NET?",
                    "Directly by the CPU without any compilation",
                    "Through the JIT (Just-In-Time) compiler at runtime",
                    "Through a traditional line-by-line interpreter",
                    "It is pre-compiled to native code at install time always",
                    "B",
                    "C# compiles to IL (also called CIL — Common Intermediate Language), not to native machine code. " +
                    "When you run a .NET app, the CLR's JIT compiler translates IL to native CPU instructions on-the-fly. " +
                    "The JIT caches the compiled native code, so methods are only JIT-compiled once per run. " +
                    ".NET also offers AOT (Ahead-of-Time) compilation in newer versions (.NET 7+) to pre-compile IL to native for faster startup, " +
                    "but JIT remains the default model."
                ),
                (
                    "What does an async method return in C# when it performs an asynchronous operation?",
                    "Task or Task<T>",
                    "Promise",
                    "Future",
                    "Coroutine",
                    "A",
                    "In C#, async methods must return Task (no result), Task<T> (returns a value), or void (only for event handlers — generally avoid). " +
                    "Example: async Task<string> FetchDataAsync() { var result = await httpClient.GetStringAsync(url); return result; }. " +
                    "The 'await' keyword suspends the method until the Task completes, freeing the thread for other work. " +
                    "This avoids blocking the UI thread in desktop apps or the request thread in ASP.NET. " +
                    "'Promise' is JavaScript's equivalent; 'Future' is used in Java/Dart; 'Coroutine' is Kotlin's model."
                ),
                (
                    "In Entity Framework Core, what does DbContext represent?",
                    "A single database table",
                    "A session with the database — the unit of work and repository",
                    "A raw SQL connection string",
                    "A single DbSet entity",
                    "B",
                    "DbContext is the central class in EF Core. It represents a session with the database and manages: " +
                    "(1) DbSet<T> properties — each maps to a database table. " +
                    "(2) Change tracking — it watches which entities were added, modified, or deleted. " +
                    "(3) SaveChanges() — translates tracked changes into SQL INSERT/UPDATE/DELETE statements and executes them. " +
                    "Example: using (var db = new AppDbContext()) { db.Users.Add(newUser); db.SaveChanges(); } — " +
                    "EF Core generates and executes the INSERT SQL automatically."
                ),
                (
                    "What does running 'Add-Migration' in EF Core create?",
                    "A C# migration file describing the schema changes",
                    "The actual database on the server",
                    "A new table directly in SQL Server",
                    "A new connection string in appsettings.json",
                    "A",
                    "'Add-Migration MigrationName' compares your current model (C# classes) with the last migration snapshot and generates a new C# migration file. " +
                    "This file contains Up() — the changes to apply (e.g., CreateTable, AddColumn) and Down() — how to reverse them. " +
                    "The migration file is NOT applied to the database yet — for that, you run 'Update-Database', which executes the Up() method and updates the __EFMigrationsHistory table. " +
                    "This workflow lets you version-control your database schema alongside your code."
                )
            };

            foreach (var (text, a, b, c, d, ans, explanation) in dotnetQuestions)
            {
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
                    Explanation = explanation
                });
            }

            return questions;
        }
    }
}