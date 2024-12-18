using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private Queue<Person> _people;

    public TakingTurnsQueue()
    {
        _people = new Queue<Person>();
    }

    public int Length => _people.Count;

    public void AddPerson(string name, int turns)
    {
        // Add a new person to the queue
        _people.Enqueue(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Dequeue the next person in line
        var person = _people.Dequeue();

        if (person.Turns > 0) // For finite turns
        {
            person.Turns -= 1; // Decrease their remaining turns
            if (person.Turns > 0) _people.Enqueue(person); // Re-enqueue if they still have turns left
        }
        else if (person.Turns == 0 || person.Turns < 0) // For infinite turns
        {
            _people.Enqueue(person); // Always re-enqueue
        }

        return person; // Return the person whose turn it is
    }
}
