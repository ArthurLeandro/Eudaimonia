namespace DesignPatterns
{
   
  namespace Observer Pattern
  {
    public interface ISubject 
    {
      void Register(IObservable o);
      void Unregister(IObservable o);
      void NotifyRegisteredUsers();
    }
    public interface IObservable
    {    
      void Update();
    }
  
    public class Observer : ISubject
    {
      List<IObservable> observerList = new List<IObservable>();
      public void Register(IObservable o)
      {
        observerList.Add(o);
      }
      public void Unregister(IObservable o)
      {
        observerList.Remove(o);
      }
      public void NotifyRegisteredUsers()
      {
        foreach (IObservable observer in observerList)
        {
            observer.Update();
        }
      }

    }
  }
  
  /// <summary>
  /// Encapsulate a request as an object, thereby letting you parameterize clients with
  /// different requests, queue or log requests, and support undoable operations.
  /// </summary>
  namespace Command Pattern
  {
    public interface IComand
    {
      void Do();
    }
    public abstract class Receiver
    {
      public abstract void PerformUndo(){}
      public abstract void PerformRedo(){}
      public abstract void OptionalTaskPriorToRedo(){}
      public abstract void OptionalTaskPriorToUndo(){}
    }
    public class Invoke
    {
      IComand commandToBePerformed;
      public void SetCommand(IComand command)
      {
        this.commandToBePerformed = command;
      }
      public void ExecuteCommand()
      {
        commandToBePerformed.Do();
      }
    }
    
    public class UndoCommand : IComand
    {
      Receiver receiver;
      public UndoCommand(Receiver _receiver)
      {
        this.receiver = _receiver;
      }
      public void Do()
      {
        receiver.OptionalTaskPriorToUndo();
        receiver.PerformUndo();
      }
    }   
    public class RedoCommand : IComand
    {
      Receiver receiver;
      public RedoCommand(Receiver _receiver)
      {
        this.receiver = _receiver;
      }
      public void Do()
      {
        receiver.OptionalTaskPriorToRedo();
        receiver.PerformRedo();
      }
    }    
  }

  /// <summary>
  /// Without violating encapsulation, capture and externalize an object’s internal state so that
  /// the object can be restored to this state later.
  /// </summary>
  namespace MementoPattern
  {
      public class Memento <T>
      {
        public T state;
        public T State{get{return state;} set{state = value;}}
      }
      public class Originator <T>
      {
        Memento myMemento;
        T state;
        public T State{get{return state;}set{state = value;}}
        public Memento GetMemento()
        {
          myMemento = new Memento();
          myMemento.State = state;
          return myMemento;
        }
        public void RevertToPreviousState(Memento previousMemento)
        {
          this.state = previousMemento.State;
        }
      }
  }
  /// <summary>
  /// Define an object that encapsulates how a set of objects interact.
  /// </summary>
  namespace Mediator Pattern
  {
   //TODO
  }
   
  /// <summary>
  /// YOu can select the behaviour of an algorithm at runtime.
  /// </summary>
   namespace Strategy Pattern
   {
      public interface IChoice{
         void MyChoice();
      }
      public class FirstChoice:IChoice
      {
         public void MyChoice()
      }
      public class SecondChoice:IChoice
      {
         public void MyChoice()
      }
      public class Context
      {
         IChoice choice;
         /*It's our choice. We prefer to use a setter method instead of
         using a constructor. We can call this method whenever we want to
         change the "choice behavior" on the fly*/
         public void SetChoice(IChoice choice)
         {
            this.choice = choice;
         }
         /* This method will help us to delegate the particular
         object's choice behavior/characteristic*/
         public void ShowChoice()
         {
            choice.SetChoice();
         }
     }
   }
   
   ///<summary>
   ///This pattern requires that the Decorator and our object are derived from a common base
   ///class so they share the same interface. Each Decorator will then layer itself on top of an
   ///object or another interface to create more interesting object types and effects.
   ///</sumary>
   namespace Decorator Pattern
   {
      abstract class Component
      {
         public abstract void MakeAction();
      }
      class ConcreteComponent : Component
      {
         public override void MakeAction()
         {
            Console.WriteLine("Perform some modification.");
         }
      }
      abstract class AbstractDecorator : Component
      {
         protected Component com ;
         public void SetTheComponent(Component c)
         {
            com = c;
         }
         public override void MakeAction()
         {
            if (com != null)
            {
               com.MakeAction();//Delegating the task
            }
         }
      }
   }
   class ConcreteDecoratorEx1 : AbstractDecorator
   {
      public override void MakeHouse()
      {
         base.MakeHouse();
         //Decorating now.
        AddAction();
        //You can put additional stuff as per your needs.
      }
      private void AddAction()
      {
      Console.WriteLine("I am making an additional action on top of it.");
      }
   }
 }

namespace State Pattern
{
   interface IMediator
   {
      void Register(Friend friend);
      void Send(Friend friend, string msg);
   }
// ConcreteMediator
   class ConcreteMediator : IMediator
   {
      //private Friend friend1,friend2,boss;
      List<Friend> participants = new List<Friend>();
      public void Register(Friend friend)
      {
         participants.Add(friend);
      }
      public void DisplayDetails()
      {
         Console.WriteLine("At present, registered Participants are:");
         foreach (Friend friend in participants)
         {
            Console.WriteLine("{0}", friend.Name);
         }
      }
      public void Send(Friend friend, string msg)
      {
         if (participants.Contains(friend))
         {
            Console.WriteLine(String.Format("[{0}] posts: {1} Last
            message posted {2}", friend.Name, msg, DateTime.Now));

            System.Threading.Thread.Sleep(1000);
         }
         else
         {
         Console.WriteLine("An outsider named {0} trying to send some messages", friend.Name);

         }
      }
       // Friend
   abstract class Friend
   {
      protected IMediator mediator;
      private string name;
      public string Name
      {
         get { return name; }
         set { name = value; }
      }
      // Constructor
      public Friend(IMediator mediator)
      {
         this.mediator = mediator;
      }
   }
   // Friend1-first participant
   class Friend1 : Friend
   {
      public Friend1(IMediator mediator, string name)
      : base(mediator)
      {
         this.Name = name;
      }
      public void Send(string msg)
      {
         mediator.Send(this,msg);
      }
   }
   // Friend2-Second participant
   class Friend2 : Friend
   {
      // Constructor
      public Friend2(IMediator mediator, string name)
      : base(mediator)
      {  
         this.Name = name;
      }
      public void Send(string msg)
      {
         mediator.Send(this, msg);
      }
    }
   /* Friend3-Third Participant.He is the boss.*/
   class Boss : Friend
   {
      // Constructor
      public Boss(IMediator mediator, string name)
      : base(mediator)
      {
         this.Name = name;
      }
      public void Send(string msg)
      {
         mediator.Send(this, msg);
      }
   }

   // Friend4-4th participant who will not register himself to the
   // mediator. Still he will try to send a message.
   class Unknown: Friend
   {
      // Constructor
      public Unknown(IMediator mediator, string name)
      : base(mediator)
      {
         this.Name = name;
      }
      public void Send(string msg)
      {
         mediator.Send(this, msg);
      }
   }
}
///
/// Factory to create objects
///
namespace FactoryMethodPattern
{
   public interface IAnimal
   {
      void Speak();
      void Action();
   }
   

   public class Dog : IAnimal
   {
      public void Speak()
      {
         Console.WriteLine("Dog says: Bow-Wow.");
      }
      public void Action()
      {
         Console.WriteLine("Dogs prefer barking...\n");
      }
   }
   public class Tiger : IAnimal
   {
      public void Speak()
      {
         Console.WriteLine("Tiger says: Halum.");
      }
      public void Action()
      {
         Console.WriteLine("Tigers prefer hunting...\n");
      }
   }
   public abstract class IAnimalFactory
   {
      //Remember the GoF definition which says "....Factory method lets a class
      //defer instantiation to subclasses." Following method will create a Tiger
      //or Dog But at this point it does not know whether it will get a Dog or a
      //Tiger. It will be decided by the subclasses i.e.DogFactory or TigerFactory.
      //So, the following method is acting like a factory (of creation).
      public abstract IAnimal CreateAnimal();
   }
   public class DogFactory : IAnimalFactory
      {
         public override IAnimal CreateAnimal()
         {
            //Creating a Dog
            return new Dog();
         }
      }
   public class TigerFactory : IAnimalFactory
   {
      public override IAnimal CreateAnimal()
      {
         //Creating a Tiger
         return new Tiger();
      }
   }
}
///
/// Factory to create abstract objects
///
namespace AbstractFactoryPattern
{
   public interface IDog
   {
      void Speak();
      void Action();
   }
   public interface ITiger
   {
      void Speak();
      void Action();
   }
   #region Wild Animal collections
   class WildDog : IDog
   {
      public void Speak()
      {
         Console.WriteLine("Wild Dog says: Bow-Wow.");
      }
      public void Action()
      {
          Console.WriteLine("Wild Dogs prefer to roam freely in jungles.\n");
      }
   }
   class WildTiger : ITiger
   {
      public void Speak()
      {
         Console.WriteLine("Wild Tiger says: Halum.");
      }
      public void Action()
      {
         Console.WriteLine("Wild Tigers prefer hunting in jungles.\n");
      }
    }
    #endregion
   #region Pet Animal collections
   class PetDog : IDog
   {
      public void Speak()
      {
         Console.WriteLine("Pet Dog says: Bow-Wow.");
      }
      public void Action()
      {
         Console.WriteLine("Pet Dogs prefer to stay at home.\n");
      }
   }
   class PetTiger : ITiger
   {
      public void Speak()
      {
         Console.WriteLine("Pet Tiger says: Halum.");
      }
      public void Action()
      {
         Console.WriteLine("Pet Tigers play in an animal circus.\n");
      }
   }
   #endregion
   //Abstract Factory
   public interface IAnimalFactory
   {
      IDog GetDog();
      ITiger GetTiger();
   }
   //Concrete Factory-Wild Animal Factory
   public class WildAnimalFactory : IAnimalFactory
   {
      public IDog GetDog()
      {
      return new WildDog();
      }
      public ITiger GetTiger()
      {
         return new WildTiger();
      }
   }
   //Concrete Factory-Pet Animal Factory
   public class PetAnimalFactory : IAnimalFactory
   {
      public IDog GetDog()
      {
         return new PetDog();
      }
      public ITiger GetTiger()
      {
         return new PetTiger();
      }
   }
 }
 
 namespace PrototypePattern
{
public abstract class BasicCar
{
public string ModelName{get;set;}
public int Price {get; set;}
public static int SetPrice()
{
int price = 0;
Random r = new Random();
int p = r.Next(200000, 500000);
price = p;
return price;
}
public abstract BasicCar Clone();
}
}
//Nano.cs
using System;
namespace PrototypePattern
{
public class Nano:BasicCar
{
public Nano(string m)
{
ModelName = m;
}
public override BasicCar Clone()
{
Chapter 2 Prototype Pattern

23

return (Nano) this.MemberwiseClone();//shallow Clone
}
}
}
//Ford.cs
using System;
namespace PrototypePattern
{
public class Ford:BasicCar
{
public Ford(string m)
{
ModelName = m;
}
public override BasicCar Clone()
{
return (Ford)this.MemberwiseClone();
}
}
}
//Client
 
 namespace GameObject Pool
 {
      Class Object Pool
      {
        List<Game Object> pool;
        Singleton<Object Pool>;
        public static Object Pool GetInstance(){//singleton basico}
        Game Object AcquireObject(){
         se a lista nao estiver vazia{
           pegar o último elemento da lista pool
           retornar esse elemento
         }
        senao retorna um novo elemento do tipo GameObject
         }
        void ReleaseObject(GameObject object){
           reseta as caracteristicas e propriedades do objeto
           adiciona ele ao fim da lista
         }
        void ClearPool(){
           enquanto a lista nao estiver vazia{
           delete o último elemento dela
        }
      }
}
 
 }
 ///
 /// same object used in diferent instances
 ///
 namespace Flyweight Pattern
 {
   /// <summary>
   /// The 'Flyweight' interface
   /// </summary>
   interface IRobot
   {
   void Print();
   }

   Chapter 10 Flyweight Pattern

   128
   /// <summary>
   /// A 'ConcreteFlyweight' class
   /// </summary>
   class SmallRobot : IRobot
   {
   public void Print()
   {
   Console.WriteLine("This is a small Robot");
   }
   }
   /// <summary>
   /// A 'ConcreteFlyweight' class
   /// </summary>
   class LargeRobot : IRobot
   {
   public void Print()
   {
   Console.WriteLine("I am a large Robot");
   }
   }
   /// <summary>
   /// The 'FlyweightFactory' class
   /// </summary>
   class RobotFactory
   {
   Dictionary<string, IRobot> shapes = new Dictionary<string,
   IRobot>();
   public int TotalObjectsCreated
   {
   get {return shapes.Count;}
   }
   public IRobot GetRobotFromFactory(string robotType)
   {
   IRobot robotCategory = null;
   Chapter 10 Flyweight Pattern

   129

   if (shapes.ContainsKey(robotType))
   {
   robotCategory = shapes[robotType];
   }
   else
   {
   switch (robotType)
   {
   case "Small":
   robotCategory = new SmallRobot();
   shapes.Add("Small", robotCategory);
   break;
   case "Large":
   robotCategory = new LargeRobot();
   shapes.Add("Large", robotCategory);
   break;
   default:
   throw new Exception("Robot Factory can create only

   small and large robots");

   }
   }
   return robotCategory;
   }
 }
 
}
