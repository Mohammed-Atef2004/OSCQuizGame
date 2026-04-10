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

            // ══════════════════════════════════════════════════════════════
            // SP (SOLID PRINCIPLES) - 60 Questions
            // ══════════════════════════════════════════════════════════════
            var spQuestions = new (string Text, string A, string B, string C, string D, string Ans)[]
            {
                ("What does SOLID stand for?", "System Object Logic Interface Design", "Single responsibility, Open/closed, Liskov substitution, Interface segregation, Dependency inversion", "Simple Object Language Interface Definition", "Strong Object Linking Interface Design", "B"),
                ("Single Responsibility Principle means?", "One class many reasons to change", "Each class has one reason to change", "Multiple responsibilities encouraged", "No responsibilities", "B"),
                ("Which principle forbids modification after release?", "Liskov", "Open/Closed", "Interface Segregation", "Dependency Inversion", "B"),
                ("Open/Closed Principle is about?", "Open for modification only", "Open for extension, closed for modification", "Closed for both", "Always modifying code", "B"),
                ("What is Liskov Substitution Principle?", "Replace child with parent safely", "Replace parent with child safely", "No substitution allowed", "Random substitution", "A"),
                ("Interface Segregation advocates?", "Large interfaces", "Small specific interfaces", "No interfaces", "Multiple inheritance", "B"),
                ("Dependency Inversion means?", "Depend on concrete classes", "Depend on abstractions, not implementations", "Invert class hierarchy", "No dependencies", "B"),
                ("SRP violation example?", "Class handling one concern", "Class handling UI, DB, and business logic", "Well-organized class", "Simple class", "B"),
                ("How to fix SRP violation?", "Add more methods", "Split into multiple classes", "Merge classes", "Use inheritance", "B"),
                ("OCP achieved through?", "Direct modification", "Inheritance and composition", "Copy-paste code", "Global variables", "B"),
                ("Factory pattern relates to?", "OCP", "SRP", "DIP", "ISP", "A"),
                ("Strategy pattern relates to?", "OCP", "SRP", "LSP", "DIP", "A"),
                ("Decorator pattern supports?", "OCP", "SRP", "LSP", "ISP", "A"),
                ("Template Method pattern supports?", "OCP", "SRP", "ISP", "DIP", "A"),
                ("What violates LSP?", "Child extends parent properly", "Child breaks parent contract", "Parent class design", "Interface implementation", "B"),
                ("Rectangle and Square violates?", "SRP", "OCP", "LSP", "ISP", "C"),
                ("ISP example?", "One large interface", "Multiple small interfaces", "No interfaces", "Abstract classes only", "B"),
                ("Fat interface problem?", "Clients depend on unneeded methods", "Small interfaces", "Lean interfaces", "Required methods", "A"),
                ("How to fix ISP?", "Merge interfaces", "Split into role-based interfaces", "Enlarge interface", "Remove methods", "B"),
                ("DIP core idea?", "Modules depend on details", "Modules depend on abstractions", "No modules", "Hard dependencies", "B"),
                ("Inversion of Control (IoC)?", "Direct object creation", "Framework controls flow", "No control", "User controls framework", "B"),
                ("Dependency Injection types?", "Constructor only", "Constructor, Property, Method", "Method only", "No types", "B"),
                ("Constructor injection benefit?", "Optional dependencies", "Required dependencies clear", "Hidden dependencies", "Complex setup", "B"),
                ("Property injection use case?", "Required properties", "Optional dependencies", "Always use it", "Never use it", "B"),
                ("Method injection for?", "Permanent objects", "Temporary method usage", "Rare cases", "Always prefer it", "B"),
                ("Service Locator vs DI?", "Same thing", "DI preferred for testability", "Service Locator better", "Both identical", "B"),
                ("Which SOLID principle most important?", "All equally", "Depends on context", "SRP", "DIP", "B"),
                ("SOLID and Design Patterns?", "Unrelated", "Patterns implement SOLID", "SOLID requires patterns", "Opposite concepts", "B"),
                ("Refactoring to SOLID?", "Rewrite completely", "Incremental improvement", "Not recommended", "Skip unnecessary", "B"),
                ("Testing and SOLID?", "No relationship", "SOLID improves testability", "SOLID makes testing harder", "Testing unrelated", "B"),
                ("SRP and cohesion?", "Different concepts", "Related concepts", "Opposite", "Unrelated", "B"),
                ("OCP and abstraction?", "No connection", "Abstraction enables OCP", "OCP enables abstraction", "Separate concerns", "B"),
                ("LSP and type systems?", "No relationship", "LSP ensures type safety", "Type systems ignore LSP", "Unrelated fields", "B"),
                ("ISP and coupling?", "Increases coupling", "Reduces coupling", "No effect", "Random effect", "B"),
                ("DIP and decoupling?", "Increases coupling", "Enables decoupling", "No effect", "Harmful", "B"),
                ("Legacy code and SOLID?", "Ignore SOLID", "Gradually apply SOLID", "Rewrite everything", "Can't apply SOLID", "B"),
                ("Microservices and SOLID?", "Unrelated", "SOLID applies", "Prevents microservices", "Optional", "B"),
                ("SOLID in frameworks?", "Ignored", "Built-in support", "Discouraged", "Impossible", "B"),
                ("When to relax SOLID?", "Never", "Complex legacy systems", "Simple scripts", "Performance critical", "B"),
                ("SOLID and performance?", "SOLID ensures performance", "Trade-offs possible", "SOLID hurts performance", "No relationship", "B"),
                ("Over-engineering with SOLID?", "Apply everywhere", "Context-dependent", "Never apply", "Always necessary", "B"),
                ("Real-world SOLID example?", "Add more methods", "Customer/OrderRepository separation", "Merge classes", "Complex hierarchy", "B"),
                ("SOLID and agile?", "Unrelated", "SOLID supports agility", "SOLID prevents change", "Opposite concepts", "B"),
                ("SOLID in code review?", "Ignore it", "Key review points", "Optional", "Advanced only", "B"),
                ("SOLID principles count?", "3", "4", "5", "6", "C"),
                ("Best SOLID learning path?", "All at once", "Start with SRP, progress to DIP", "Random order", "Skip difficult ones", "B"),
                ("SOLID violations cost?", "Nothing", "Increased maintenance", "Improves code", "No impact", "B"),
                ("SOLID and requirements change?", "Requires rewrite", "SOLID handles change better", "No difference", "Makes it worse", "B"),
                ("Which violates SRP most?", "MVC Controller", "God Class", "Repository", "Entity", "B"),
                ("DIP in ASP.NET Core?", "Not supported", "Dependency Injection container", "Manual wiring", "Not recommended", "B"),
                ("SOLID documentation?", "Not needed", "Essential for understanding", "Burdens", "Wastes time", "B"),
                ("SOLID for teams?", "Individual concern", "Improves collaboration", "Creates conflict", "Irrelevant", "B"),
                ("SOLID and frameworks?", "Restrict framework", "Work with framework design", "Contradict framework", "Incompatible", "B"),
                ("SOLID maturity level?", "Beginner skill", "Advanced skill", "Intermediate", "Expert only", "B"),
                ("SOLID ROI?", "No benefit", "Long-term code quality", "Short-term cost", "Wastes money", "B"),
                ("Testing SOLID code?", "Harder to test", "Easier to test", "No difference", "Impossible", "B"),
                ("SOLID in interviews?", "Never asked", "Common topic", "Rarely discussed", "Advanced only", "B"),
                ("SOLID certification?", "Useful?", "Demonstrates knowledge", "Not valuable", "Required", "B")
            };

            foreach (var (text, a, b, c, d, ans) in spQuestions)
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
                    CorrectAnswer = ans 
                });
            }

            // ══════════════════════════════════════════════════════════════
            // OOP - 60 Questions
            // ════════════���═════════════════════════════════════════════════
            var oopQuestions = new (string Text, string A, string B, string C, string D, string Ans)[]
            {
                ("Which principle focuses on bundling data and methods?", "Inheritance", "Encapsulation", "Polymorphism", "Abstraction", "B"),
                ("What is method overriding?", "Same method name, different signatures", "Redefining parent method in child", "Changing method return type", "Creating multiple methods", "B"),
                ("Which keyword prevents inheritance?", "abstract", "static", "sealed", "readonly", "C"),
                ("What is polymorphism?", "Multiple data types", "Same interface, different behavior", "Data hiding", "Code reusability", "B"),
                ("Access modifier for same class only?", "protected", "public", "private", "internal", "C"),
                ("What is abstraction?", "Creating instances", "Hiding complexity", "Binding data", "Inheriting classes", "B"),
                ("Inheritance is also called?", "Method hiding", "IS-A relationship", "HAS-A relationship", "Association", "B"),
                ("Multiple inheritance in C# through?", "Classes", "Interfaces", "Structs", "Records", "B"),
                ("Virtual keyword enables?", "Late binding", "Early binding", "Static binding", "Compile-time binding", "A"),
                ("Protected modifier access level?", "Current class only", "Same assembly", "Derived classes", "All classes", "C"),
                ("What is composition?", "HAS-A relationship", "IS-A relationship", "Polymorphism", "Abstraction", "A"),
                ("Abstract class can have?", "Only abstract members", "Constructor and abstract members", "No members", "Only static members", "B"),
                ("Interface can contain?", "Private methods", "Implementation", "Contracts/signatures", "Fields", "C"),
                ("Why use interfaces?", "Security", "Contract enforcement", "Performance", "Memory management", "B"),
                ("this keyword refers to?", "Current class", "Base class", "Derived class", "Object reference", "A"),
                ("base keyword used for?", "Access parent members", "Access current class", "Create instance", "Initialize array", "A"),
                ("Static member belongs to?", "Instance", "Class", "Method", "Property", "B"),
                ("Sealed class can?", "Be inherited", "Have methods", "Not be inherited", "Be abstract", "C"),
                ("Constructor overloading achieves?", "Polymorphism", "Multiple object creation", "Flexibility in initialization", "Memory optimization", "C"),
                ("Destructor is called?", "Manually", "When object is garbage collected", "At compile time", "When method ends", "B"),
                ("Property with get/set is?", "Encapsulation", "Abstraction", "Inheritance", "Polymorphism", "A"),
                ("Dependency Injection provides?", "Loose coupling", "Tight coupling", "Performance", "Memory efficiency", "A"),
                ("const member is?", "Changeable", "Unchangeable", "Runtime only", "Thread-safe only", "B"),
                ("readonly differs from const?", "Same thing", "readonly changeable in constructor", "readonly is static", "const is runtime", "B"),
                ("Static constructor runs?", "Every object creation", "Once before any instance", "Never", "When garbage collected", "B"),
                ("Extension methods extend?", "Classes only", "Existing types without inheritance", "Namespaces", "Assemblies", "B"),
                ("Generic class provides?", "Type safety", "Code duplication", "Performance loss", "Memory overhead", "A"),
                ("Variance in generics?", "No relationship", "Covariance and Contravariance", "Only inheritance", "Method overloading", "B"),
                ("Namespace provides?", "Variable scope", "Organization and avoiding name conflicts", "Memory management", "Compilation speed", "B"),
                ("Internal modifier scope?", "Class only", "Same assembly", "Everywhere", "Only properties", "B"),
                ("Protected internal combines?", "Protected AND internal", "Protected OR internal", "Only protected", "Only internal", "B"),
                ("Partial class allows?", "Definition in one file", "Definition across multiple files", "Interface only", "Enum only", "B"),
                ("Anonymous type used for?", "Temporary unnamed objects", "Permanent objects", "Only methods", "Only properties", "A"),
                ("LINQ query syntax resembles?", "SQL", "C++", "Java", "JavaScript", "A"),
                ("Delegates are?", "Type-safe function pointers", "Classes", "Structs", "Properties", "A"),
                ("Events are?", "Delegates", "Wrapper around delegates", "Methods", "Properties", "B"),
                ("Lambda expression syntax?", "=>(parameters)=>body", "(parameters)=>body", "body=>parameters", "parameters==body", "B"),
                ("Action delegate returns?", "Void", "Generic type", "String", "Int", "A"),
                ("Func delegate returns?", "Void", "Specified type", "Always int", "Always string", "B"),
                ("Predicate is?", "Func returning bool", "Action returning bool", "Delegate type", "Method only", "A"),
                ("IEnumerable is?", "For iteration", "For storage", "For inheritance", "For static members", "A"),
                ("IQueryable is?", "Deferred execution locally", "Deferred execution on source", "Immediate execution", "No execution", "B"),
                ("Expression tree represents?", "Runtime code", "Lambda as tree", "Compilation", "Type info", "B"),
                ("var keyword type?", "Always dynamic", "Compile-time inferred", "Runtime determined", "System.Object", "B"),
                ("dynamic type checking?", "Compile-time", "Runtime", "Never", "Partially", "B"),
                ("Nullable<T> usage?", "Non-nullable", "Optional values", "Always null", "Never null", "B"),
                ("?. operator effect?", "Comparison", "Null coalescing", "Safe navigation", "Casting", "C"),
                ("?? operator returns?", "Right if left null", "Left if not null", "Both", "Result", "A"),
                ("??= operator does?", "Assignment if null", "Always assign", "Never assign", "Compare", "A"),
                ("Try-catch-finally order?", "Optional", "Finally always runs", "Finally optional", "Catch always", "B"),
                ("Using statement provides?", "Resource management", "Namespace only", "Type safety", "Memory", "A"),
                ("Attribute targets can?", "Class only", "Multiple targets", "Method only", "Property only", "B"),
                ("Reflection accesses?", "Compiled code", "Metadata", "Memory", "CPU", "B"),
                ("MethodInfo represents?", "Method object", "Integer", "String", "Type", "A"),
                ("PropertyInfo allows?", "Reading metadata", "Getting values", "Setting values", "Both get&set", "A"),
                ("Activator.CreateInstance?", "Creates type instance", "Deletes type", "Modifies type", "Lists types", "A")
            };

            foreach (var (text, a, b, c, d, ans) in oopQuestions)
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
                    CorrectAnswer = ans 
                });
            }

            // ══════════════════════════════════════════════════════════════
            // DATA STRUCTURES - 60 Questions
            // ══════════════════════════════════════════════════════════════
            var dsQuestions = new (string Text, string A, string B, string C, string D, string Ans)[]
            {
                ("LIFO principle followed by?", "Queue", "Stack", "Heap", "Tree", "B"),
                ("FIFO principle followed by?", "Stack", "Queue", "Both", "Neither", "B"),
                ("Array access time complexity?", "O(n)", "O(log n)", "O(1)", "O(n^2)", "C"),
                ("Array insertion worst case?", "O(1)", "O(n)", "O(log n)", "O(n^2)", "B"),
                ("Linked list access time?", "O(1)", "O(n)", "O(log n)", "O(n^2)", "B"),
                ("Linked list insertion at start?", "O(1)", "O(n)", "O(log n)", "O(n^2)", "A"),
                ("Doubly linked list advantage?", "Less memory", "Reverse traversal", "Faster", "Easier coding", "B"),
                ("Circular linked list usage?", "Simulation", "Undo/Redo", "Round-robin scheduling", "Linear search", "C"),
                ("Stack used for?", "FIFO operations", "LIFO operations", "Sorting", "Searching", "B"),
                ("Queue used for?", "BFS graph traversal", "DFS graph traversal", "Stack simulation", "Recursion", "A"),
                ("Priority Queue uses?", "Array", "Linked list", "Binary Heap", "AVL Tree", "C"),
                ("Hash table collision?", "Chaining and Open addressing", "Only chaining", "Only open addressing", "No solution", "A"),
                ("Hash function should?", "Distribute uniformly", "Create clusters", "Hash same values", "Be slow", "A"),
                ("Binary Search Tree property?", "Left > Right", "Left < Right", "No order", "Random order", "B"),
                ("BST search time?", "O(n)", "O(log n) average", "O(1)", "O(n^2)", "B"),
                ("AVL tree ensures?", "Balanced", "Unbalanced", "No height limit", "Only left heavy", "A"),
                ("Red-Black tree property?", "Balanced", "Semi-balanced", "Unbalanced", "Random color", "B"),
                ("Binary heap property?", "Parent >= children min-heap", "Parent <= children min-heap", "No order", "Random", "B"),
                ("Min-heap root is?", "Maximum element", "Minimum element", "Middle element", "Random", "B"),
                ("Heap sort time complexity?", "O(n)", "O(log n)", "O(n log n)", "O(n^2)", "C"),
                ("Graph represented as?", "Tree", "Array", "Adjacency matrix/list", "Stack", "C"),
                ("Directed graph edge?", "Bidirectional", "Unidirectional", "Both possible", "No edges", "C"),
                ("Weighted graph edge has?", "Cost/weight", "Direction only", "Color", "Label only", "A"),
                ("BFS traversal uses?", "Stack", "Queue", "Heap", "Tree", "B"),
                ("DFS traversal uses?", "Queue", "Stack", "Heap", "Deque", "B"),
                ("Topological sort for?", "Cyclic graphs", "DAGs", "Undirected graphs", "Binary trees", "B"),
                ("Dijkstra finds?", "Shortest path", "Longest path", "All paths", "Cycles", "A"),
                ("Bellman-Ford handles?", "Positive weights only", "Negative weights", "Cycles", "Disconnected graphs", "B"),
                ("Floyd-Warshall finds?", "Single pair path", "All pairs path", "Shortest cycle", "Longest path", "B"),
                ("Spanning tree has?", "n+1 edges", "n-1 edges", "n edges", "2n edges", "B"),
                ("MST can be found by?", "Dijkstra", "Kruskal/Prim", "DFS", "BFS", "B"),
                ("Kruskal sorts edges by?", "Weight", "Vertex", "Color", "Index", "A"),
                ("Trie used for?", "Prefix searches", "Range searches", "Sorting", "Hashing", "A"),
                ("B-tree used in?", "Databases", "Memory", "Cache", "Registers", "A"),
                ("Segment tree for?", "Range queries", "Single queries", "Sorting", "Searching", "A"),
                ("Fenwick tree time?", "O(n)", "O(log n)", "O(n^2)", "O(1)", "B"),
                ("Skip list level?", "Random", "Fixed", "Deterministic", "None", "A"),
                ("Disjoint set union for?", "Graph connectivity", "Sorting", "Searching", "Hashing", "A"),
                ("Union by rank optimizes?", "Time complexity", "Space", "Comparison", "Swaps", "A"),
                ("Path compression in DSU?", "Increases height", "Decreases height", "No effect", "Changes structure", "B"),
                ("Tree height O(1) with?", "Skewed tree", "AVL tree", "Random tree", "Linear tree", "B"),
                ("Suffix array used for?", "String matching", "Number sorting", "Graph traversal", "Tree balancing", "A"),
                ("KMP preprocessing creates?", "LPS array", "Failure array", "Both", "None", "C"),
                ("Boyer-Moore skips?", "Single character", "Multiple characters", "All characters", "No skipping", "B"),
                ("Rabin-Karp uses?", "Rolling hash", "Perfect hash", "No hash", "Static hash", "A"),
                ("Bloom filter trade-off?", "Time vs Space", "Memory vs Accuracy", "Speed vs Accuracy", "Space vs Time", "B"),
                ("Cache memory hierarchy?", "L1 > L2 > L3 > RAM", "RAM > L3 > L2 > L1", "L3 > L2 > L1 > RAM", "Equal speed", "A"),
                ("Virtual memory purpose?", "Increase RAM", "Speed optimization", "Extend addressable space", "Reduce latency", "C"),
                ("Page replacement LRU?", "Least Recently Used", "Least Relevant Used", "Long Running Units", "Local Regular Use", "A"),
                ("Buddy system allocates?", "Random size", "Power of 2 sizes", "Sequential", "Fragmented", "B"),
                ("Memory fragmentation type?", "Internal only", "External only", "Both internal and external", "None", "C"),
                ("Compression reduce by?", "Redundancy", "Size fixed", "Complexity", "Speed", "A"),
                ("LZ77 compression uses?", "Dictionary", "Huffman", "RLE", "Arithmetic", "A"),
                ("Deque operations?", "Front and rear both", "Front only", "Rear only", "Random", "A"),
                ("Priority vs Regular Queue?", "Same thing", "Priority ordered differently", "No difference", "Always ordered", "B"),
                ("Bitset used for?", "Boolean arrays", "Numbers only", "Strings", "Trees", "A"),
                ("Rope data structure?", "Garden tool", "Heavy string operations", "Integers", "Sorting", "B")
            };

            foreach (var (text, a, b, c, d, ans) in dsQuestions)
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
                    CorrectAnswer = ans 
                });
            }

            // ══════════════════════════════════════════════════════════════
            // .NET - 60 Questions
            // ══════════════════════════════════════════════════════════════
            var dotnetQuestions = new (string Text, string A, string B, string C, string D, string Ans)[]
            {
                ("CLR stands for?", "Common Language Runtime", "Code Level Reuse", "C# Library Runtime", "Common Logic Run", "A"),
                ("CLS requirement?", "Optional", "For language interop", "Only C#", "Never needed", "B"),
                ("IL code executes via?", "Direct CPU", "JIT compiler", "Interpreter", "Native code", "B"),
                ("Managed code benefits?", "Manual memory", "GC and safety", "Faster execution", "Lower level", "B"),
                (".NET Framework release?", "2002", "2005", "1999", "2000", "A"),
                (".NET Core purpose?", "Windows only", "Cross-platform", "Enterprise", "Web only", "B"),
                (".NET 5 unification?", "Framework only", "Core + Framework", "Separate", "Beta", "B"),
                ("async/await returns?", "Task", "Promise", "Future", "Coroutine", "A"),
                ("Task<T> represents?", "Synchronous work", "Asynchronous work", "Cancelled operation", "Failed task", "B"),
                ("await keyword does?", "Blocks thread", "Async wait", "Throws exception", "Returns null", "B"),
                ("async void usage?", "Events only", "Always ok", "Never use", "Methods only", "A"),
                ("async Main support?", "C# 5", "C# 7.1+", "C# 8", "Never", "B"),
                ("Delegate syntax?", "Interface", "Function pointer", "Method signature", "Class", "C"),
                ("Event modifier ensures?", "Encapsulation", "No access", "Controllable invocation", "Data hiding", "C"),
                ("Lambda expression benefit?", "Verbose", "Concise syntax", "Always faster", "Type safe only", "B"),
                ("Func<T1,TResult> example?", "void Method(int)", "int Add(int,int)", "public void Go()", "no return", "B"),
                ("Action<T> returns?", "Generic T", "Void", "Bool", "Int", "B"),
                ("Predicate<T> uses?", "All types", "bool return", "void only", "int only", "B"),
                ("LINQ deferred execution?", "Immediate", "Until enumeration", "At declaration", "At definition", "B"),
                ("IEnumerable vs IQueryable?", "Same thing", "Queryable for data sources", "IEnumerable faster", "No difference", "B"),
                ("Expression tree represents?", "Runtime code", "Lambda as tree", "Compilation", "Type info", "B"),
                ("var keyword type?", "Always dynamic", "Compile-time inferred", "Runtime determined", "System.Object", "B"),
                ("dynamic type checking?", "Compile-time", "Runtime", "Never", "Partially", "B"),
                ("Extension method first param?", "Normal", "this keyword", "ref", "params", "B"),
                ("Nullable<T> usage?", "Non-nullable", "Optional values", "Always null", "Never null", "B"),
                ("?. operator effect?", "Comparison", "Null coalescing", "Safe navigation", "Casting", "C"),
                ("?? operator returns?", "Right if left null", "Left if not null", "Both", "Result", "A"),
                ("??= operator does?", "Assignment if null", "Always assign", "Never assign", "Compare", "A"),
                ("Try-catch-finally order?", "Optional", "Finally always runs", "Finally optional", "Catch always", "B"),
                ("Using statement provides?", "Resource management", "Namespace only", "Type safety", "Memory", "A"),
                ("Attribute targets can?", "Class only", "Multiple targets", "Method only", "Property only", "B"),
                ("Reflection accesses?", "Compiled code", "Metadata", "Memory", "CPU", "B"),
                ("MethodInfo represents?", "Method object", "Integer", "String", "Type", "A"),
                ("PropertyInfo allows?", "Reading metadata", "Getting values", "Setting values", "Both get&set", "A"),
                ("Activator.CreateInstance?", "Creates type instance", "Deletes type", "Modifies type", "Lists types", "A"),
                ("POCO benefits?", "Entity Framework", "EF and LINQ", "Only classes", "No benefits", "B"),
                ("DbContext represents?", "Database table", "ORM session", "SQL connection", "DbSet", "B"),
                ("DbSet<T> represents?", "Single record", "Table/collection", "Database", "Query", "B"),
                ("SaveChanges tracks?", "All entities", "New entities", "Deleted entities", "All changes", "A"),
                ("Eager loading uses?", "Include()", "First()", "Where()", "Select()", "A"),
                ("Lazy loading default?", "Always on", "Off in some contexts", "Virtual navigation", "Disabled", "C"),
                ("Explicit loading uses?", "Load()", "Load<T>()", "Entry().Collection()", "Correct answers", "C"),
                ("Navigation property?", "Foreign key", "Related entity", "Data column", "Table name", "B"),
                ("Shadow property purpose?", "Database only", "Hidden from model", "Type safety", "Performance", "B"),
                ("Value object in EF?", "Has ID", "No ID", "Table mapped", "Always persisted", "B"),
                ("Owned entity mapping?", "Separate table", "Parent table", "No mapping", "Optional", "B"),
                ("HasKey() designates?", "Primary key", "Foreign key", "Index", "Constraint", "A"),
                ("HasMany().WithOne?", "One to many", "Many to one", "Many to many", "One to one", "A"),
                ("HasOne().WithMany?", "Many to many", "One to many", "One to one", "Many to one", "B"),
                ("HasMany().WithMany?", "One to one", "One to many", "Many to many", "Tree", "C"),
                ("Migration adds version?", "No version", "Auto incrementing", "Timestamp", "Manual", "B"),
                ("Add-Migration creates?", "Migration file", "Database", "Table", "Connection", "A"),
                ("Update-Database applies?", "EF model", "Pending migrations", "Current migration", "All migrations", "B"),
                ("Scaffold-DbContext generates?", "DbContext", "Models from DB", "Both context and models", "Migrations", "C"),
                ("Computed columns in DB?", "Stored", "Not stored", "Always computed", "Never used", "A"),
                ("Concurrency token prevents?", "Duplicate keys", "Simultaneous updates", "Null values", "Invalid types", "B"),
                ("Model validation in EF?", "None", "Data Annotations", "Fluent API", "Both", "D"),
                ("OnModelCreating called?", "Once per context", "Every operation", "Never", "Rarely", "A"),
                ("GlobalQueryFilters for?", "Soft delete", "Multi-tenancy", "Security", "All above", "D")
            };

            foreach (var (text, a, b, c, d, ans) in dotnetQuestions)
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
                    CorrectAnswer = ans 
                });
            }

            return questions;
        }
    }
}
