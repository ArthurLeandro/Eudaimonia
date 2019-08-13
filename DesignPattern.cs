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
  
}
