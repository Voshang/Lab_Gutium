using System;

interface Iholiday
{
    void ContemplateExistence();
}

interface IReflect
{
    void ReflectOnLife();
}

public abstract class Philosopher : Iholiday
{
    protected string Name;
    protected int IQ;

    public static Random random = new Random();

    public const int minIQ = 70;
    public const int maxIQ = 200;

    public Philosopher()
    {
        string[] Names = { "Socrates", "Nietzsche", "Descartes" };
        Name = Names[random.Next(Names.Length)];
        IQ = random.Next(minIQ, maxIQ);
    }

    public Philosopher(int IQ)
    {
        string[] Names = { "Socrates", "Nietzsche", "Descartes" };
        Name = Names[random.Next(Names.Length)];
        this.IQ = IQ;
    }

    public virtual void Print()
    {
        Console.WriteLine($"My name is {Name}. My IQ is {IQ}.");
    }
    public abstract void ExpressThoughts();

    public virtual void ResetName()
    {
        Name = "?";
    }

    public abstract void ContemplateExistence();
}

public sealed class Stoic : Philosopher, IReflect
{
    double Wisdom;
    bool Ataraxia;
    string Quote = "The only thing we control is our perception.";

    public Stoic() : base()
    {
        Wisdom = random.NextDouble() * 100;
        Ataraxia = random.Next(10) > 5;
    }

    public Stoic(int x, double d) : base(x)
    {
        Wisdom = d;
        if (Quote == "The only thing we control is our perception.")
        {
            Ataraxia = true;
        }
    }

    public override void Print()
    {
        Console.WriteLine("I am a true Stoic.");
        base.Print();

        if (Ataraxia)
        {
            Console.WriteLine("\n I have achieved peace through acceptance.");
        }
        else
        {
            Console.WriteLine("\n I struggle, but I endure.");
        }

        Console.WriteLine($"My wisdom level is {Wisdom}.");
    }

    public override void ExpressThoughts()
    {
        Console.WriteLine(Ataraxia ? "Accept fate as it comes." : "Endure, for life is struggle.");
    }

    public void PracticeVirtue()
    {
        if (Wisdom > 50)
        {
            Console.WriteLine("\n I live a life of virtue and reason.");
        }
        else
        {
            Console.WriteLine("\n I seek wisdom, for I am yet learning.");
        }
    }

    public override void ContemplateExistence()
    {
        Wisdom *= 1.1;
        Ataraxia = !Ataraxia;
    }

    public void ReflectOnLife()
    {
        Console.WriteLine("A Stoic reflects: Life is about controlling perception and accepting fate.");
    }
}

public sealed class Existentialist : Philosopher, IReflect
{
    float Angst;
    byte FreedomLevel;

    public Existentialist() : base()
    {
        Angst = (float)random.NextDouble();
        FreedomLevel = (byte)random.Next(1, 10);
    }

    public Existentialist(int x, float b, byte v) : base(x)
    {
        Angst = b;
        FreedomLevel = v;
    }

    public override void Print()
    {
        Console.WriteLine("I am an Existentialist.");
        base.Print();
        Console.WriteLine($"\n My level of existential angst is {Angst}.");
        Console.WriteLine($"\n I am {FreedomLevel * 10}% free!");
    }

    public void ConfrontAbsurdity()
    {
        Angst *= 1.5f;
        Console.WriteLine("I gaze into the void, and it gazes back.");
    }

    public override void ExpressThoughts()
    {
        string reflection = FreedomLevel < 5 ? "I am condemned to be free." : "I define my own essence.";
        Console.WriteLine(reflection);
    }

    public override void ContemplateExistence()
    {
        FreedomLevel = 10;
        Angst *= 0.5f;
    }

    public void ReflectOnLife()
    {
        Console.WriteLine("An Existentialist reflects: Life is absurd, but I create my own meaning.");
    }
}

public sealed class Nihilism : Philosopher, IReflect
{
    int feelings;
    bool meaninglessness;

    public Nihilism() : base()
    {
        feelings = random.Next(10);
        meaninglessness = random.Next(2) == 1;
    }


    public override void Print()
    {
        Console.WriteLine($"My feelings are {feelings}.");
        if (feelings > 5)
        {
            Console.WriteLine("I feel nothing.");
        }
        else
        {
            Console.WriteLine("I feel everything.");
        }
        Console.WriteLine("I am a Nihilist.");
        base.Print();
    }

    public override void ExpressThoughts()
    {
        Console.WriteLine("Nothing matters, and that's the point.");
    }

    public override void ContemplateExistence()
    {
        Console.WriteLine("Contemplating existence is futile.");
    }

    public void ReflectOnLife()
    {
        Console.WriteLine("A Nihilist reflects: Life is devoid of meaning, but I find freedom in that.");
    }

    public void Rejection()
    {
        if (meaninglessness)
        {
            Console.WriteLine("I reject all meaning and purpose.");
        }
        else
        {
            Console.WriteLine("I accept the absurdity of existence.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Philosopher[] symposium = new Philosopher[8];
        for (int i = 0; i < symposium.Length; i += 2)
        {
            symposium[i] = new Stoic();
            symposium[i + 1] = new Existentialist();
        }

        for (int i = 0; i < symposium.Length; i++)
        {
            symposium[i].ExpressThoughts();
            symposium[i].ContemplateExistence();
            symposium[i].ExpressThoughts();
        }

        for (int i = 0; i < symposium.Length; i++)
        {
            if (symposium[i] is Existentialist existentialist)
            {
                existentialist.ConfrontAbsurdity();
            }
            else if (symposium[i] is Stoic stoic)
            {
                stoic.PracticeVirtue();
            }
        }

        Console.WriteLine("\nReflections on life:");
        for (int i = 0; i < symposium.Length; i++)
        {
            if (symposium[i] is IReflect reflectivePhilosopher)
            {
                reflectivePhilosopher.ReflectOnLife();
            }
        }

        IReflect[] philosophers = new IReflect[16];
        for (int i = 0; i < philosophers.Length; i++)
        {
            if (i % 3 == 0)
                philosophers[i] = new Nihilism();
            else if (i % 3 == 1)
                philosophers[i] = new Stoic();
            else
                philosophers[i] = new Existentialist();

            philosophers[i].ReflectOnLife();
        }
    }
}