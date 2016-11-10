using System;

namespace OperatorOverloading {
  struct MyFraction {
    public long Num {get; set;}
    public long Denom {get; set;}
    public MyFraction(long num, long denom) {
      Num = num;
      Denom = denom;
      Simplify();
    }
    public static MyFraction operator +(MyFraction f1, MyFraction f2) {
      long tempNum = f1.Num * f2.Denom + f2.Num * f1.Denom;
      long tempDenom = f1.Denom * f2.Denom;
      return new MyFraction(tempNum, tempDenom); 
    }
    public static MyFraction operator -(MyFraction f1, MyFraction f2) {
      long tempNum = f1.Num * f2.Denom - f2.Num * f1.Denom;
      long tempDenom = f1.Denom * f2.Denom;
      return new MyFraction(tempNum, tempDenom); 
    }
    public static MyFraction operator *(MyFraction f1, MyFraction f2) {
      long tempNum = f1.Num * f2.Num;
      long tempDenom = f1.Denom * f2.Denom;
      return new MyFraction(tempNum, tempDenom); 
    }
    public static MyFraction operator /(MyFraction f1, MyFraction f2) {
      long tempNum = f1.Num * f2.Denom;
      long tempDenom = f1.Denom * f2.Num;

      if (tempDenom == 0) throw new DivideByZeroException();
      else return new MyFraction(tempNum, tempDenom); 
    }
    public static MyFraction operator -(MyFraction f) {
      return new MyFraction(-f.Num, f.Denom);
    }
    public static bool operator ==(MyFraction f1, MyFraction f2) {
      return f1.Num * f2.Denom == f2.Num * f1.Denom;
    }
    public static bool operator !=(MyFraction f1, MyFraction f2) {
      return !(f1 == f2);
    }
    public override bool Equals(Object o) {
      if(!(o is MyFraction)) return false;
      return this == (MyFraction)o;
    }
    public override int GetHashCode() {
      return (int)(Num ^ Denom); 
    }
    private void Simplify() {
      long gcd;
      if (Denom < 0) {
        Num = -Num;
        Denom = -Denom;
      }
      gcd = GetGCD(Num, Denom);
      Num = Num / gcd;
      Denom = Denom / gcd;  
    }
    private long GetGCD(long a, long b) {
      long rem;
      while (b != 0) {
        rem = a%b;
        a = b;
        b = rem;
      }
      return a;
    } 
  }
}
