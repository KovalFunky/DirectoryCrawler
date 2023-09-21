

using System;

namespace EnumerateAllFiles
{

    public class EventManagerLibraryClass
    {
        internal void FireEvent(EventHandler<OwnArgsLibraryClass> MyEvent, OwnArgsLibraryClass ownArgs=null)
        {
            if (ownArgs == null) { ownArgs = new OwnArgsLibraryClass(); }

            MyEvent?.Invoke(this, ownArgs);
        }
    }
}

////Variables
//bool recurse = true;

////Events
//public event EventHandler<OwnArgsLibraryClass> EventNotFired;
//public event EventHandler<OwnArgsLibraryClass> EventCorectlyFired;

////Methods
//private bool ReverseIt(bool _recurse)
//{
//    if (_recurse)
//    {
//        return false;
//    }
//    else
//    {
//        return true;
//    }
//}
//public void RunOnce(EventHandler<OwnArgsLibraryClass> ownEvent, OwnArgsLibraryClass ownArgsLibraryClass=null)
//{
//    if (ownArgsLibraryClass==null)
//    {
//        ownArgsLibraryClass = new OwnArgsLibraryClass();
//    }
//    if (ownEvent == null)
//    {
//        if (EventNotFired != null && recurse != false)
//        {
//            recurse = ReverseIt(recurse);
//            RunOnce(EventNotFired, new OwnArgsLibraryClass() { message = "Event to run is Null" });
//            recurse = ReverseIt(recurse);
//        }
//    }
//    if (ownEvent!=null)
//    {
//        ownEvent?.Invoke(this, ownArgsLibraryClass);

//        if (EventCorectlyFired != null && recurse!=false)
//        {
//            recurse = ReverseIt(recurse);
//            RunOnce(EventCorectlyFired, new OwnArgsLibraryClass() { message = "Event corect succesfully" });
//            recurse = ReverseIt(recurse);
//        }
//    }
//}
//else
//{
//    if (ownArgsLibraryClass==null)
//    {
//        ownArgsLibraryClass = new OwnArgsLibraryClass();
//        ownEvent?.Invoke(this, ownArgsLibraryClass);
//    }
//    else
//    {
//        ownEvent?.Invoke(this, ownArgsLibraryClass);return;
//    }
//    if (EventCorectlyFired!=null && ownArgsLibraryClass.message!= "Event to run is Null")
//    {
//        RunOnce(EventCorectlyFired, new OwnArgsLibraryClass() { message = "Event corect succesfully" });
//    }

//}

//private OwnArgsLibraryClass ownArgument;
//private List<(EventHandler<OwnArgsLibraryClass> myEvent, OwnArgsLibraryClass myArguments)> eventList;

//public event EventHandler<OwnArgsLibraryClass> BeForeEventFired;
//public event EventHandler<OwnArgsLibraryClass> AfterEventFired;

//public EventManagerLibraryClass()
//{
//    ownArgument = new OwnArgsLibraryClass();
//    eventList = new List<(EventHandler<OwnArgsLibraryClass> myEvent, OwnArgsLibraryClass myArguments)>();
//}
//public void Add(EventHandler<OwnArgsLibraryClass> eventAddToList, OwnArgsLibraryClass args = null)
//{
//    if (args != null)
//    {
//        eventList.Add((eventAddToList, args));
//    }
//    else
//    {
//        eventList.Add((eventAddToList, new OwnArgsLibraryClass()));
//    }
//}
//private void FireOwnEvent(EventHandler<OwnArgsLibraryClass> MyEvent, OwnArgsLibraryClass ownEventArgs = null)
//{
//    if (ownEventArgs != null && MyEvent != null)
//    {
//        MyEvent?.Invoke(this, ownEventArgs);
//    }
//    else if (ownEventArgs == null && MyEvent != null)
//    {
//        MyEvent?.Invoke(this, new OwnArgsLibraryClass());
//    }
//}
//public void FireEvent(EventHandler<OwnArgsLibraryClass> MyEvent = null, OwnArgsLibraryClass ownEventArgs = null)
//{
//    if (MyEvent == null && ownEventArgs == null)
//    {
//        foreach (var item in eventList)
//        {
//            FireOwnEvent(BeForeEventFired);
//            item.myEvent?.Invoke(this, item.myArguments);
//            FireOwnEvent(AfterEventFired);
//        }
//    }
//    else if (MyEvent != null && ownEventArgs != null)
//    {
//        MyEvent?.Invoke(this, ownEventArgs);
//    }
//    else if (MyEvent != null && ownEventArgs == null)
//    {
//        MyEvent?.Invoke(this, new OwnArgsLibraryClass());
//    }
//    else if (MyEvent == null && ownEventArgs != null)
//    {
//        foreach (var item in eventList)
//        {
//            item.myEvent?.Invoke(this, ownEventArgs);
//        }
//    }

//}