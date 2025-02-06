using System;
using Microsoft.Z3;

public static class SMT
{
    public static void Solve()
    {
        using (Context ctx = new Context())
        {
            Solver solver = ctx.MkSolver();

            // Definiowanie zmiennych
            IntExpr x1 = ctx.MkIntConst("x1");
            IntExpr x2 = ctx.MkIntConst("x2");
            IntExpr x3 = ctx.MkIntConst("x3");
            IntExpr x4 = ctx.MkIntConst("x4");
            IntExpr x5 = ctx.MkIntConst("x5");
            IntExpr x6 = ctx.MkInt(144); // x6 = 144 z zadania
            IntExpr x7 = ctx.MkIntConst("x7");

            // Ograniczenia: dodatnie liczby całkowite
            solver.Add(ctx.MkGt(x1, ctx.MkInt(0)));
            solver.Add(ctx.MkGt(x2, ctx.MkInt(0)));
            solver.Add(ctx.MkGt(x3, ctx.MkInt(0)));
            solver.Add(ctx.MkGt(x4, ctx.MkInt(0)));
            solver.Add(ctx.MkGt(x5, ctx.MkInt(0)));
            solver.Add(ctx.MkGt(x7, ctx.MkInt(0)));

            // Warunki rekurencyjne
            solver.Add(ctx.MkEq(x4, ctx.MkMul(x3, ctx.MkAdd(x2, x1))));
            solver.Add(ctx.MkEq(x5, ctx.MkMul(x4, ctx.MkAdd(x3, x2))));
            solver.Add(ctx.MkEq(x6, ctx.MkMul(x5, ctx.MkAdd(x4, x3))));
            solver.Add(ctx.MkEq(x7, ctx.MkMul(x6, ctx.MkAdd(x5, x4))));

            // Czy istnieje rozwiązanie
            if (solver.Check() == Status.SATISFIABLE)
            {
                Model model = solver.Model;
                Console.WriteLine("Rozwiązanie:");
                Console.WriteLine($"x1 = {model.Eval(x1)}, x2 = {model.Eval(x2)}, x3 = {model.Eval(x3)}");
                Console.WriteLine($"x4 = {model.Eval(x4)}, x5 = {model.Eval(x5)}, x6 = {x6}, x7 = {model.Eval(x7)}");
            }
            else
            {
                Console.WriteLine("Brak rozwiązania spełniającego warunki.");
            }
        }
    }
}
