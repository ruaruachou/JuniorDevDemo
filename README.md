# JuniorDevDemo
### Abstract抽象类  
#### 1.因为其作为基类时过于抽象，可以不用给出任何具体实现。基类负责定义基本结构，派生类负责具体实现  
#### 2.仅用于被其他类继承
#### 3.抽象类脚本不能实例化，也就是说不能挂载，不能new
#

## 一段抽象类示例 
#

```
// 抽象类
public abstract class Shape
{
    public abstract void Draw(); 
    // 抽象方法，没有具体实现。
    //注意：基类中的抽象方法必须要在派生类中override实现，不能置之不理。

    public void PrintName()//普通方法
    {
        Debug.Log("This is a shape.");
    }
}

// 派生类
public class Circle : Shape
{
    public override void Draw()//在派生类中进行具体实现
    {
        Debug.Log("Drawing a circle.");
    }
}

public class Square : Shape
{
    public override void Draw()
    {
        Debug.Log("Drawing a square.");
    }
}

// 使用抽象类和派生类
void Start()
{
    Shape circle = new Circle();
    circle.Draw(); // 输出: Drawing a circle.
    circle.PrintName(); // 输出: This is a shape.实现普通方法

    Shape square = new Square();
    square.Draw(); // 输出: Drawing a square.
    square.PrintName(); // 输出: This is a shape.
}
```

👆在以上基础上，对普通方法进行多态化
#
```
// 抽象类
public abstract class Shape
{
    public abstract void Draw(); // 抽象方法

    public virtual void PrintName() // 将普通方法转为虚方法，以便在派生类中重写
    {
        Debug.Log("This is a shape.");
    }
}

// 派生类
public class Circle : Shape
{
    public override void Draw()
    {
        Debug.Log("Drawing a circle.");
    }

    public override void PrintName()
    {
        Debug.Log("This is a circle."); // 重写基类方法
    }
}

public class Square : Shape
{
    public override void Draw()
    {
        Debug.Log("Drawing a square.");
    }

    public override void PrintName()
    {
        Debug.Log("This is a square."); // 重写基类方法
    }
}

// 使用抽象类和派生类
void Start()
{
    Shape circle = new Circle();
    circle.Draw(); // 输出: Drawing a circle.
    circle.PrintName(); // 输出: This is a circle.

    Shape square = new Square();
    square.Draw(); // 输出: Drawing a square.
    square.PrintName(); // 输出: This is a square.
}
```