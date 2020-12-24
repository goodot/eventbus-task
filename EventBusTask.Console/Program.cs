using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EventBusTask.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventBus = new EventBus();
            eventBus.RegisterEvent("myEvent1");
            eventBus.RegisterEvent("myEvent2");
            eventBus.Subscribe("myEvent1", o => System.Console.WriteLine($"event 1: {JsonConvert.SerializeObject(o)}"));
            eventBus.Subscribe("myEvent2", o => System.Console.WriteLine($"event 2: {JsonConvert.SerializeObject(o)}"));
            eventBus.Subscribe("myEvent2", o => System.Console.WriteLine($"event 2: {JsonConvert.SerializeObject(o)}"));
            eventBus.Trigger("myEvent1", new {name = "europebet 1"});
            eventBus.Trigger("myEvent2", new {name = "europebet 2"});
            System.Console.ReadKey();

            
        }

       
    }
}